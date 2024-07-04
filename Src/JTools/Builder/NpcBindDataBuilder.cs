using TierneyJohn.MiChangSheng.JTools.Manager;
using TierneyJohn.MiChangSheng.JTools.Model.Entity;

namespace TierneyJohn.MiChangSheng.JTools.Builder;

/// <summary>
/// NPC 绑定数据构造器
/// </summary>
public class NpcBindDataBuilder : BaseBuilder<NpcBindEntity>
{
    public override void Build() { Build(DataManager.NpcBindData); }

    public override void Load() { DataManager.Inst.npcBindEntities.AddRange(Data); }
}