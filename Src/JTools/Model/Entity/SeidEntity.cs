using System;
using System.Collections.Generic;
using TierneyJohn.MiChangSheng.JTools.Model.Entity.Seid;

namespace TierneyJohn.MiChangSheng.JTools.Model.Entity;

/// <summary>Seid 数据实体类</summary>
[Serializable]
public class SeidEntity
{
    #region 字段属性

    public virtual Dictionary<int, List<BaseSeidEntity>> BuffSeidDictionary { get; set; } = [];

    public virtual Dictionary<int, List<BaseSeidEntity>> EquipSeidDictionary { get; set; } = [];

    public virtual Dictionary<int, List<BaseSeidEntity>> ItemSeidDictionary { get; set; } = [];

    public virtual Dictionary<int, List<BaseSeidEntity>> SkillSeidDictionary { get; set; } = [];

    public virtual Dictionary<int, List<BaseSeidEntity>> StaticSkillSeidDictionary { get; set; } = [];

    #endregion
}