using System;
using System.Collections.Generic;
using System.Linq;
using JSONClass;
using TierneyJohn.MiChangSheng.JTools.Model.Enum.Item;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools.Model.Entity;

/// <summary>背包数据实体类</summary>
[Serializable]
public class BackpackEntity
{
    #region 字段属性

    /// <summary>背包编号</summary>
    public virtual int Id { get; set; }

    /// <summary>绑定角色编号</summary>
    public virtual int AvatarId { get; set; }

    /// <summary>背包名称</summary>
    public virtual string Name { get; set; }

    /// <summary>随机物品</summary>
    public virtual (ShopType, LevelType, List<int>) RandomItems { get; set; } = (ShopType.无, LevelType.无, null);

    /// <summary>固定物品</summary>
    public virtual List<(int, int)> Items { get; set; } = [];

    /// <summary>是否可以售卖</summary>
    public virtual bool CanSell { get; set; }

    /// <summary>售价百分比 基础 100</summary>
    public virtual int Percent { get; set; } = 100;

    /// <summary>是否可掉落</summary>
    public virtual bool CanDrop { get; set; }

    #endregion

    #region 构造方法

    public void Create(BackpackJsonData data)
    {
        Id = data.id;
        AvatarId = data.AvatrID;
        Name = data.BackpackName;
        CanSell = data.CanSell == 1;
        Percent = data.SellPercent;
        CanDrop = data.CanDrop == 1;

        if (data.Type == 0)
            Items = data.ItemID.Zip(data.randomNum, (item1, item2) => (item1, item2)).ToList();
        else
            RandomItems = ((ShopType)data.Type, (LevelType)data.quality, data.randomNum);
    }

    #endregion

    #region 公开方法

    public JSONObject ToJsonObject()
    {
        var data = JSONObject.Create();
        data.AddField("id", Id);
        data.AddField("AvatrID", AvatarId);
        data.AddField("BackpackName", Name);
        data.AddField("CanSell", CanSell ? 1 : 0);
        data.AddField("SellPercent", Percent);
        data.AddField("CanDrop", CanDrop ? 1 : 0);

        if (Items != null && Items.Count != 0)
        {
            data.AddField("Type", 0);
            data.AddField("quality", 0);
            data.AddField("ItemID", Items.Select(item => item.Item1).ToList().ToJsonObject());
            data.AddField("randomNum", Items.Select(item => item.Item2).ToList().ToJsonObject());
        }
        else
        {
            data.AddField("Type", (int)RandomItems.Item1);
            data.AddField("quality", (int)RandomItems.Item2);
            data.AddField("ItemID", JSONObject.arr);
            data.AddField("randomNum", RandomItems.Item3.ToJsonObject());
        }

        return data;
    }

    #endregion
}