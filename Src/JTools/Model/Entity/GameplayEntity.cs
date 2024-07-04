using System;

namespace TierneyJohn.MiChangSheng.JTools.Model.Entity;

/// <summary>游戏玩法数据实体类</summary>
[Serializable]
public class GameplayEntity
{
    #region 字段属性

    /// <summary>玩法编号</summary>
    public virtual int Id { get; set; }

    /// <summary>子序列排序</summary>
    public virtual int Index { get; set; }

    /// <summary>玩法名称</summary>
    public virtual string Name { get; set; }

    /// <summary>玩法说明</summary>
    public virtual string Desc { get; set; }

    /// <summary>玩法所属 (默认为 玩法说明)</summary>
    public virtual string Title { get; set; } = "玩法说明";

    /// <summary>玩法所属编号 (默认为 506)</summary>
    public virtual int TitleId { get; set; } = 506;

    #endregion
}