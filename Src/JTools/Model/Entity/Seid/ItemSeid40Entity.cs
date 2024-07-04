using System;

namespace TierneyJohn.MiChangSheng.JTools.Model.Entity.Seid;

/// <summary>Item Seid 40 实体类</summary>
[Serializable]
public class ItemSeid40Entity : BaseSeidEntity
{
    #region 字段属性

    public virtual string Flowchart { get; set; }

    public virtual string Block { get; set; }

    #endregion

    #region 公开方法

    public override JSONObject ToJsonObject()
    {
        var data = JSONObject.Create();
        data.AddField("id", Id);
        data.AddField("flowchart", Flowchart);
        data.AddField("block", Block);
        return data;
    }

    #endregion
}