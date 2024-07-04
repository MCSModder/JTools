using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TierneyJohn.MiChangSheng.JTools.Exception.AssetBundleException;
using TierneyJohn.MiChangSheng.JTools.Util;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace TierneyJohn.MiChangSheng.JTools.Manager;

/// <summary>
/// AB 包资源加载管理器
/// </summary>
public class AssetBundleManager : MonoBehaviour
{
    #region 实例对象

    public static AssetBundleManager Inst;

    #endregion

    #region 私有字段/属性

    private readonly Dictionary<string, AssetBundle> _loadAssetBundles = new();
    private string _assetBundlePath;

    #endregion

    #region Unity 事件函数

    private void Awake() { Inst = this; }

    private void Start() { SceneManager.sceneLoaded += SceneShaderFix; }

    private void OnDestroy() { ClearAllAssetBundles(); }

    #endregion

    #region 公开方法

    /// <summary>
    /// 初始化 AssetBundle 文件路径
    /// </summary>
    /// <param name="directoryPath">文件路径</param>
    public void SetAssetBundlePatch(string directoryPath) { _assetBundlePath = directoryPath; }

    public void SetAssetBundlePatch(Type mainClass, string path = "/AssetBundle")
    {
        _assetBundlePath = Directory.GetParent(mainClass.Assembly.Location)?.FullName + path;
    }

    /// <summary>
    /// 获取 AssetBundle 的某个 Texture2D 资源并将其封装成 Sprite 对象返回
    /// </summary>
    /// <param name="assetBundleFileName">AssetBundle 文件名称</param>
    /// <param name="assetName">资源名称</param>
    /// <returns>Sprite 数据</returns>
    [Obsolete("该方法已被弃用，资源加载请使用 GetAsset 方法")]
    public Sprite GetSpriteForTexture2D(string assetBundleFileName, string assetName)
    {
        var asset = GetAsset<Texture2D>(assetBundleFileName, assetName);

        return asset != null ? asset.ToSprite() : null;
    }

    /// <summary>
    /// 获取 AssetBundle 的某个资源
    /// </summary>
    /// <param name="assetBundleFileName">AssetBundle 文件名称</param>
    /// <param name="assetName">资源名称</param>
    /// <typeparam name="T">资源类型</typeparam>
    /// <returns>资源数据</returns>
    public T GetAsset<T>(string assetBundleFileName, string assetName) where T : Object
    {
        return TryGetAssetBundle(assetBundleFileName, out var assetBundle) ?
            assetBundle.LoadAsset<T>(assetName) :
            default;
    }

    /// <summary>
    /// 加载一个 AssetBundle 的 Scene 数据
    /// </summary>
    /// <param name="assetBundleFileName">AssetBundle 文件名称</param>
    /// <param name="sceneName">Scene 名称</param>
    /// <returns>Scene对象</returns>
    [Obsolete("该方法已被弃用，场景相关数据加载请使用 LoadScenesAndNoCache 方法")]
    public void CreateScene(string assetBundleFileName, string sceneName)
    {
        TryGetAssetBundle(assetBundleFileName, out var assetBundle);

        if (assetBundle == null) assetBundleFileName.AssetBundleLoadError("Scene 获取失败");
    }

    /// <summary>
    /// 加载当前文件夹所有的 AssetBundle 的 Scene 数据 (仅限场景)
    /// </summary>
    [Obsolete("该方法已被弃用，场景相关数据加载请使用 LoadScenesAndNoCache 方法")]
    public List<string> CreateAllScene()
    {
        var sceneNames = new List<string>();

        try
        {
            foreach (var file in new DirectoryInfo(_assetBundlePath).GetFiles())
            {
                var assetBundleFileName = file.Name;
                var sceneName = assetBundleFileName.ToUpperInvariant();
                if (_loadAssetBundles.ContainsKey(assetBundleFileName)) continue;

                var assetBundle = AssetBundle.LoadFromFile(file.FullName);
                _loadAssetBundles.Add(assetBundleFileName, assetBundle);
                sceneNames.Add(sceneName);
                assetBundleFileName.AssetBundleLoadInfo();
            }
        }
        catch (System.Exception e)
        {
            e.Error();
        }

        return sceneNames;
    }

    /// <summary>
    /// 加载当前文件夹内的 Spine 数据
    /// </summary>
    public void LoadAvatarSpine()
    {
        try
        {
            StartCoroutine(AsyncLoadSpine());
        }
        catch (System.Exception e)
        {
            e.Error();
        }
    }

