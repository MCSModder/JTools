using TierneyJohn.MiChangSheng.JTools.Manager;
using TierneyJohn.MiChangSheng.JTools.Model.Entity;

namespace TierneyJohn.MiChangSheng.JTools.Builder;

/// <summary>
/// NPC 实例数据构造器
/// </summary>
public class NpcImportantDataBuilder : BaseBuilder<NpcImportantEntity>
{
    public override void Build() { Build(DataManager.NpcImportantData); }

    public override void Load() { DataManager.Inst.npcImportantEntities.AddRange(Data); }
}