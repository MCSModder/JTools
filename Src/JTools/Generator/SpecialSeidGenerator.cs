using System.Collections.Generic;
using TierneyJohn.MiChangSheng.JTools.Model.Entity.Seid;

namespace TierneyJohn.MiChangSheng.JTools.Generator;

/// <summary>特殊 Seid 数据生成器</summary>
public static class SpecialSeidGenerator
{
    public static BuffSeid138Entity Buff119Generator(int id, int target, int value1, int value2)
    {
        return new BuffSeid138Entity { Id = id, Target = target, Value1 = value1, Value2 = value2 };
    }

    public static BuffSeid141Entity Buff141Generator(int id, float value)
    {
        return new BuffSeid141Entity { Id = id, Value1 = value };
    }

    public static BuffSeid138Entity Buff134Generator(int id, int target, int value1, int value2)
    {
        return new BuffSeid138Entity { Id = id, Target = target, Value1 = value1, Value2 = value2 };
    }

    public static BuffSeid138Entity Buff138Generator(int id, int target, int value1, int value2)
    {
        return new BuffSeid138Entity { Id = id, Target = target, Value1 = value1, Value2 = value2 };
    }

    public static BuffSeid156Entity Buff156Generator(int id, int target, int value)
    {
        return new BuffSeid156Entity { Id = id, Target = target, Value1 = value };
    }

    public static ItemSeid40Entity Item40Generator(int id, string flowchart, string block)
    {
        return new ItemSeid40Entity { Id = id, Flowchart = flowchart, Block = block };
    }

    public static SkillSeid148Entity Skill148Generator(int id, int target, int value1, string check, int value2)
    {
        return new SkillSeid148Entity
        {
            Id = id,
            Target = target,
            Value1 = value1,
            Check = check,
            Value2 = value2
        };
    }

    public static SkillSeid152Entity Skill152Generator(int id, int target, int value1, int value2)
    {
        return new SkillSeid152Entity { Id = id, Target = target, Value1 = value1, Value2 = value2 };
    }

    public static StaticSkillSeid1Entity StaticSkill1Generator(int id, int target, List<int> value1, List<int> value2)
    {
        return new StaticSkillSeid1Entity { Id = id, Target = target, Value1 = value1, Value2 = value2 };
    }

    public static StaticSkillSeid9Entity StaticSkill9Generator(
        int id,
        string spine,
        string onMoveEnter = "",
        string onMoveExit = "",
        string onLoopMoveEnter = "",
        string onLoopMoveExit = ""
    )
    {
        return new StaticSkillSeid9Entity
        {
            Id = id,
            Spine = spine,
            OnMoveEnter = onMoveEnter,
            OnMoveExit = onMoveExit,
            OnLoopMoveEnter = onLoopMoveEnter,
            OnLoopMoveExit = onLoopMoveExit
        };
    }
}