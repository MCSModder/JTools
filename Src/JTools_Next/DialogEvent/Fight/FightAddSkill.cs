using System;
using SkySwordKill.Next.DialogEvent;
using SkySwordKill.Next.DialogSystem;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools_Next.DialogEvent.Fight;

[DialogEvent("JT_FightAddSkill")]
[DialogEvent("JT_添加战斗面板神通")]
public class FightAddSkill : IDialogEvent
{
    public void Execute(DialogCommand command, DialogEnvironment env, Action callback)
    {
        var skillId = command.GetInt(0);
        PlayerEx.Player.FightAddSkill(skillId);
        callback?.Invoke();
    }
}