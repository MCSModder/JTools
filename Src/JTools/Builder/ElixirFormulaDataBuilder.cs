using TierneyJohn.MiChangSheng.JTools.Manager;
using TierneyJohn.MiChangSheng.JTools.Model.Entity;

namespace TierneyJohn.MiChangSheng.JTools.Builder;

/// <summary>
/// 丹方数据构造器
/// </summary>
public class ElixirFormulaDataBuilder : BaseBuilder<ElixirFormulaEntity>
{
    public override void Build() { Build(DataManager.ElixirFormulaData); }

    public override void Load() { DataManager.Inst.elixirFormulaEntities.AddRange(Data); }
}