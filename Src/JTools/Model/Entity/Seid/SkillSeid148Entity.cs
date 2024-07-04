using System;

namespace TierneyJohn.MiChangSheng.JTools.Model.Entity.Seid;

/// <summary>Skill Seid 148 实体类</summary>
[Serializable]
public class SkillSeid148Entity : BaseSeidEntity
{
    #region 字段属性

    public virtual int Target { get; set; }

    public virtual int Value1 { get; set; }

    public virtual string Check { get; set; }

    public virtual int Value2 { get; set; }

    #endregion

    #region 公开方法

    public override JSONObject ToJsonObject()
    {
        var data = JSONObject.Create();
        data.AddField("skillid", Id);
        data.AddField("target", Target);
        data.AddField("value1", Value1);
        data.AddField("panduan", Check);
        data.AddField("value2", Value2);
        return data;
    }

    #endregion
}