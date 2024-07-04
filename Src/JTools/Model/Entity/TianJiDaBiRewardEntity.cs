using System;
using System.Collections.Generic;
using JSONClass;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools.Model.Entity;

/// <summary>天机大比奖励数据实体类</summary>
[Serializable]
public class TianJiDaBiRewardEntity
{
    #region 字段属性

    /// <summary>对应流派编号</summary>
    public virtual int Id { get; set; }

    /// <summary>阶段奖励</summary>
    public virtual List<List<int>> Rewards { get; set; } = [];

    #endregion

    #region 构造方法

    public void Create(TianJiDaBiReward data)
    {
        Id = data.id;

        Rewards =
        [
            data.Reward1,
            data.Reward2,
            data.Reward3,
            data.Reward4,
            data.Reward5,
            data.Reward6,
            data.Reward7,
            data.Reward8,
            data.Reward9,
            data.Reward10
        ];
    }

    #endregion

    #region 公开方法

    public JSONObject ToJsonObject()
    {
        var data = JSONObject.Create();
        data.SetField("id", Id);

        Rewards ??= [];

        for (var index = 1; index <= 10; index++)
        {
            data.SetField(
                $"Reward{index}",
                index <= Rewards.Count ? Rewards[index - 1].ToJsonObject() : JSONObject.arr);
        }

        return data;
    }

    #endregion
}