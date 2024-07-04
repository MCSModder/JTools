using TierneyJohn.MiChangSheng.JTools.Manager;
using TierneyJohn.MiChangSheng.JTools.Model.Entity;

namespace TierneyJohn.MiChangSheng.JTools.Builder;

/// <summary>
/// 天机大比数据构造器
/// </summary>
public class TianJiDaBiDataBuilder : BaseBuilder<TianJiDaBiEntity>
{
    public override void Build() { Build(DataManager.TianJiDaBiData); }

    public override void Load() { DataManager.Inst.tianJiDaBiEntities.AddRange(Data); }
}