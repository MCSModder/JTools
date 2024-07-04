using TierneyJohn.MiChangSheng.JTools.Manager;
using TierneyJohn.MiChangSheng.JTools.Model.Entity;

namespace TierneyJohn.MiChangSheng.JTools.Builder;

/// <summary>
/// Buff数据构造器
/// </summary>
public class BuffDataBuilder : BaseBuilder<BuffEntity>
{
    public override void Build() { Build(DataManager.BuffData); }

    public override void Load() { DataManager.Inst.buffEntities.AddRange(Data); }
}