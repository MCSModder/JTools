using System;

namespace TierneyJohn.MiChangSheng.JTools.Model.Entity.Seid;

/// <summary>Skill Seid 152 实体类</summary>
[Serializable]
public class SkillSeid152Entity : BaseSeidEntity
{
    #region 字段属性

    public virtual int Target { get; set; }

    public virtual int Value1 { get; set; }

    public virtual int Value2 { get; set; }

    #endregion

    #region 公开方法

    public override JSONObject ToJsonObject()
    {
        var data = JSONObject.Create();
        data.AddField("id", Id);
        data.AddField("target", Target);
        data.AddField("value1", Value1);
        data.AddField("value2", Value2);
        return data;
    }

    #endregion
}