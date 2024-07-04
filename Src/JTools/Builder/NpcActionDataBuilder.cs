using TierneyJohn.MiChangSheng.JTools.Manager;
using TierneyJohn.MiChangSheng.JTools.Model.Entity;

namespace TierneyJohn.MiChangSheng.JTools.Builder;

/// <summary>
/// NPC 行为数据构造器
/// </summary>
public class NpcActionDataBuilder : BaseBuilder<NpcActionEntity>
{
    public override void Build() { Build(DataManager.NpcActionData); }

    public override void Load() { DataManager.Inst.npcActionEntities.AddRange(Data); }
}