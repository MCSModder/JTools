using System;
using JSONClass;

namespace TierneyJohn.MiChangSheng.JTools.Model.Entity;

/// <summary>通用 NPC 行为数据实体类</summary>
[Serializable]
public class NpcActionEntity
{
    #region 字段属性

    /// <summary>行为事件编号</summary>
    public virtual int Id { get; set; }

    /// <summary>行为事件权重</summary>
    public virtual int Weight { get; set; }

    /// <summary>行为前置判定</summary>
    public virtual int PanDing { get; set; }

    /// <summary>宁州大地图位置移动</summary>
    public virtual int AllMapIndex { get; set; }

    /// <summary>副本特定位置移动</summary>
    public virtual int FuBen { get; set; }

    /// <summary>NPC 特定三级场景移动</summary>
    public virtual string Scene { get; set; }

    /// <summary>是否为任务特定行为</summary>
    public virtual bool IsTask { get; set; }

    /// <summary>行为相关对话 已被官方废弃</summary>
    public virtual string Talk { get; set; }

    #endregion

    #region 构造方法

    public void Create(NPCActionDate data)
    {
        Id = data.id;
        Weight = data.QuanZhong;
        PanDing = data.PanDing;
        AllMapIndex = data.AllMap;
        FuBen = data.FuBen;
        Scene = data.ThreeSence;
        IsTask = data.IsTask == 1;
        Talk = data.GuanLianTalk;
    }

    #endregion

    #region 公开方法

    public JSONObject ToJsonObject()
    {
        var data = JSONObject.Create();
        data.SetField("id", Id);
        data.SetField("QuanZhong", Weight);
        data.SetField("PanDing", PanDing);
        data.SetField("AllMap", AllMapIndex);
        data.SetField("FuBen", FuBen);
        data.SetField("ThreeSence", Scene);
        data.SetField("IsTask", IsTask);
        data.SetField("GuanLianTalk", Talk);
        return data;
    }

    #endregion
}