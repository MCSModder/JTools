using System.Collections.Generic;
using TierneyJohn.MiChangSheng.JTools.Model.Entity;
using TierneyJohn.MiChangSheng.JTools.Model.Enum.Item;
using TierneyJohn.MiChangSheng.JTools.Model.Enum.Tao;

namespace TierneyJohn.MiChangSheng.JTools.Generator;

/// <summary>物品数据生成器</summary>
public static class ItemGenerator
{
    public static ItemEntity
        Generator(
            int itemId,
            string name,
            int itemIconId,
            int maxCount,
            List<int> affix,
            List<int> seid,
            Model.Enum.Item.ItemType itemType,
            LevelType levelType,
            int price,
            string info,
            string desc,
            bool isConsumables,
            bool unSalable,
            GradeLevelType gradeLevelType = GradeLevelType.无,
            IllustratedType illustratedType = IllustratedType.其他,
            ShopType shopType = ShopType.不投放,
            int refreshTime = 0,
            int learnTime = 0,
            List<(TaoType, TaoLevelType)> prerequisites = null,
            string weaponType = "",
            List<int> equipAffix = null,
            int material = 0,
            int materialType = 0,
            int canUsedCount = 0,
            int toxicity = 0,
            bool npcCanUsed = false,
            MedicinalPropertyType mainDrug = MedicinalPropertyType.无,
            MedicinalPropertyType adjuvant = MedicinalPropertyType.无,
            MedicinalPropertyType drugPrimer = MedicinalPropertyType.无
        )
    {
        return new ItemEntity
        {
            Id = itemId,
            Name = name,
            ItemIconId = itemIconId,
            MaxCount = maxCount,
            Affix = affix,
            Seid = seid,
            ItemType = itemType,
            LevelType = levelType,
            Price = price,
            Info = info,
            Desc = desc,
            IsConsumables = isConsumables,
            UnSalable = unSalable,
            GradeLevelType = gradeLevelType,
            IllustratedType = illustratedType,
            ShopType = shopType,
            RefreshTime = refreshTime,
            LearnTime = learnTime,
            Prerequisites = prerequisites,
            WeaponType = weaponType,
            EquipAffix = equipAffix,
            Material = material,
            MaterialType = materialType,
            CanUsedCount = canUsedCount,
            Toxicity = toxicity,
            NpcCanUsed = npcCanUsed,
            MainDrug = mainDrug,
            Adjuvant = adjuvant,
            DrugPrimer = drugPrimer
        };
    }

    public static ItemEntity SkillGenerator(
        int skillItemId,
        string skillName,
        LevelType levelType,
        GradeLevelType gradeLevelType,
        string desc,
        List<(TaoType, TaoLevelType)> prerequisites,
        int price = 0,
        List<int> seid = null,
        List<int> affix = null,
        ShopType shopType = ShopType.不投放,
        bool unSalable = false,
        bool isConsumables = true
    )
    {
        affix ??= [4];
        seid ??= [1];
        int learnTime;

        switch (levelType, gradeLevelType)
        {
            case (LevelType.一品, GradeLevelType.下品):
                affix.AddRange([51, 401]);
                learnTime = 12;
                if (price == 0) price = 50;
                break;

            case (LevelType.一品, GradeLevelType.中品):
                affix.AddRange([51, 401]);
                learnTime = 24;
                if (price == 0) price = 100;
                break;

            case (LevelType.一品, GradeLevelType.上品):
                affix.AddRange([51, 401]);
                learnTime = 48;
                if (price == 0) price = 150;
                break;

            case (LevelType.二品, GradeLevelType.下品):
                affix.AddRange([51, 402]);
                learnTime = 72;
                if (price == 0) price = 1200;
                break;

            case (LevelType.二品, GradeLevelType.中品):
                affix.AddRange([51, 402]);
                learnTime = 96;
                if (price == 0) price = 1600;
                break;

            case (LevelType.二品, GradeLevelType.上品):
                affix.AddRange([51, 402]);
                learnTime = 120;
                if (price == 0) price = 2000;
                break;

            case (LevelType.三品, GradeLevelType.下品):
                affix.AddRange([52, 403]);
                learnTime = 144;
                if (price == 0) price = 36000;
                break;

            case (LevelType.三品, GradeLevelType.中品):
                affix.AddRange([52, 403]);
                learnTime = 240;
                if (price == 0) price = 42000;
                break;

            case (LevelType.三品, GradeLevelType.上品):
                affix.AddRange([52, 403]);
                learnTime = 288;
                if (price == 0) price = 48000;
                break;

            default:
                affix.AddRange([51, 401]);
                learnTime = 12;
                if (price == 0) price = 50;
                break;
        }

        return Generator(
            skillItemId,
            skillName,
            levelType == LevelType.三品 ? 110000 : 120000,
            1,
            affix,
            seid,
            Model.Enum.Item.ItemType.神通书,
            levelType,
            price,
            skillItemId >= 1000000000 ? $"{(skillItemId - 1000000000).ToString()}.0" : $"{skillItemId.ToString()}.0",
            desc,
            isConsumables,
            unSalable,
            gradeLevelType,
            learnTime: learnTime,
            prerequisites: prerequisites,
            shopType: shopType);
    }

