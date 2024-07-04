using TierneyJohn.MiChangSheng.JTools.Manager;
using TierneyJohn.MiChangSheng.JTools.Model.Entity;

namespace TierneyJohn.MiChangSheng.JTools.Builder;

/// <summary>
/// Npc 悟道数据构造器
/// </summary>
public class NpcTaoDataBuilder : BaseBuilder<NpcTaoEntity>
{
    public override void Build() { Build(DataManager.NpcTaoData); }

    public override void Load() { DataManager.Inst.npcTaoEntities.AddRange(Data); }
}