    /// <summary>
    /// 加载当前文件夹内的 AssetBundle 的 Scene 数据
    /// 但是不会对 AB 数据进行缓存
    /// </summary>
    public void LoadScenesAndNoCache()
    {
        try
        {
            StartCoroutine(AsyncLoadScene());
        }
        catch (System.Exception e)
        {
            e.Error();
        }
    }

    /// <summary>
    /// 获取一个 AssetBundle 数据并在其上绑定一个 Component 用于访问
    /// </summary>
    /// <param name="assetBundleFileName">AssetBundle 文件名称</param>
    /// <param name="canvasPath">Canvas 预制体组件路径</param>
    /// <typeparam name="T">绑定的 Component 对象</typeparam>
    /// <returns>Component 对象</returns>
    public T LoadUI<T>(string assetBundleFileName, string canvasPath) where T : MonoBehaviour
    {
        if (!TryGetAssetBundle(assetBundleFileName, out var assetBundle)) return default;

        var canvasName = string.Empty;

        if (canvasPath.Contains("/"))
        {
            var cutIndex = canvasPath.IndexOf('/');
            canvasName = canvasPath.Substring(cutIndex + 1);
            canvasPath = canvasPath.Substring(0, cutIndex);
        }

        if (string.IsNullOrEmpty(canvasName))
        {
            return assetBundle.LoadAsset<GameObject>(canvasPath).AddComponent<T>();
        }

        return assetBundle.LoadAsset<GameObject>(canvasPath).transform.Find(canvasName).gameObject.AddComponent<T>();
    }

    /// <summary>
    /// 获取一个 AssetBundle 数据并在其上绑定一个 Component 用于访问
    /// </summary>
    /// <param name="assetBundleFileName">AssetBundle 文件名称</param>
    /// <param name="canvasPath">Canvas 预制体组件路径</param>
    /// <param name="parent">挂载的父对象 (可省略)</param>
    /// <typeparam name="T">绑定的 Component 对象</typeparam>
    /// <returns>Component 对象</returns>
    public T LoadUI<T>(string assetBundleFileName, string canvasPath, Transform parent) where T : MonoBehaviour
    {
        if (!TryGetAssetBundle(assetBundleFileName, out var assetBundle)) return default;

        var canvasName = string.Empty;

        if (canvasPath.Contains("/"))
        {
            var cutIndex = canvasPath.IndexOf('/');
            canvasName = canvasPath.Substring(cutIndex + 1);
            canvasPath = canvasPath.Substring(0, cutIndex);
        }

        try
        {
            if (string.IsNullOrEmpty(canvasName))
            {
                return Instantiate(assetBundle.LoadAsset<GameObject>(canvasPath), parent).AddComponent<T>();
            }

            return Instantiate(
                    assetBundle.LoadAsset<GameObject>(canvasPath).transform.Find(canvasName).gameObject,
                    parent)
                .AddComponent<T>();
        }
        catch (System.Exception e)
        {
            e.Error();
        }

        return default;
    }

    /// <summary>
    /// 获取一个 AssetBundle 数据并在其上绑定一个 Component 用于访问
    /// </summary>
    /// <param name="assetBundleFileName">AssetBundle 文件名称</param>
    /// <param name="canvasPath">Canvas 预制体组件路径</param>
    /// <param name="parent">挂载的父对象 (可省略)</param>
    /// <typeparam name="T">绑定的 Component 对象</typeparam>
    /// <returns>Component 对象</returns>
    [Obsolete("该方法已被弃用，UI数据加载请使用 LoadUI 方法")]
    public T CreateUI<T>(string assetBundleFileName, string canvasPath, Transform parent = null) where T : MonoBehaviour
    {
        if (TryGetAssetBundle(assetBundleFileName, out var assetBundle))
        {
            var canvasName = string.Empty;

            if (canvasPath.Contains("/"))
            {
                var cutIndex = canvasPath.IndexOf('/');
                canvasName = canvasPath.Substring(cutIndex + 1);
                canvasPath = canvasPath.Substring(0, cutIndex);
            }

            var go = string.IsNullOrEmpty(canvasName) ?
                assetBundle.LoadAsset<GameObject>(canvasPath) :
                assetBundle.LoadAsset<GameObject>(canvasPath).transform.Find(canvasName).gameObject;

            var component = go.AddComponent<T>();

            if (parent != null)
            {
                component = Instantiate(go, parent).GetComponent<T>();
            }

            return component;
        }

        assetBundleFileName.AssetBundleLoadError("UI组件绑定失败");
        return null;
    }

