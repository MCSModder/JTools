using System.Collections.Generic;
using TierneyJohn.MiChangSheng.JTools.Model.Entity.Seid;

namespace TierneyJohn.MiChangSheng.JTools.Generator;

/// <summary>Seid 数据生成器</summary>
public static class SeidGenerator
{
    public static VariableSeidEntity SingleGenerator(int id, int value)
    {
        return new VariableSeidEntity { Id = id, IntValue1 = value };
    }

    public static VariableSeidEntity SingleGenerator(int id, List<int> value)
    {
        return new VariableSeidEntity { Id = id, ListValue1 = value };
    }

    public static VariableSeidEntity DoubleGenerator(int id, int value1, int value2)
    {
        return new VariableSeidEntity { Id = id, IntValue1 = value1, IntValue2 = value2 };
    }

    public static VariableSeidEntity DoubleGenerator(int id, List<int> value1, List<int> value2)
    {
        return new VariableSeidEntity { Id = id, ListValue1 = value1, ListValue2 = value2 };
    }

    public static VariableSeidEntity DoubleGenerator(int id, int value1, List<int> value2)
    {
        return new VariableSeidEntity { Id = id, IntValue1 = value1, ListValue2 = value2 };
    }

    public static VariableSeidEntity ThreeGenerator(int id, int value1, int value2, int value3)
    {
        return new VariableSeidEntity { Id = id, IntValue1 = value1, IntValue2 = value2, IntValue3 = value3 };
    }

    public static VariableSeidEntity FourGenerator(int id, int value1, int value2, int value3, int value4)
    {
        return new VariableSeidEntity
        {
            Id = id,
            IntValue1 = value1,
            IntValue2 = value2,
            IntValue3 = value3,
            IntValue4 = value4
        };
    }

    public static VariableSeidEntity FourGenerator(int id, int value1, int value2, List<int> value3, List<int> value4)
    {
        return new VariableSeidEntity
        {
            Id = id,
            IntValue1 = value1,
            IntValue2 = value2,
            ListValue3 = value3,
            ListValue4 = value4
        };
    }

    public static VariableSeidEntity FourGenerator(
        int id,
        List<int> value1,
        List<int> value2,
        List<int> value3,
        List<int> value4
    )
    {
        return new VariableSeidEntity
        {
            Id = id,
            ListValue1 = value1,
            ListValue2 = value2,
            ListValue3 = value3,
            ListValue4 = value4
        };
    }
}