    public static IEnumerable<ItemEntity> SkillsGenerator(
        int skillItemId,
        string skillName,
        LevelType levelType,
        GradeLevelType gradeLevelType,
        string desc,
        List<(TaoType, TaoLevelType)> prerequisites,
        int price = 0,
        List<int> seid = null,
        List<int> affix = null,
        ShopType shopType = ShopType.不投放,
        bool unSalable = false,
        bool isConsumables = true
    )
    {
        return
        [
            // 神通书
            SkillGenerator(
                skillItemId,
                skillName,
                levelType,
                gradeLevelType,
                desc,
                prerequisites,
                price,
                seid,
                affix,
                shopType,
                unSalable,
                isConsumables),
            // 请教用神通书
            SkillGenerator(
                skillItemId + 1000000000,
                skillName,
                levelType,
                gradeLevelType,
                desc,
                prerequisites,
                price,
                seid,
                affix,
                shopType,
                unSalable,
                isConsumables),
        ];
    }

    public static ItemEntity StaticSkillGenerator(
        int skillItemId,
        string skillName,
        LevelType levelType,
        GradeLevelType gradeLevelType,
        string desc,
        List<(TaoType, TaoLevelType)> prerequisites,
        int price = 0,
        List<int> seid = null,
        List<int> affix = null,
        ShopType shopType = ShopType.不投放,
        bool unSalable = false,
        bool isConsumables = true
    )
    {
        affix ??= [5];
        seid ??= [2];
        int learnTime;

        switch (levelType, gradeLevelType)
        {
            case (LevelType.一品, GradeLevelType.下品):
                affix.AddRange([51, 501]);
                learnTime = 120;
                if (price == 0) price = 100;
                break;

            case (LevelType.一品, GradeLevelType.中品):
                affix.AddRange([51, 501]);
                learnTime = 152;
                if (price == 0) price = 150;
                break;

            case (LevelType.一品, GradeLevelType.上品):
                affix.AddRange([51, 501]);
                learnTime = 180;
                if (price == 0) price = 200;
                break;

            case (LevelType.二品, GradeLevelType.下品):
                affix.AddRange([51, 502]);
                learnTime = 288;
                if (price == 0) price = 4000;
                break;

            case (LevelType.二品, GradeLevelType.中品):
                affix.AddRange([51, 502]);
                learnTime = 320;
                if (price == 0) price = 6000;
                break;

            case (LevelType.二品, GradeLevelType.上品):
                affix.AddRange([51, 502]);
                learnTime = 360;
                if (price == 0) price = 8000;
                break;

            case (LevelType.三品, GradeLevelType.下品):
                affix.AddRange([52, 503]);
                learnTime = 480;
                if (price == 0) price = 480000;
                break;

            case (LevelType.三品, GradeLevelType.中品):
                affix.AddRange([52, 503]);
                learnTime = 600;
                if (price == 0) price = 800000;
                break;

            case (LevelType.三品, GradeLevelType.上品):
                affix.AddRange([52, 503]);
                learnTime = 720;
                if (price == 0) price = 1000000;
                break;

            default:
                affix.AddRange([51, 501]);
                learnTime = 120;
                if (price == 0) price = 50;
                break;
        }

        return Generator(
            skillItemId,
            skillName,
            levelType == LevelType.三品 ? 110000 : 120000,
            1,
            affix,
            seid,
            Model.Enum.Item.ItemType.功法书,
            levelType,
            price,
            skillItemId >= 1000000000 ? $"{(skillItemId - 1000000000).ToString()}.0" : $"{skillItemId.ToString()}.0",
            desc,
            isConsumables,
            unSalable,
            gradeLevelType,
            learnTime: learnTime,
            prerequisites: prerequisites,
            shopType: shopType);
    }

