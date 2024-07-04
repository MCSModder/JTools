using TierneyJohn.MiChangSheng.JTools.Manager;
using TierneyJohn.MiChangSheng.JTools.Model.Entity;

namespace TierneyJohn.MiChangSheng.JTools.Builder;

/// <summary>
/// NPC 称号数据构造器
/// </summary>
public class NpcTitleDataBuilder : BaseBuilder<NpcTitleEntity>
{
    public override void Build() { Build(DataManager.NpcTitleData); }

    public override void Load() { DataManager.Inst.npcTitleEntities.AddRange(Data); }
}