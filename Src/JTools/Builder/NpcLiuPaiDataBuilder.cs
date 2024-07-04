using TierneyJohn.MiChangSheng.JTools.Manager;
using TierneyJohn.MiChangSheng.JTools.Model.Entity;

namespace TierneyJohn.MiChangSheng.JTools.Builder;

/// <summary>
/// NPC 流派数据构造器
/// </summary>
public class NpcLiuPaiDataBuilder : BaseBuilder<NpcLiuPaiEntity>
{
    public override void Build() { Build(DataManager.NpcLiuPaiData); }

    public override void Load() { DataManager.Inst.npcLiuPaiEntities.AddRange(Data); }
}