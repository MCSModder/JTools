using TierneyJohn.MiChangSheng.JTools.Manager;
using TierneyJohn.MiChangSheng.JTools.Model.Entity;

namespace TierneyJohn.MiChangSheng.JTools.Builder;

/// <summary>
/// NPC 生成数据构造器
/// </summary>
public class NpcSpawnDataBuilder : BaseBuilder<NpcSpawnEntity>
{
    public override void Build() { Build(DataManager.NpcSpawnData); }

    public override void Load() { DataManager.Inst.npcSpawnEntities.AddRange(Data); }
}