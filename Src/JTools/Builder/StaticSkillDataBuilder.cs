using TierneyJohn.MiChangSheng.JTools.Manager;
using TierneyJohn.MiChangSheng.JTools.Model.Entity;

namespace TierneyJohn.MiChangSheng.JTools.Builder;

/// <summary>
/// 功法数据构造器
/// </summary>
public class StaticSkillDataBuilder : BaseBuilder<StaticSkillEntity>
{
    public override void Build() { Build(DataManager.StaticSkillData); }

    public override void Load() { DataManager.Inst.staticSkillEntities.AddRange(Data); }
}