using System.Collections.Generic;
using System.Linq;
using TierneyJohn.MiChangSheng.JTools.Model.NpcPop;
using TierneyJohn.MiChangSheng.JTools.Util;
using UnityEngine;
using UnityEngine.UI;

namespace TierneyJohn.MiChangSheng.JTools.Manager;

public class NpcPopManager : MonoBehaviour
{
    #region 字段/属性

    public static NpcPopManager Inst;

    /// <summary>
    /// NpcPopConfig 元素字典
    /// </summary>
    private readonly Dictionary<int, NpcPopConfig> _npcPopConfigs = [];

    /// <summary>
    /// NpcPopConfig 配置文件字典
    /// </summary>
    private readonly Dictionary<int, int> _npcActivatedConfigs = [];

    private const string NpcPopConfigs = "JTools_Save/NpcPopConfigs.dat";

    #endregion

    #region Unity 事件函数

    private void Awake() { Inst = this; }

    private void Start()
    {
        ArchiveManager.Inst.OnSaved += SaveConfigs;
        ArchiveManager.Inst.OnLoaded += LoadConfigs;
    }

    #endregion

    #region 公开方法

    /// <summary>
    /// 注册配置文件
    /// </summary>
    /// <param name="config">Npc 交互界面配置文件</param>
    public void RegisterConfig(NpcPopConfig config)
    {
        if (_npcPopConfigs.ContainsKey(config.id)) $"注册 NpcPopConfig 数据时,配置文件编号 [{config.id}] 发生冲突，执行覆盖操作".Warn();
        _npcPopConfigs[config.id] = config;
        var activatedConfig = config.config.Find(item => item.activated);
        if (activatedConfig == null) return;
        _npcActivatedConfigs[config.id] = activatedConfig.configId;
    }

    /// <summary>
    /// 修改激活配置
    /// </summary>
    /// <param name="npcId">Npc 编号</param>
    /// <param name="configId">配置文件编号</param>
    public void ChangeActivated(int npcId, int configId)
    {
        if (!_npcPopConfigs.ContainsKey(npcId)) return;
        _npcActivatedConfigs[npcId] = configId;
    }

    public void ChangePopButton(UINPCJiaoHuPop pop)
    {
        if (UINPCJiaoHu.Inst == null || UINPCJiaoHu.Inst.NowJiaoHuNPC == null) return;

        var id = NPCEx.NPCIDToOld(UINPCJiaoHu.Inst.NowJiaoHuNPC.ID);
        if (!_npcPopConfigs.TryGetValue(id, out var config)) return;

        RefreshConfig(config);

        var configItem = config.config.Find(item => item.activated);
        if (configItem == null) return;

        ChangePopButton(pop, configItem);
    }

    #endregion

    #region 私有方法

    private void SaveConfigs()
    {
        if (_npcActivatedConfigs == null || !_npcActivatedConfigs.Any()) return;
        NpcPopConfigs.Archive(_npcActivatedConfigs);
    }

    private void LoadConfigs()
    {
        if (!NpcPopConfigs.TryGetArchive(out Dictionary<int, int> data)) return;
        if (data == null || !data.Any()) return;

        foreach (var item in data)
        {
            _npcActivatedConfigs[item.Key] = item.Value;
        }
    }

    private void RefreshConfig(NpcPopConfig config)
    {
        if (!_npcActivatedConfigs.TryGetValue(config.id, out var configId)) return;

        foreach (var configItem in config.config)
        {
            if (configItem.configId.Equals(configId))
            {
                configItem.activated = true;
                continue;
            }

            configItem.activated = false;
        }
    }

    private void ChangePopButton(UINPCJiaoHuPop pop, NpcPopConfigItem config)
    {
        if (config.交谈) UsedButton(pop.JiaoTanBtn);
        else HideButton(pop.JiaoTanBtn);

        if (config.论道) UsedButton(pop.LunDaoBtn);
        else HideButton(pop.LunDaoBtn);

        if (config.交易) UsedButton(pop.JiaoYiBtn);
        else HideButton(pop.JiaoYiBtn);

        if (config.切磋) HideButton(pop.QieCuoBtn);
        else HideButton(pop.QieCuoBtn);

        if (config.赠礼) HideButton(pop.ZengLiBtn);
        else HideButton(pop.ZengLiBtn);

        if (config.请教) UsedButton(pop.QingJiaoBtn);
        else HideButton(pop.QingJiaoBtn);

        if (config.查看) UsedButton(pop.ChaKanBtn);
        else HideButton(pop.ChaKanBtn);

        if (config.探查) UsedRedButton(pop.TanChaBtn);
        else HideButton(pop.TanChaBtn);

        if (config.威胁) UsedRedButton(pop.SuoQuBtn);
        else HideButton(pop.SuoQuBtn);

        if (config.截杀) UsedRedButton(pop.JieShaBtn);
        else HideButton(pop.JieShaBtn);
    }

    private void UsedButton(Button button)
    {
        UINPCJiaoHu.Inst.SetBtnNormalColor(button.transform);
        button.enabled = true;
    }

    private void UsedRedButton(Button button)
    {
        UINPCJiaoHu.Inst.SetBtnDangerColor(button.transform);
        button.enabled = true;
    }

    private void HideButton(Button button)
    {
        UINPCJiaoHu.Inst.SetBtnGreyColor(button.transform);
        button.enabled = false;
    }

    #endregion
}