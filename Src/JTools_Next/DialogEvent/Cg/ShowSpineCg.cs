using System;
using SkySwordKill.Next.DialogEvent;
using SkySwordKill.Next.DialogSystem;
using TierneyJohn.MiChangSheng.JTools.Manager;

namespace TierneyJohn.MiChangSheng.JTools_Next.DialogEvent.Cg;

[DialogEvent("JT_ShowSpineCg")]
[DialogEvent("JT_显示动态Cg")]
public class ShowSpineCg : IDialogEvent
{
    public void Execute(DialogCommand command, DialogEnvironment env, Action callback)
    {
        var spineName = command.GetStr(0);
        var skinName = command.GetStr(1);

        CgManager.Inst.ShowSpineCg(spineName, skinName, callback);
    }
}