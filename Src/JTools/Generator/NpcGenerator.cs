using System;
using System.Collections.Generic;
using TierneyJohn.MiChangSheng.JTools.Model.Entity;
using TierneyJohn.MiChangSheng.JTools.Model.Enum;
using TierneyJohn.MiChangSheng.JTools.Model.Enum.Avatar;

namespace TierneyJohn.MiChangSheng.JTools.Generator;

/// <summary>NPC 相关数据生成器</summary>
public static class NpcGenerator
{
    public static NpcAvatarEntity
        AvatarGenerator(
            int id,
            string title,
            string name,
            int face,
            AvatarLevelType level,
            int hp,
            int agile,
            int aptitude,
            int perception,
            int spirit,
            SectType sect,
            int age,
            int shouYuan,
            List<int> usedSkills,
            List<int> usedStaticSkills,
            Dictionary<ReikiType, int> reiki,
            int wuDaoType,
            int xingQuType,
            AvatarSexType sex = AvatarSexType.男,
            AvatarType avatarType = AvatarType.人,
            int usedYuanYingStaticSkill = 0,
            int usedHuaShenLingYu = 0,
            int equipWeapon = 0,
            int equipArmor = 0,
            int equipOrnament = 0,
            AvatarMoneyType moneyType = AvatarMoneyType.一级,
            int murderous = 0,
            int fightFace = 0,
            bool isRefresh = false,
            bool isDrop = true,
            bool toAuctions = true,
            List<int> auctionsType = null,
            bool guDingJiaGe = false,
            int sellPercent = 0,
            string surname = ""
        )
    {
        return new NpcAvatarEntity
        {
            Id = id,
            Title = title,
            Surname = surname,
            Name = name,
            Face = face,
            FightFace = fightFace,
            Sex = sex,
            AvatarType = avatarType,
            Level = level,
            Hp = hp,
            Agile = agile,
            Aptitude = aptitude,
            Perception = perception,
            Spirit = spirit,
            Murderous = murderous,
            Sect = sect,
            Age = age,
            LifeSpan = shouYuan,
            EquipWeapon = equipWeapon,
            EquipArmor = equipArmor,
            EquipOrnament = equipOrnament,
            Reiki = reiki,
            UsedSkills = usedSkills,
            UsedStaticSkills = usedStaticSkills,
            UsedYuanYingStaticSkill = usedYuanYingStaticSkill,
            UsedHuaShenLingYu = usedHuaShenLingYu,
            MoneyType = moneyType,
            IsRefresh = isRefresh,
            IsDrop = isDrop,
            ToAuctions = toAuctions,
            AuctionsType = auctionsType,
            WuDaoType = wuDaoType,
            XingQuType = xingQuType,
            GuDingJiaGe = guDingJiaGe,
            SellPercent = sellPercent
        };
    }

    public static NpcAvatarEntity ShopAvatarGenerator(
        int id,
        string title,
        string name = "",
        AvatarMoneyType moneyType = AvatarMoneyType.五级,
        AvatarSexType sex = AvatarSexType.男,
        bool isRefresh = true,
        bool isDrop = false,
        string surname = ""
    )
    {
        List<int> skills = [304, 532, 501, 502, 533];
        List<int> staticSkills = [5138, 5035, 5059];

        var reiki = new Dictionary<ReikiType, int>
        {
            { ReikiType.金, 10 },
            { ReikiType.木, 10 },
            { ReikiType.水, 10 },
            { ReikiType.火, 10 },
            { ReikiType.土, 10 },
            { ReikiType.魔, 0 }
        };

        return AvatarGenerator(
            id,
            title,
            name,
            0,
            AvatarLevelType.金丹初期,
            5000,
            30,
            15,
            10,
            25,
            SectType.散修,
            150,
            5000,
            skills,
            staticSkills,
            reiki,
            9,
            107,
            sex,
            moneyType: moneyType,
            isRefresh: isRefresh,
            isDrop: isDrop,
            toAuctions: false,
            surname: surname);
    }

