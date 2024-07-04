using TierneyJohn.MiChangSheng.JTools.Manager;
using TierneyJohn.MiChangSheng.JTools.Model.Entity;

namespace TierneyJohn.MiChangSheng.JTools.Builder;

/// <summary>
/// 背包数据构造器
/// </summary>
public class BackpackDataBuilder : BaseBuilder<BackpackEntity>
{
    public override void Build() { Build(DataManager.BackpackData); }

    public override void Load() { DataManager.Inst.backpackEntities.AddRange(Data); }
}