using System;
using System.Collections.Generic;
using JSONClass;
using TierneyJohn.MiChangSheng.JTools.Model.Enum.Buff;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools.Model.Entity;

/// <summary>Buff 数据实体类</summary>
[Serializable]
public class BuffEntity
{
    #region 字段属性

    /// <summary>Buff 编号</summary>
    public virtual int Id { get; set; }

    /// <summary>Buff 名称</summary>
    public virtual string Name { get; set; }

    /// <summary>Buff 图标编号</summary>
    public virtual int BuffIconId { get; set; }

    /// <summary>Buff 释放特效</summary>
    public virtual string BuffEffect { get; set; } = "fx_Summoner_o";

    /// <summary>Buff 词缀</summary>
    public virtual List<int> Affix { get; set; }

    /// <summary>Buff 特性</summary>
    public virtual List<int> Seid { get; set; }

    /// <summary>Buff 类型</summary>
    public virtual BuffType BuffType { get; set; }

    /// <summary>Buff 触发类型</summary>
    public virtual StartTriggerType StartTrigger { get; set; }

    /// <summary>Buff 移除类型</summary>
    public virtual RemoveTriggerType RemoveTrigger { get; set; }

    /// <summary>Buff 叠加类型</summary>
    public virtual OverlayType OverlayType { get; set; }

    /// <summary>Buff 描述</summary>
    public virtual string Desc { get; set; }

    /// <summary>是否隐藏</summary>
    public virtual bool IsHide { get; set; }

    /// <summary>是否只显示一层</summary>
    public virtual bool ShowOnlyOne { get; set; }

    /// <summary>Buff 循环时间</summary>
    public virtual int LoopTime { get; set; } = 1;

    /// <summary>Buff 持续时间</summary>
    public virtual int TotalTime { get; set; } = 1;

    /// <summary>Buff执行脚本</summary>
    public virtual string Script { get; set; } = "Buff";

    #endregion

    #region 构造方法

    public void Create(_BuffJsonData data)
    {
        Id = data.buffid;
        Name = data.name;
        BuffIconId = data.BuffIcon;
        BuffEffect = data.skillEffect;
        Affix = data.Affix;
        Seid = data.seid;
        BuffType = (BuffType)data.bufftype;
        StartTrigger = (StartTriggerType)data.trigger;
        RemoveTrigger = (RemoveTriggerType)data.removeTrigger;
        OverlayType = (OverlayType)data.BuffType;
        Desc = data.descr;
        IsHide = data.isHide == 1;
        ShowOnlyOne = data.ShowOnlyOne == 1;
        LoopTime = data.looptime;
        TotalTime = data.totaltime;
        Script = data.script;
    }

    #endregion

    #region 公开方法

    public JSONObject ToJsonObject()
    {
        var data = JSONObject.Create();
        data.AddField("buffid", Id);
        data.AddField("name", Name);
        data.AddField("BuffIcon", BuffIconId);
        data.AddField("skillEffect", BuffEffect);
        data.AddField("Affix", Affix.ToJsonObject());
        data.AddField("seid", Seid.ToJsonObject());
        data.AddField("bufftype", (int)BuffType);
        data.AddField("trigger", (int)StartTrigger);
        data.AddField("removeTrigger", (int)RemoveTrigger);
        data.AddField("BuffType", (int)OverlayType);
        data.AddField("descr", Desc);
        data.AddField("isHide", IsHide ? 1 : 0);
        data.AddField("ShowOnlyOne", ShowOnlyOne ? 1 : 0);
        data.AddField("looptime", LoopTime);
        data.AddField("totaltime", TotalTime);
        data.AddField("script", Script);
        return data;
    }

    #endregion
}