    public static List<ItemEntity> StaticSkillsGenerator(
        int skillItemId,
        string skillName,
        LevelType levelType,
        GradeLevelType gradeLevelType,
        string desc,
        List<(TaoType, TaoLevelType)> prerequisites,
        int price = 0,
        List<int> seid = null,
        List<int> affix = null,
        ShopType shopType = ShopType.不投放,
        bool unSalable = false,
        bool isConsumables = true
    )
    {
        return
        [
            // 功法书
            StaticSkillGenerator(
                skillItemId,
                skillName,
                levelType,
                gradeLevelType,
                desc,
                prerequisites,
                price,
                seid,
                affix,
                shopType,
                unSalable,
                isConsumables),
            // 请教用功法书
            StaticSkillGenerator(
                skillItemId + 1000000000,
                skillName,
                levelType,
                gradeLevelType,
                desc,
                prerequisites,
                price,
                seid,
                affix,
                shopType,
                unSalable,
                isConsumables),
        ];
    }

    public static ItemEntity WeaponGenerator(
        int weaponId,
        string weaponName,
        string weaponType,
        List<int> affix,
        List<int> equipAffix,
        List<int> seid,
        LevelType levelType,
        GradeLevelType gradeLevelType,
        int price,
        string info,
        string desc,
        bool unSalable = false
    )
    {
        return Generator(
            weaponId,
            weaponName,
            weaponId,
            1,
            affix,
            seid,
            Model.Enum.Item.ItemType.武器,
            levelType,
            price,
            info,
            desc,
            false,
            unSalable,
            gradeLevelType,
            weaponType: weaponType,
            equipAffix: equipAffix);
    }

    public static ItemEntity ArmorGenerator(
        int armorId,
        string armorName,
        List<int> affix,
        List<int> equipAffix,
        List<int> seid,
        LevelType levelType,
        GradeLevelType gradeLevelType,
        int price,
        string info,
        string desc,
        bool unSalable = false
    )
    {
        return Generator(
            armorId,
            armorName,
            armorId,
            1,
            affix,
            seid,
            Model.Enum.Item.ItemType.衣服,
            levelType,
            price,
            info,
            desc,
            false,
            unSalable,
            gradeLevelType,
            equipAffix: equipAffix);
    }

    public static ItemEntity OrnamentsGenerator(
        int ornamentsId,
        string ornamentsName,
        List<int> affix,
        List<int> equipAffix,
        List<int> seid,
        LevelType levelType,
        GradeLevelType gradeLevelType,
        int price,
        string info,
        string desc,
        bool unSalable = false
    )
    {
        return Generator(
            ornamentsId,
            ornamentsName,
            ornamentsId,
            1,
            affix,
            seid,
            Model.Enum.Item.ItemType.饰品,
            levelType,
            price,
            info,
            desc,
            false,
            unSalable,
            gradeLevelType,
            equipAffix: equipAffix);
    }

    public static ItemEntity ElixirGenerator(
        int elixirId,
        string elixirName,
        int elixirIconId,
        List<int> seid,
        LevelType levelType,
        ShopType shopType,
        int price,
        string info,
        string desc,
        int canUsedCount,
        int toxicity,
        bool npcCanUsed = true,
        bool unSalable = false
    )
    {
        var affix = new List<int> { 6, 600 + (int)levelType };

        return Generator(
            elixirId,
            elixirName,
            elixirIconId,
            99999,
            affix,
            seid,
            Model.Enum.Item.ItemType.丹药,
            levelType,
            price,
            info,
            desc,
            true,
            unSalable,
            illustratedType: IllustratedType.丹药,
            canUsedCount: canUsedCount,
            toxicity: toxicity,
            npcCanUsed: npcCanUsed,
            shopType: shopType);
    }

    public static ItemEntity ElixirFormulaGenerator(
        int elixirFormulaId,
        string elixirFormulaName,
        int elixirFormulaIconId,
        LevelType levelType,
        ShopType shopType,
        int price,
        string info,
        string desc,
        bool unSalable = false
    )
    {
        var affix = new List<int> { 10, 1000 + (int)levelType };

        return Generator(
            elixirFormulaId,
            elixirFormulaName,
            elixirFormulaIconId,
            1,
            affix,
            [13],
            Model.Enum.Item.ItemType.丹方,
            levelType,
            price,
            info,
            desc,
            true,
            unSalable,
            canUsedCount: 1,
            shopType: shopType);
    }

    public static ItemEntity SpecialGoodsGenerator(
        int specialGoodsId,
        string specialGoodsName,
        List<int> seid,
        string info,
        string desc,
        LevelType levelType = LevelType.六品,
        bool unSalable = true,
        int price = 1,
        bool isConsumables = true
    )
    {
        return Generator(
            specialGoodsId,
            specialGoodsName,
            specialGoodsId,
            1,
            [53],
            seid,
            Model.Enum.Item.ItemType.任务,
            levelType,
            price,
            info,
            desc,
            isConsumables,
            unSalable);
    }
}