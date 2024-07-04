using TierneyJohn.MiChangSheng.JTools.Manager;
using TierneyJohn.MiChangSheng.JTools.Model.Entity;

namespace TierneyJohn.MiChangSheng.JTools.Builder;

/// <summary>
/// 生平数据构造器
/// </summary>
public class BiographyDataBuilder : BaseBuilder<BiographyEntity>
{
    public override void Build() { Build(DataManager.BiographyData); }

    public override void Load() { DataManager.Inst.biographyEntities.AddRange(Data); }
}