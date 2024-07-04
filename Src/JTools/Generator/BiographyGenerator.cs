using TierneyJohn.MiChangSheng.JTools.Model.Entity;

namespace TierneyJohn.MiChangSheng.JTools.Generator;

/// <summary>生平数据生成器</summary>
public static class BiographyGenerator
{
    public static BiographyEntity Generator(string id, string info, int priority = 1, bool once = false)
    {
        return new BiographyEntity { Id = id, Info = info, Priority = priority, Once = once };
    }
}