using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Spine.Unity;
using TierneyJohn.MiChangSheng.JTools.Model.Spine;
using TierneyJohn.MiChangSheng.JTools.Util;
using UnityEngine;

namespace TierneyJohn.MiChangSheng.JTools.Manager;

/// <summary>
/// Spine 管理器
/// </summary>
public class SpineManager : MonoBehaviour
{
    #region 字段/熟悉

    public static SpineManager Inst;

    /// <summary>
    /// Spine 元素字典
    /// </summary>
    private readonly Dictionary<string, GameObject> _spines = [];

    /// <summary>
    /// Spine 皮肤映射字典
    /// </summary>
    private readonly Dictionary<string, string> _skins = [];

    /// <summary>
    /// Spine 配置文件字典
    /// </summary>
    private readonly Dictionary<string, List<SpineConfig>> _configs = [];

    private const string SpineSkins = "JTools_Save/SpineSkins.dat";

    #endregion

    #region Unity 事件函数

    private void Awake() { Inst = this; }

    private void Start()
    {
        ArchiveManager.Inst.OnSaved += SaveSkins;
        ArchiveManager.Inst.OnLoaded += LoadSkins;
    }

    #endregion

    #region 核心加载方法

    /// <summary>
    /// 加载预处理 SpineConfig 数据
    /// </summary>
    /// <param name="file">SpineConfig 文件信息</param>
    public void LoadSpineConfig(FileInfo file)
    {
        var jsonString = File.ReadAllText(file.FullName);
        var spineConfig = JsonConvert.DeserializeObject<List<SpineConfig>>(jsonString);
        var key = file.Name.Substring(0, file.Name.IndexOf('.'));
        _configs[key] = spineConfig;
    }

    /// <summary>
    /// 加载预处理 Spine 数据
    /// </summary>
    /// <param name="assetBundle">AssetBundle 对象</param>
    public void LoadSpine(AssetBundle assetBundle)
    {
        var key = assetBundle.name;
        var spine = assetBundle.LoadAsset<GameObject>(key);

        // canvas 修正
        spine.transform.GetChild(0).localScale = Vector3.one;
        // 默认 Skin 读取
        var skeletonGraphic = GetSkeletonGraphic(spine.transform).GetComponent<SkeletonGraphic>();
        var skin = skeletonGraphic.initialSkinName;

        // 保存数据
        _spines[key] = spine;
        _skins[key] = skin;
    }

    #endregion

    #region 公开方法

    /// <summary>
    /// 验证是否存在 Spine 数据
    /// </summary>
    /// <param name="id">角色编号</param>
    /// <returns>验证结果</returns>
    public bool CheckSpine(int id) { return _spines.ContainsKey(GetKey(id)); }

    /// <summary>
    /// 获取指定 Spine 的 Skin 名称
    /// </summary>
    /// <param name="id">角色编号</param>
    /// <returns>皮肤名称</returns>
    public string GetSpineSkin(int id)
    {
        var key = GetKey(id);
        return _skins.TryGetValue(key, out var skin) ? skin : string.Empty;
    }

    /// <summary>
    /// 变更指定 Spine 的 Skin
    /// </summary>
    /// <param name="id">角色编号</param>
    /// <param name="skin">皮肤名称</param>
    public void ChangeSpineSkin(int id, string skin)
    {
        var key = GetKey(id);
        if (!_skins.ContainsKey(key)) return;
        _skins[key] = skin;
    }

    /// <summary>
    /// 创建并初始化 Spine 数据
    /// </summary>
    /// <param name="id">角色编号</param>
    /// <param name="parent">挂载父对象</param>
    /// <param name="clone">参照对象</param>
    /// <param name="configMode">配置模式</param>
    /// <param name="init">额外的初始化函数</param>
    public void CreateSpine(
        int id,
        Transform parent,
        Transform clone,
        SpineConfigMode configMode,
        Action<Transform> init = null
    )
    {
        // 初始化 Spines 配置
        var spines = InitSpines(parent, clone);
        CloseAllSpines(spines);

        // Spine 数据验证
        var key = GetKey(id);

        if (!_spines.ContainsKey(key))
        {
            // 没有对应的 Spine 数据，恢复配置
            clone.gameObject.SetActive(true);
            return;
        }

        var spine = spines.Find($"{key}(Clone)");

        if (spine == null)
        {
            // 初始化 Spine 数据
            spine = Instantiate(_spines[key], spines, false).transform;
            init?.Invoke(spine);
        }

        // 执行配置
        RefreshSkin(key, spine);
        RefreshConfig(key, spine, configMode);
        spine.gameObject.SetActive(true);
        clone.gameObject.SetActive(false);
    }

    public Transform InitSpines(Transform parent, Transform clone)
    {
        var spines = parent.Find("Spines(Clone)");

        if (spines != null) return spines;

        // 初始化 Spines
        spines = Instantiate(new GameObject("Spines"), parent, false).transform;
        spines.localPosition = clone.localPosition;
        spines.localRotation = clone.localRotation;
        spines.localScale = clone.localScale;

        return spines;
    }

    public void CloseAllSpines(Transform spines)
    {
        for (var index = 0; index < spines.childCount; index++)
        {
            spines.GetChild(index).gameObject.SetActive(false);
        }
    }

    public void RefreshSkin(string key, Transform spine)
    {
        var skin = _skins[key];
        var skeletonGraphic = GetSkeletonGraphic(spine).GetComponent<SkeletonGraphic>();
        skeletonGraphic.initialSkinName = skin;
        skeletonGraphic.Skeleton.SetSkin(skin);
        skeletonGraphic.Initialize(true);
    }

