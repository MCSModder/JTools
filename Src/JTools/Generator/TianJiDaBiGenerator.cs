using System.Collections.Generic;
using TierneyJohn.MiChangSheng.JTools.Model.Entity;

namespace TierneyJohn.MiChangSheng.JTools.Generator;

/// <summary>天机大比数据生成器</summary>
public static class TianJiDaBiGenerator
{
    public static TianJiDaBiEntity Generator(int id, int youXian, int liuPai)
    {
        return new TianJiDaBiEntity { Id = id, YouXian = youXian, LiuPai = liuPai };
    }

    public static TianJiDaBiRewardEntity RewardGenerator(int id, List<List<int>> rewards)
    {
        return new TianJiDaBiRewardEntity { Id = id, Rewards = rewards };
    }
}