using TierneyJohn.MiChangSheng.JTools.Model.Entity;
using TierneyJohn.MiChangSheng.JTools.Model.Enum.Affix;

namespace TierneyJohn.MiChangSheng.JTools.Generator;

/// <summary>词缀数据生成器</summary>
public static class AffixGenerator
{
    public static AffixEntity Generator(int id, string name, AffixType affixType, string desc)
    {
        return new AffixEntity { Id = id, Name = name, AffixType = affixType, Desc = desc };
    }
}