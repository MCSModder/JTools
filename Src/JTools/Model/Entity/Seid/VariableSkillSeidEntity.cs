using System;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools.Model.Entity.Seid;

/// <summary>可变 Skill Seid 实体类</summary>
[Serializable]
public class VariableSkillSeidEntity : VariableSeidEntity
{
    public override JSONObject ToJsonObject()
    {
        var data = JSONObject.Create();
        data.AddField("skillid", Id);

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
}