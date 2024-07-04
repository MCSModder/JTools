using System;
using System.Collections.Generic;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools.Model.Entity.Seid;

/// <summary>可变 Seid 实体类</summary>
[Serializable]
public class VariableSeidEntity : BaseSeidEntity
{
    #region 字段属性

    public virtual int IntValue1 { get; set; }

    public virtual List<int> ListValue1 { get; set; }

    public virtual int IntValue2 { get; set; }

    public virtual List<int> ListValue2 { get; set; }

    public virtual int IntValue3 { get; set; }

    public virtual List<int> ListValue3 { get; set; }

    public virtual int IntValue4 { get; set; }

    public virtual List<int> ListValue4 { get; set; }

    #endregion

    #region 公开方法

    public override JSONObject ToJsonObject()
    {
        var data = JSONObject.Create();
        data.AddField("id", Id);

        if (ListValue1 == null)
            data.AddField("value1", IntValue1);
        else
            data.AddField("value1", ListValue1.ToJsonObject());

        if (ListValue2 == null)
            data.AddField("value2", IntValue2);
        else
            data.AddField("value2", ListValue2.ToJsonObject());

        if (ListValue3 == null)
            data.AddField("value3", IntValue3);
        else
            data.AddField("value3", ListValue3.ToJsonObject());

        if (ListValue4 == null)
            data.AddField("value4", IntValue4);
        else
            data.AddField("value4", ListValue4.ToJsonObject());

        return data;
    }

    #endregion
}