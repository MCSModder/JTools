using System;
using System.Collections.Generic;
using System.Linq;
using JSONClass;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools.Model.Entity;

/// <summary>NPC 实例称号数据实体类</summary>
[Serializable]
public class NpcTitleEntity
{
    #region 字段属性

    /// <summary>称号编号</summary>
    public virtual int Id { get; set; }

    /// <summary>NPC 类型</summary>
    public virtual int NpcType { get; set; }

    /// <summary>称号名称</summary>
    public virtual string Title { get; set; }

    /// <summary>称号类型</summary>
    public virtual int TitleType { get; set; }

    /// <summary>需求贡献</summary>
    public virtual int GongXian { get; set; }

    /// <summary>称号境界区间</summary>
    public virtual List<int> Levels { get; set; }

    /// <summary>唯一称号</summary>
    public virtual bool Once { get; set; }

    /// <summary>称号级别</summary>
    public virtual int TitleLevel { get; set; }

    /// <summary>最大称号等级</summary>
    public virtual int MaxLevel { get; set; }

    /// <summary>称号特殊行为权重变化</summary>
    public virtual List<(int, int)> ActionChange { get; set; }

    #endregion

    #region 构造方法

    public void Create(NPCChengHaoData data)
    {
        Id = data.id;
        NpcType = data.NPCType;
        Title = data.ChengHao;
        TitleType = data.ChengHaoType;
        GongXian = data.GongXian;
        Levels = data.Level;
        Once = data.IsOnly == 1;
        TitleLevel = data.ChengHaoLv;
        MaxLevel = data.MaxLevel;
        ActionChange = data.Change.Zip(data.ChangeTo, (item1, item2) => (item1, item2)).ToList();
    }

    #endregion

    #region 公开方法

    public JSONObject ToJsonObject()
    {
        var data = JSONObject.Create();
        data.AddField("id", Id);
        data.AddField("NPCType", NpcType);
        data.AddField("ChengHao", Title);
        data.AddField("ChengHaoType", TitleType);
        data.AddField("GongXian", GongXian);
        data.AddField("Level", Levels.ToJsonObject());
        data.AddField("IsOnly", Once ? 1 : 0);
        data.AddField("ChengHaoLv", TitleLevel);
        data.AddField("MaxLevel", MaxLevel);
        data.AddField("Change", ActionChange.Select(item => item.Item1).ToList().ToJsonObject());
        data.AddField("ChangeTo", ActionChange.Select(item => item.Item2).ToList().ToJsonObject());
        return data;
    }

    #endregion
}