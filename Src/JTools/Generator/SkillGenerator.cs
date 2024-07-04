using System.Collections.Generic;
using TierneyJohn.MiChangSheng.JTools.Model.Entity;
using TierneyJohn.MiChangSheng.JTools.Model.Enum;
using TierneyJohn.MiChangSheng.JTools.Model.Enum.Item;
using TierneyJohn.MiChangSheng.JTools.Model.Enum.Skill;

namespace TierneyJohn.MiChangSheng.JTools.Generator;

/// <summary>神通数据生成器</summary>
public static class SkillGenerator
{
    public static IEnumerable<SkillEntity>
        Generator(
            int skillId,
            string name,
            string skillEffect,
            List<int> affix,
            List<int> seid,
            List<SkillAttackType> attackTypes,
            List<int> attack,
            List<int> sameCast,
            List<(ReikiType, int)> cast,
            LevelType levelType,
            GradeLevelType gradeLevelType,
            List<string> info,
            List<string> desc,
            string skillScript = "SkillAttack",
            IllustratedType illustratedType = IllustratedType.神通,
            SkillAskType askType = SkillAskType.普通,
            int skillOpen = 0,
            int learnTime = 0,
            bool canDF = true,
            int canUseDistMax = 30,
            int cd = 10000,
            int priority = 1000
        )
    {
        return
        [
            new SkillEntity
            {
                Id = skillId + 1,
                SkillId = skillId,
                Level = 1,
                Name = name + 1,
                SkillIconId = skillId,
                SkillEffect = skillEffect,
                Priority = priority,
                Affix = affix,
                Seid = seid,
                AskType = askType,
                AttackTypes = attackTypes,
                SkillScript = skillScript,
                Attack = attack[0],
                SameCast = sameCast,
                Cast = cast,
                LevelType = levelType,
                GradeLevelType = gradeLevelType,
                SkillOpen = skillOpen,
                LearnTime = learnTime,
                IllustratedType = illustratedType,
                CanDF = canDF,
                Info = info[0],
                Desc = desc[0],
                CanUseDistMax = canUseDistMax,
                Cd = cd
            },
            new SkillEntity
            {
                Id = skillId + 2,
                SkillId = skillId,
                Level = 2,
                Name = name + 2,
                SkillIconId = skillId,
                SkillEffect = skillEffect,
                Priority = priority,
                Affix = affix,
                Seid = seid,
                AskType = askType,
                AttackTypes = attackTypes,
                SkillScript = skillScript,
                Attack = attack[1],
                SameCast = sameCast,
                Cast = cast,
                LevelType = levelType,
                GradeLevelType = gradeLevelType,
                SkillOpen = skillOpen,
                LearnTime = learnTime,
                IllustratedType = illustratedType,
                CanDF = canDF,
                Info = info[1],
                Desc = desc[1],
                CanUseDistMax = canUseDistMax,
                Cd = cd
            },
            new SkillEntity
            {
                Id = skillId + 3,
                SkillId = skillId,
                Level = 3,
                Name = name + 3,
                SkillIconId = skillId,
                SkillEffect = skillEffect,
                Priority = priority,
                Affix = affix,
                Seid = seid,
                AskType = askType,
                AttackTypes = attackTypes,
                SkillScript = skillScript,
                Attack = attack[2],
                SameCast = sameCast,
                Cast = cast,
                LevelType = levelType,
                GradeLevelType = gradeLevelType,
                SkillOpen = skillOpen,
                LearnTime = learnTime,
                IllustratedType = illustratedType,
                CanDF = canDF,
                Info = info[2],
                Desc = desc[2],
                CanUseDistMax = canUseDistMax,
                Cd = cd
            },
            new SkillEntity
            {
                Id = skillId + 4,
                SkillId = skillId,
                Level = 4,
                Name = name + 4,
                SkillIconId = skillId,
                SkillEffect = skillEffect,
                Priority = priority,
                Affix = affix,
                Seid = seid,
                AskType = askType,
                AttackTypes = attackTypes,
                SkillScript = skillScript,
                Attack = attack[3],
                SameCast = sameCast,
                Cast = cast,
                LevelType = levelType,
                GradeLevelType = gradeLevelType,
                SkillOpen = skillOpen,
                LearnTime = learnTime,
                IllustratedType = illustratedType,
                CanDF = canDF,
                Info = info[3],
                Desc = desc[3],
                CanUseDistMax = canUseDistMax,
                Cd = cd
            },
            new SkillEntity
            {
                Id = skillId + 5,
                SkillId = skillId,
                Level = 5,
                Name = name + 5,
                SkillIconId = skillId,
                SkillEffect = skillEffect,
                Priority = priority,
                Affix = affix,
                Seid = seid,
                AskType = askType,
                AttackTypes = attackTypes,
                SkillScript = skillScript,
                Attack = attack[4],
                SameCast = sameCast,
                Cast = cast,
                LevelType = levelType,
                GradeLevelType = gradeLevelType,
                SkillOpen = skillOpen,
                LearnTime = learnTime,
                IllustratedType = illustratedType,
                CanDF = canDF,
                Info = info[4],
                Desc = desc[4],
                CanUseDistMax = canUseDistMax,
                Cd = cd
            }
        ];
    }
}