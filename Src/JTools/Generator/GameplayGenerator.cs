using TierneyJohn.MiChangSheng.JTools.Model.Entity;

namespace TierneyJohn.MiChangSheng.JTools.Generator;

/// <summary>游戏玩法数据生成器</summary>
public static class GameplayGenerator
{
    public static GameplayEntity Generator(int id, int index, string name, string desc)
    {
        return new GameplayEntity { Id = id, Index = index, Name = name, Desc = desc };
    }
}