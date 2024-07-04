using System.Collections.Generic;
using TierneyJohn.MiChangSheng.JTools.Model.Entity.Seid;

namespace TierneyJohn.MiChangSheng.JTools.Generator;

/// <summary>Skill Seid 数据生成器</summary>
public static class SkillSeidGenerator
{
    public static VariableSkillSeidEntity SingleGenerator(int id, int value)
    {
        return new VariableSkillSeidEntity { Id = id, IntValue1 = value };
    }

    public static VariableSkillSeidEntity DoubleGenerator(int id, int value1, int value2)
    {
        return new VariableSkillSeidEntity { Id = id, IntValue1 = value1, IntValue2 = value2 };
    }

    public static VariableSkillSeidEntity DoubleGenerator(int id, List<int> value1, List<int> value2)
    {
        return new VariableSkillSeidEntity { Id = id, ListValue1 = value1, ListValue2 = value2 };
    }

    public static VariableSkillSeidEntity ThreeGenerator(int id, int value1, int value2, int value3)
    {
        return new VariableSkillSeidEntity { Id = id, IntValue1 = value1, IntValue2 = value2, IntValue3 = value3 };
    }

    public static VariableSkillSeidEntity ThreeGenerator(int id, List<int> value1, List<int> value2, List<int> value3)
    {
        return new VariableSkillSeidEntity { Id = id, ListValue1 = value1, ListValue2 = value2, ListValue3 = value3 };
    }

    public static VariableSkillSeidEntity ThreeGenerator(int id, int value1, List<int> value2, List<int> value3)
    {
        return new VariableSkillSeidEntity { Id = id, IntValue1 = value1, ListValue2 = value2, ListValue3 = value3 };
    }

    public static VariableSkillSeidEntity FourGenerator(int id, int value1, int value2, int value3, int value4)
    {
        return new VariableSkillSeidEntity
        {
            Id = id,
            IntValue1 = value1,
            IntValue2 = value2,
            IntValue3 = value3,
            IntValue4 = value4
        };
    }
}