using System;

namespace TierneyJohn.MiChangSheng.JTools.Model.Entity.Seid;

/// <summary>StaticSkill Seid 9 实体类</summary>
[Serializable]
public class StaticSkillSeid9Entity : BaseSeidEntity
{
    #region 字段属性

    public virtual string Spine { get; set; }

    public virtual string OnMoveEnter { get; set; }

    public virtual string OnMoveExit { get; set; }

    public virtual string OnLoopMoveEnter { get; set; }

    public virtual string OnLoopMoveExit { get; set; }

    #endregion

    #region 公开方法

    public override JSONObject ToJsonObject()
    {
        var data = JSONObject.Create();
        data.AddField("skillid", Id);
        data.AddField("Spine", Spine);
        data.AddField("OnMoveEnter", OnMoveEnter);
        data.AddField("OnMoveExit", OnMoveExit);
        data.AddField("OnLoopMoveEnter", OnLoopMoveEnter);
        data.AddField("OnLoopMoveExit", OnLoopMoveExit);
        return data;
    }

    #endregion
}