using System;
using System.Collections;
using TierneyJohn.MiChangSheng.JTools.Model.Spine;
using TierneyJohn.MiChangSheng.JTools.Tool;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TierneyJohn.MiChangSheng.JTools.Manager;

/// <summary>
/// CG 管理器
/// </summary>
public class CgManager : MonoBehaviour
{
    #region 字段属性

    public static CgManager Inst;

    private Action _action;

    #endregion

    #region Spine 信息

    /// <summary>
    /// 当前加载的 Spine 名称
    /// </summary>
    public string nowSpineName;

    /// <summary>
    /// 当前加载的 Spine Skin 名称
    /// </summary>
    public string nowSpineSkin;

    /// <summary>
    /// 原始场景名称
    /// </summary>
    public string originSceneName;

    #endregion

    #region Image 信息

    /// <summary>
    /// 静态立绘画布
    /// </summary>
    public Canvas canvas;

    /// <summary>
    /// 当前显示 Image 数据
    /// </summary>
    public Image image;

    #endregion

    #region Unity 事件函数

    private void Awake() { Inst = this; }

    private void Start() { SceneManager.sceneLoaded += SpineSceneLoaded; }

    #endregion

    #region 公开方法

    /// <summary>
    /// 显示动态 CG
    /// </summary>
    /// <param name="spineName">Spine 场景名称</param>
    /// <param name="skinName">Skin 名称(不提供则使用默认皮肤)</param>
    /// <param name="action">事件回调</param>
    public void ShowSpineCg(string spineName, string skinName = null, Action action = null)
    {
        originSceneName ??= SceneManager.GetActiveScene().name;
        nowSpineName = spineName;
        nowSpineSkin = skinName;
        _action ??= action;
        HideCg();
        nowSpineName.LoadScene();
    }

    /// <summary>
    /// 隐藏动态 CG
    /// </summary>
    /// <param name="action">事件回调</param>
    public void HideSpineCg(Action action = null)
    {
        originSceneName.LoadScene();
        action?.Invoke();
        originSceneName = null;
        nowSpineName = null;
        nowSpineSkin = null;
    }

    /// <summary>
    /// 显示静态 CG
    /// </summary>
    /// <param name="path">cg 文件路径</param>
    /// <param name="action">事件回调</param>
    public void ShowCg(string path, Action action = null) => ShowCg(ResManager.inst.LoadSprite(path), action);

    /// <summary>
    /// 显示静态 CG
    /// </summary>
    /// <param name="sprite">cg 图片数据</param>
    /// <param name="action">事件回调</param>
    public void ShowCg(Sprite sprite, Action action = null)
    {
        InitCanvas();
        image.sprite = sprite;
        image.gameObject.SetActive(true);
        action?.Invoke();
    }

    /// <summary>
    /// 隐藏静态 CG
    /// </summary>
    /// <param name="action">事件回调</param>
    public void HideCg(Action action = null)
    {
        if (image != null) image.gameObject.SetActive(false);
        action?.Invoke();
    }

    #endregion

    #region 加载方法

    /// <summary>
    /// 动态 CG 场景处理
    /// </summary>
    /// <param name="scene">场景对象</param>
    /// <param name="mode">场景加载模式</param>
    private void SpineSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (LoadSceneMode.Additive == mode) return;

        if (string.IsNullOrEmpty(nowSpineName) || !scene.name.Equals(nowSpineName)) return;

        var go = new GameObject("manager");
        var spine = go.AddComponent<SpineCg>();
        SceneManager.MoveGameObjectToScene(go, scene);

        if (!string.IsNullOrEmpty(nowSpineSkin)) spine.SetSkin(nowSpineSkin);
        StartCoroutine(AfterAction());
    }

    /// <summary>
    /// 初始化 Canvas 配置
    /// </summary>
    private void InitCanvas()
    {
        if (!gameObject.GetComponent<Canvas>())
        {
            canvas = gameObject.AddComponent<Canvas>();
            canvas.sortingOrder = 20;
            canvas.planeDistance = 100;
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        }

        if (transform.GetComponentInChildren<Image>()) return;

        var imageObject = new GameObject("CG Mask");
        imageObject.transform.SetParent(transform);
        image = imageObject.AddComponent<Image>();

        var imageRect = image.rectTransform;
        imageRect.position = Vector3.zero;
        imageRect.localScale = Vector3.one;
        imageRect.anchorMin = Vector2.zero;
        imageRect.anchorMax = Vector2.one;
        imageRect.offsetMin = Vector2.zero;
        imageRect.offsetMax = Vector2.zero;

        image.gameObject.SetActive(false);
    }

    private IEnumerator AfterAction()
    {
        yield return new WaitForSeconds(0.6f);
        _action?.Invoke();
        _action = null;
    }

    #endregion
}