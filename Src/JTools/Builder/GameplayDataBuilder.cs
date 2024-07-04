using TierneyJohn.MiChangSheng.JTools.Manager;
using TierneyJohn.MiChangSheng.JTools.Model.Entity;

namespace TierneyJohn.MiChangSheng.JTools.Builder;

/// <summary>
/// 游戏玩法数据构造器
/// </summary>
public class GameplayDataBuilder : BaseBuilder<GameplayEntity>
{
    public override void Build() { Build(DataManager.GameplayData); }

    public override void Load() { DataManager.Inst.gameplayEntities.AddRange(Data); }
}