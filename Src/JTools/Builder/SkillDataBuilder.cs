using TierneyJohn.MiChangSheng.JTools.Manager;
using TierneyJohn.MiChangSheng.JTools.Model.Entity;

namespace TierneyJohn.MiChangSheng.JTools.Builder;

/// <summary>
/// 神通数据构造器
/// </summary>
public class SkillDataBuilder : BaseBuilder<SkillEntity>
{
    public override void Build() { Build(DataManager.SkillData); }

    public override void Load() { DataManager.Inst.skillEntities.AddRange(Data); }
}