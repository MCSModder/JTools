using System;
using System.Collections.Generic;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools.Model.Entity.Seid;

/// <summary>StaticSkill Seid 1 实体类</summary>
[Serializable]
public class StaticSkillSeid1Entity : BaseSeidEntity
{
    #region 字段属性

    public virtual int Target { get; set; }

    public virtual List<int> Value1 { get; set; }

    public virtual List<int> Value2 { get; set; }

    #endregion

    #region 公开方法

    public override JSONObject ToJsonObject()
    {
        var data = JSONObject.Create();
        data.AddField("skillid", Id);
        data.AddField("target", Target);
        data.AddField("value1", Value1.ToJsonObject());
        data.AddField("value2", Value2.ToJsonObject());
        return data;
    }

    #endregion
}