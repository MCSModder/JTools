using System;
using SkySwordKill.Next.DialogEvent;
using SkySwordKill.Next.DialogSystem;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools_Next.DialogEvent.Fight;

[DialogEvent("JT_FightChangeSkill")]
[DialogEvent("JT_替换战斗面板神通")]
public class FightChangeSkill : IDialogEvent
{
    public void Execute(DialogCommand command, DialogEnvironment env, Action callback)
    {
        var skillId = command.GetInt(0);
        var toSkillId = command.GetInt(1);
        PlayerEx.Player.FightChangeSkill(skillId, toSkillId);
        callback?.Invoke();
    }
}