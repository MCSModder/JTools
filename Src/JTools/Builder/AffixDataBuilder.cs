using TierneyJohn.MiChangSheng.JTools.Manager;
using TierneyJohn.MiChangSheng.JTools.Model.Entity;

namespace TierneyJohn.MiChangSheng.JTools.Builder;

/// <summary>
/// 词缀数据构造器
/// </summary>
public class AffixDataBuilder : BaseBuilder<AffixEntity>
{
    public override void Build() { Build(DataManager.AffixData); }

    public override void Load() { DataManager.Inst.affixEntities.AddRange(Data); }
}