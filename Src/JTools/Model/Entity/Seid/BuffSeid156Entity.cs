using System;

namespace TierneyJohn.MiChangSheng.JTools.Model.Entity.Seid;

/// <summary>Buff Seid 156 实体类</summary>
[Serializable]
public class BuffSeid156Entity : BaseSeidEntity
{
    #region 字段属性

    public virtual int Target { get; set; }

    public virtual int Value1 { get; set; }

    #endregion

    #region 公开方法

    public override JSONObject ToJsonObject()
    {
        var data = JSONObject.Create();
        data.AddField("id", Id);
        data.AddField("target", Target);
        data.AddField("value1", Value1);
        return data;
    }

    #endregion
}