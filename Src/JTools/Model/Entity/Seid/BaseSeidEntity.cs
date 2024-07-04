using System;

namespace TierneyJohn.MiChangSheng.JTools.Model.Entity.Seid;

/// <summary>Seid 数据抽象类</summary>
[Serializable]
public abstract class BaseSeidEntity
{
    #region 字段属性

    /// <summary>Seid 编号</summary>
    public virtual int Id { get; set; }

    #endregion

    #region 公开方法

    public abstract JSONObject ToJsonObject();

    #endregion
}