    /// <summary>
    /// 移除并释放一个 AssetBundle 资源数据
    /// </summary>
    /// <param name="assetBundleFileName">AssetBundle 文件名称</param>
    public void DestroyAssetBundle(string assetBundleFileName) { RemoveLoadAssetBundle(assetBundleFileName); }

    /// <summary>
    /// 移除并释放一个 AssetBundle 资源数据并同时释放其绑定的 Component 对象
    /// </summary>
    /// <param name="assetBundleFileName">AssetBundle 文件名称</param>
    /// <typeparam name="T">绑定的 Component 对象</typeparam>
    public void DestroyAssetBundle<T>(string assetBundleFileName) where T : MonoBehaviour
    {
        foreach (var go in FindObjectsOfType<T>())
        {
            Destroy(go);
        }

        RemoveLoadAssetBundle(assetBundleFileName);
    }

    /// <summary>
    /// 尝试加载 AssetBundle 数据
    /// </summary>
    /// <param name="assetBundleFileName">AssetBundle 文件名称</param>
    /// <param name="assetBundle">AssetBundle 数据对象</param>
    /// <returns>加载结果</returns>
    public bool TryGetAssetBundle(string assetBundleFileName, out AssetBundle assetBundle)
    {
        if (_loadAssetBundles.TryGetValue(assetBundleFileName, out assetBundle)) return true;

        try
        {
            assetBundle = LoadAssetBundle(assetBundleFileName);
            return assetBundle != default;
        }
        catch (AssetBundleException e)
        {
            e.Error();
            return false;
        }
    }

    /// <summary>
    /// 加载 AssetBundle 数据 (需要先初始化 AssetBundle 文件路径才行)
    /// </summary>
    /// <param name="assetBundleFileName">AssetBundle 文件名称</param>
    /// <exception cref="AssetBundleFileNotFoundException">文件不存在异常</exception>
    /// <returns>AssetBundle 对象</returns>
    public AssetBundle LoadAssetBundle(string assetBundleFileName)
    {
        try
        {
            foreach (var file in new DirectoryInfo(_assetBundlePath).GetFiles())
            {
                if (!assetBundleFileName.Equals(file.Name)) continue;

                var assetBundle = AssetBundle.LoadFromFile(file.FullName);
                _loadAssetBundles.Add(assetBundleFileName, assetBundle);
                assetBundleFileName.AssetBundleLoadInfo();
                return assetBundle;
            }
        }
        catch (System.Exception e)
        {
            e.Error();
            return default;
        }

        throw new AssetBundleFileNotFoundException(assetBundleFileName);
    }

    /// <summary>
    /// 清空所有缓存的 AssetBundle 数据
    /// </summary>
    public void ClearAllAssetBundles() { _loadAssetBundles.Clear(); }

    #endregion

    #region 私有方法

    private IEnumerator AsyncLoadSpine()
    {
        foreach (var file in new DirectoryInfo(_assetBundlePath).GetFiles())
        {
            if (file.FullName.EndsWith(".json"))
            {
                // 加载 SpineConfig 文件
                SpineManager.Inst.LoadSpineConfig(file);
                file.Name.SpineConfigLoadInfo();
                continue;
            }

            // 加载 Spine 文件
            SpineManager.Inst.LoadSpine(AssetBundle.LoadFromFile(file.FullName));
            file.Name.SpineLoadInfo();
            yield return null;
        }
    }

    private IEnumerator AsyncLoadScene()
    {
        foreach (var file in new DirectoryInfo(_assetBundlePath).GetFiles())
        {
            AssetBundle.LoadFromFile(file.FullName);
            file.Name.AssetBundleLoadInfo();
            yield return null;
        }
    }

    private void RemoveLoadAssetBundle(string assetBundleFileName)
    {
        if (_loadAssetBundles.TryGetValue(assetBundleFileName, out var assetBundle))
        {
            assetBundle.Unload(true);
        }

        Destroy(assetBundle);
        _loadAssetBundles.Remove(assetBundleFileName);
    }

    private void SceneShaderFix(Scene scene, LoadSceneMode mode)
    {
        if (mode == LoadSceneMode.Additive) return;

        scene.GetRootGameObjects().InitShader();
    }

    #endregion
}