    public static NpcImportantEntity NpcImportantGenerator(
        int id,
        int age,
        AvatarSexType sex,
        AvatarLevelType level,
        int liuPai,
        int aptitude,
        int perception,
        int xingGe,
        int title,
        int tag,
        string zhuJiTime,
        string jinDanTime,
        string yuanYingTime,
        string huaShenTime,
        bool isDaShiXiong = false,
        bool isZhangLao = false,
        bool isZhangMen = false,
        List<int> eventValue = null,
        string fuHao = ""
    )
    {
        return new NpcImportantEntity
        {
            Id = id,
            Age = age,
            Sex = sex,
            Level = level,
            LiuPai = liuPai,
            Aptitude = aptitude,
            Perception = perception,
            XingGe = xingGe,
            Title = title,
            Tag = tag,
            ZhuJiTime = zhuJiTime,
            JinDanTime = jinDanTime,
            YuanYingTime = yuanYingTime,
            HuaShenTime = huaShenTime,
            IsDaShiXiong = isDaShiXiong,
            IsZhangLao = isZhangLao,
            IsZhangMen = isZhangMen,
            EventValue = eventValue,
            FuHao = fuHao
        };
    }

    public static NpcTitleEntity NpcTitleGenerator(
        int id,
        int npcType,
        string title,
        int titleType,
        int titleLevel,
        List<int> levels,
        bool once = false,
        int gongXian = 0,
        int maxLevel = 1,
        List<(int, int)> actionChange = null
    )
    {
        actionChange ??= [];

        return new NpcTitleEntity
        {
            Id = id,
            NpcType = npcType,
            Title = title,
            TitleType = titleType,
            GongXian = gongXian,
            Levels = levels,
            Once = once,
            TitleLevel = titleLevel,
            MaxLevel = maxLevel,
            ActionChange = actionChange
        };
    }

    public static NpcBindEntity NpcBindGenerator(
        int id,
        string name,
        int image,
        List<int> avatars,
        string title = "",
        string startTime = "0001-01-01",
        string endTime = "5000-12-31",
        int auctionsImage = 0
    )
    {
        return new NpcBindEntity
        {
            Id = id,
            Name = name,
            Title = title,
            Image = image,
            AuctionsImage = auctionsImage == 0 ? image : auctionsImage,
            Avatars = avatars,
            StartTime = startTime,
            EndTime = endTime
        };
    }

    public static NpcActionEntity NpcActionGenerator(
        int id,
        int weight = 3,
        int panDing = 0,
        int allMapIndex = 0,
        int fuBen = 0,
        string scene = "Null",
        bool isTask = false,
        string talk = "无"
    )
    {
        return new NpcActionEntity
        {
            Id = id,
            Weight = weight,
            PanDing = panDing,
            AllMapIndex = allMapIndex,
            FuBen = fuBen,
            Scene = scene,
            IsTask = isTask,
            Talk = talk
        };
    }

    public static NpcSpawnEntity NpcSpawnGenerator(int id, int liuPai, List<(int, int)> spawn)
    {
        return new NpcSpawnEntity { Id = id, LiuPai = liuPai, Spawn = spawn };
    }

    public static NpcTaoEntity NpcTaoGenerator(int id, int type, int level, List<int> taoSkills, List<int> taoPoints)
    {
        return new NpcTaoEntity
        {
            Id = id,
            Type = type,
            Level = level,
            TaoSkills = taoSkills,
            TaoPoints = taoPoints
        };
    }

    public static IEnumerable<NpcTaoEntity> NpcTaoGenerator(int id, int type, List<List<int>> taoSkills)
    {
        for (var level = 1; level <= 15; level++)
        {
            List<int> taoPoints =
            [
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0
            ];

            foreach (var i in taoSkills[level - 1])
            {
                switch (i)
                {
                    case < 1100:
                        taoPoints[i / 100 - 1] = Math.Max(taoPoints[i / 100 - 1], taoPoints[i / 10 % 10]);
                        break;

                    case > 2100:
                    {
                        var num = i - 1000;
                        taoPoints[num / 100 - 1] = Math.Max(taoPoints[num / 100 - 1], taoPoints[num / 10 % 10]);
                        break;
                    }

                    case 2001:
                        taoPoints[0] = Math.Max(taoPoints[0], 4);
                        taoPoints[1] = Math.Max(taoPoints[1], 4);
                        taoPoints[2] = Math.Max(taoPoints[2], 4);
                        taoPoints[3] = Math.Max(taoPoints[3], 4);
                        taoPoints[4] = Math.Max(taoPoints[4], 4);
                        break;

                    case 2002:
                        taoPoints[1] = Math.Max(taoPoints[1], 2);
                        taoPoints[3] = Math.Max(taoPoints[3], 2);
                        break;

                    case 2003:
                        taoPoints[1] = Math.Max(taoPoints[1], 4);
                        taoPoints[2] = Math.Max(taoPoints[2], 4);
                        break;

                    case 2004:
                        taoPoints[0] = Math.Max(taoPoints[0], 4);
                        taoPoints[4] = Math.Max(taoPoints[4], 4);
                        break;

                    case 2005:
                        taoPoints[6] = Math.Max(taoPoints[6], 4);
                        taoPoints[8] = Math.Max(taoPoints[8], 4);
                        break;

                    case 2006:
                        taoPoints[6] = Math.Max(taoPoints[6], 1);
                        taoPoints[8] = Math.Max(taoPoints[8], 1);
                        break;
                }
            }

            yield return new NpcTaoEntity
            {
                Id = id + level,
                Type = type,
                Level = level,
                TaoSkills = taoSkills[level - 1],
                TaoPoints = taoPoints
            };
        }
    }