    public void RefreshConfig(string key, Transform spine, SpineConfigMode configMode)
    {
        if (!_configs.TryGetValue(key, out var configs)) return;

        var skin = _skins[key];
        var config = configs.Find(conf => conf.skin.Equals(skin));

        if (config == null)
        {
            config = configs.Find(conf => conf.skin.Equals("All"));
            if (config == null) return;
        }

        // 配置数据初始化
        if (!_configs[key].Any(conf => conf.skin.Equals("JTools")))
        {
            // 不存在配置文件
            var conf = new SpineConfig { skin = "JTools" };
            _configs[key].Add(conf);
        }

        var jToolsConfig = _configs[key].Find(conf => conf.skin.Equals("JTools"));

        switch (configMode)
        {
            case SpineConfigMode.SayDialog:
                if (jToolsConfig.sayDialog == null)
                {
                    jToolsConfig.sayDialog = GetSpineConfigItem(spine);
                }
                else
                {
                    ResetSpine(spine, jToolsConfig.sayDialog);
                }

                SpineOffset(spine, config.sayDialog);
                break;

            case SpineConfigMode.Pop:
                if (jToolsConfig.pop == null)
                {
                    jToolsConfig.pop = GetSpineConfigItem(spine);
                }
                else
                {
                    ResetSpine(spine, jToolsConfig.pop);
                }

                SpineOffset(spine, config.pop);
                break;

            case SpineConfigMode.Info:
                if (jToolsConfig.info == null)
                {
                    jToolsConfig.info = GetSpineConfigItem(spine);
                }
                else
                {
                    ResetSpine(spine, jToolsConfig.info);
                }

                SpineOffset(spine, config.info);
                break;

            case SpineConfigMode.Shop:
                if (jToolsConfig.shop == null)
                {
                    jToolsConfig.shop = GetSpineConfigItem(spine);
                }
                else
                {
                    ResetSpine(spine, jToolsConfig.shop);
                }

                SpineOffset(spine, config.shop);
                break;

            case SpineConfigMode.Auction:
                if (jToolsConfig.auction == null)
                {
                    jToolsConfig.auction = GetSpineConfigItem(spine);
                }
                else
                {
                    ResetSpine(spine, jToolsConfig.auction);
                }

                SpineOffset(spine, config.auction);
                break;

            case SpineConfigMode.Left:
                if (jToolsConfig.left == null)
                {
                    jToolsConfig.left = GetSpineConfigItem(spine);
                }
                else
                {
                    ResetSpine(spine, jToolsConfig.left);
                }

                SpineOffset(spine, config.left);
                break;

            case SpineConfigMode.Tao:
                if (jToolsConfig.tao == null)
                {
                    jToolsConfig.tao = GetSpineConfigItem(spine);
                }
                else
                {
                    ResetSpine(spine, jToolsConfig.tao);
                }

                SpineOffset(spine, config.tao);
                break;

            case SpineConfigMode.FightPop:
                if (jToolsConfig.fightPop == null)
                {
                    jToolsConfig.fightPop = GetSpineConfigItem(spine);
                }
                else
                {
                    ResetSpine(spine, jToolsConfig.fightPop);
                }

                SpineOffset(spine, config.fightPop);
                break;

            case SpineConfigMode.Fight:
                if (jToolsConfig.fight == null)
                {
                    jToolsConfig.fight = GetSpineConfigItem(spine);
                }
                else
                {
                    ResetSpine(spine, jToolsConfig.fight);
                }

                SpineOffset(spine, config.fight);
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(configMode), configMode, null);
        }
    }

    /// <summary>
    /// 获取 Spine 数据内的 SkeletonGraphic 数据
    /// </summary>
    /// <param name="spine">Spine 数据</param>
    /// <returns>SkeletonGraphic Transform</returns>
    public Transform GetSkeletonGraphic(Transform spine)
    {
        var child = spine.GetChild(0).GetChild(0);
        return child.name.Equals("AvatarMask") ? child.GetChild(0) : child;
    }

    #endregion

    #region 私有工具方法

    private string GetKey(int id)
    {
        var key = NPCEx.NPCIDToOld(id);
        return key.ToString();
    }

    private SpineConfigItem GetSpineConfigItem(Transform spine)
    {
        return new SpineConfigItem
        {
            offsetX = GetSkeletonGraphic(spine).localPosition.x,
            offsetY = GetSkeletonGraphic(spine).localPosition.y,
            scale = GetSkeletonGraphic(spine).localScale.x
        };
    }

    private void ResetSpine(Transform spine, SpineConfigItem config)
    {
        GetSkeletonGraphic(spine).localPosition = new Vector3(config.offsetX, config.offsetY);
        GetSkeletonGraphic(spine).localScale = new Vector3(config.scale, config.scale);
    }

    private void SpineOffset(Transform spine, SpineConfigItem config)
    {
        GetSkeletonGraphic(spine).localPosition += new Vector3(config.offsetX, config.offsetY);
        GetSkeletonGraphic(spine).localScale *= config.scale;
    }

    private void SaveSkins()
    {
        if (_skins == null || !_skins.Any()) return;
        SpineSkins.Archive(_skins);
    }

    private void LoadSkins()
    {
        if (!SpineSkins.TryGetArchive(out Dictionary<string, string> data)) return;
        if (data == null || !data.Any()) return;

        foreach (var item in data)
        {
            _skins[item.Key] = item.Value;
        }
    }

    #endregion
}

public enum SpineConfigMode
{
    SayDialog,
    Pop,
    Info,
    Shop,
    Auction,
    Left,
    Tao,
    FightPop,
    Fight
}