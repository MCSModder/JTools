using System.Collections.Generic;
using System.Linq;
using TierneyJohn.MiChangSheng.JTools.Model.Entity;
using TierneyJohn.MiChangSheng.JTools.Model.Enum.Item;

namespace TierneyJohn.MiChangSheng.JTools.Generator;

/// <summary>背包数据生成器</summary>
public static class BackpackGenerator
{
    public static BackpackEntity Generator(
        int id,
        int avatarId,
        string name,
        IEnumerable<int> items,
        int percent = 100,
        bool canSell = true,
        bool canDrop = true
    )
    {
        return new BackpackEntity
        {
            Id = id,
            AvatarId = avatarId,
            Name = name,
            Percent = percent,
            CanSell = canSell,
            CanDrop = canDrop,
            Items = items.Select(item => (item, 1)).ToList()
        };
    }

    public static BackpackEntity Generator(
        int id,
        int avatarId,
        string name,
        List<(int, int)> items,
        int percent,
        bool canSell = true,
        bool canDrop = true
    )
    {
        return new BackpackEntity
        {
            Id = id,
            AvatarId = avatarId,
            Name = name,
            Percent = percent,
            CanSell = canSell,
            CanDrop = canDrop,
            Items = items
        };
    }

    public static BackpackEntity Generator(
        int id,
        int avatarId,
        string name,
        (ShopType, LevelType, List<int>) randomItems,
        int percent = 100,
        bool canSell = true,
        bool canDrop = true
    )
    {
        return new BackpackEntity
        {
            Id = id,
            AvatarId = avatarId,
            Name = name,
            Percent = percent,
            CanSell = canSell,
            CanDrop = canDrop,
            RandomItems = randomItems
        };
    }
}