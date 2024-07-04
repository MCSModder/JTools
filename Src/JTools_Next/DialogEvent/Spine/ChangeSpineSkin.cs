using System;
using SkySwordKill.Next.DialogEvent;
using SkySwordKill.Next.DialogSystem;
using TierneyJohn.MiChangSheng.JTools.Manager;

namespace TierneyJohn.MiChangSheng.JTools_Next.DialogEvent.Spine;

[DialogEvent("JT_ChangeSpineSkin")]
[DialogEvent("JT_变更立绘皮肤")]
public class ChangeSpineSkin : IDialogEvent
{
    public void Execute(DialogCommand command, DialogEnvironment env, Action callback)
    {
        var spine = command.GetInt(0);
        var skin = command.GetStr(1);

        SpineManager.Inst.ChangeSpineSkin(spine, skin);
        callback?.Invoke();
    }
}