    public static NpcLiuPaiEntity NpcLiuPaiGenerator(
        int id,
        int type,
        int liuPai,
        SectType sect,
        AvatarType avatarType,
        int level,
        List<int> skills,
        List<int> staticSkills,
        Dictionary<ReikiType, int> reiki,
        int wuDaoType,
        List<int> tags,
        int xingQuType,
        List<int> equipWeaon,
        List<int> equipArmor,
        List<int> equipOrnament,
        List<int> jinDanType,
        List<int> shiLi,
        int attackType,
        int defenseType,
        int yuanYingSkill = 0,
        int huashenLingYu = 0,
        bool toAuactions = true,
        List<int> auctionsType = null,
        string firstName = ""
    )
    {
        auctionsType ??= [1];

        return new NpcLiuPaiEntity
        {
            Id = id,
            Type = type,
            LiuPai = liuPai,
            Sect = sect,
            AvatarType = avatarType,
            Level = level,
            Skills = skills,
            StaticSkills = staticSkills,
            Reiki = reiki,
            WuDaoType = wuDaoType,
            Tags = tags,
            YuanYingSkill = yuanYingSkill,
            HuaShenLingYu = huashenLingYu,
            ToAuctions = toAuactions,
            AuctionsType = auctionsType,
            XingQuType = xingQuType,
            EquipWeapon = equipWeaon,
            EquipArmor = equipArmor,
            EquipOrnament = equipOrnament,
            JinDanType = jinDanType,
            FirstName = firstName,
            ShiLi = shiLi,
            AttackType = attackType,
            DefenseType = defenseType
        };
    }

    public static IEnumerable<NpcLiuPaiEntity> NpcLiuPaiGenerator(
        int id,
        int type,
        int liuPai,
        SectType sect,
        AvatarType avatarType,
        List<List<int>> skills,
        List<List<int>> staticSkills,
        List<int> yuanYingSkill,
        Dictionary<ReikiType, int> reiki,
        int wuDaoType,
        List<int> tags,
        List<int> xingQuType,
        List<List<int>> equipWeaon,
        List<int> equipArmor,
        List<int> equipOrnament,
        List<int> jinDanType,
        List<List<int>> shiLi,
        int attackType,
        int defenseType,
        int huashenLingYu = 0,
        bool toAuactions = true,
        List<int> auctionsType = null,
        string firstName = ""
    )
    {
        auctionsType ??= [1];

        for (var level = 1; level <= 15; level++)
        {
            yield return new NpcLiuPaiEntity
            {
                Id = id + level,
                Type = type,
                LiuPai = liuPai,
                Sect = sect,
                AvatarType = avatarType,
                Level = level,
                Skills = skills[level - 1],
                StaticSkills = staticSkills[level - 1],
                Reiki = reiki,
                WuDaoType = wuDaoType,
                Tags = tags,
                YuanYingSkill = level >= 10 ? yuanYingSkill[level - 10] : 0,
                HuaShenLingYu = level >= 13 ? huashenLingYu : 0,
                ToAuctions = toAuactions,
                AuctionsType = auctionsType,
                XingQuType = xingQuType[level - 1],
                EquipWeapon = equipWeaon[level - 1],
                EquipArmor = equipArmor,
                EquipOrnament = equipOrnament,
                JinDanType = jinDanType,
                FirstName = firstName,
                ShiLi = shiLi[level - 1],
                AttackType = attackType,
                DefenseType = defenseType
            };
        }
    }
}