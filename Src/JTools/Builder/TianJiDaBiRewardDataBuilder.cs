using TierneyJohn.MiChangSheng.JTools.Manager;
using TierneyJohn.MiChangSheng.JTools.Model.Entity;

namespace TierneyJohn.MiChangSheng.JTools.Builder;

/// <summary>
/// 天机大比奖励数据构造器
/// </summary>
public class TianJiDaBiRewardDataBuilder : BaseBuilder<TianJiDaBiRewardEntity>
{
    public override void Build() { Build(DataManager.TianJiDaBiRewardData); }

    public override void Load() { DataManager.Inst.tianJiDaBiRewardEntities.AddRange(Data); }
}