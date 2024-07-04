using System.Collections.Generic;
using TierneyJohn.MiChangSheng.JTools.Model.Entity;
using TierneyJohn.MiChangSheng.JTools.Model.Enum.Item;
using TierneyJohn.MiChangSheng.JTools.Model.Enum.Skill;

namespace TierneyJohn.MiChangSheng.JTools.Generator;

/// <summary>功法数据生成器</summary>
public static class StaticSkillGenerator
{
    public static IEnumerable<StaticSkillEntity> Generator(
        int skillId,
        string name,
        List<int> affix,
        List<int> seid,
        StaticSkillType skillType,
        LevelType levelType,
        GradeLevelType gradeLevelType,
        List<string> info,
        List<string> desc,
        SkillSpeedType skillSpeed = SkillSpeedType.中庸,
        List<int> learnTimes = null,
        IllustratedType illustratedType = IllustratedType.功法,
        SkillAskType askType = SkillAskType.普通,
        bool canDF = true
    )
    {
        learnTimes ??= [0, 0, 0, 0, 0];

        return
        [
            new StaticSkillEntity
            {
                Id = skillId + 1,
                SkillId = skillId,
                Level = 1,
                Name = name + 1,
                SkillIconId = skillId,
                Affix = affix,
                Seid = seid,
                AskType = askType,
                SkillType = skillType,
                LevelType = levelType,
                GradeLevelType = gradeLevelType,
                LearnTime = learnTimes[0],
                SkillSpeed = skillSpeed,
                IllustratedType = illustratedType,
                CanDF = canDF,
                Info = info[0],
                Desc = desc[0]
            },
            new StaticSkillEntity
            {
                Id = skillId + 2,
                SkillId = skillId,
                Level = 2,
                Name = name + 2,
                SkillIconId = skillId,
                Affix = affix,
                Seid = seid,
                AskType = askType,
                SkillType = skillType,
                LevelType = levelType,
                GradeLevelType = gradeLevelType,
                LearnTime = learnTimes[1],
                SkillSpeed = skillSpeed,
                IllustratedType = illustratedType,
                CanDF = canDF,
                Info = info[1],
                Desc = desc[1]
            },
            new StaticSkillEntity
            {
                Id = skillId + 3,
                SkillId = skillId,
                Level = 3,
                Name = name + 3,
                SkillIconId = skillId,
                Affix = affix,
                Seid = seid,
                AskType = askType,
                SkillType = skillType,
                LevelType = levelType,
                GradeLevelType = gradeLevelType,
                LearnTime = learnTimes[2],
                SkillSpeed = skillSpeed,
                IllustratedType = illustratedType,
                CanDF = canDF,
                Info = info[2],
                Desc = desc[2]
            },
            new StaticSkillEntity
            {
                Id = skillId + 4,
                SkillId = skillId,
                Level = 4,
                Name = name + 4,
                SkillIconId = skillId,
                Affix = affix,
                Seid = seid,
                AskType = askType,
                SkillType = skillType,
                LevelType = levelType,
                GradeLevelType = gradeLevelType,
                LearnTime = learnTimes[3],
                SkillSpeed = skillSpeed,
                IllustratedType = illustratedType,
                CanDF = canDF,
                Info = info[3],
                Desc = desc[3]
            },
            new StaticSkillEntity
            {
                Id = skillId + 5,
                SkillId = skillId,
                Level = 5,
                Name = name + 5,
                SkillIconId = skillId,
                Affix = affix,
                Seid = seid,
                AskType = askType,
                SkillType = skillType,
                LevelType = levelType,
                GradeLevelType = gradeLevelType,
                LearnTime = learnTimes[4],
                SkillSpeed = skillSpeed,
                IllustratedType = illustratedType,
                CanDF = canDF,
                Info = info[4],
                Desc = desc[4]
            }
        ];
    }
}