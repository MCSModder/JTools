using TierneyJohn.MiChangSheng.JTools.Manager;
using TierneyJohn.MiChangSheng.JTools.Model.Entity;

namespace TierneyJohn.MiChangSheng.JTools.Builder;

/// <summary>
/// NPC 立绘数据构造器
/// </summary>
public class NpcAvatarDataBuilder : BaseBuilder<NpcAvatarEntity>
{
    public override void Build() { Build(DataManager.NpcAvatarData); }

    public override void Load() { DataManager.Inst.npcAvatarEntities.AddRange(Data); }
}