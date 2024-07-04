using System;
using SkySwordKill.Next.DialogEvent;
using SkySwordKill.Next.DialogSystem;
using TierneyJohn.MiChangSheng.JTools.Manager;

namespace TierneyJohn.MiChangSheng.JTools_Next.DialogEvent.Cg;

[DialogEvent("JT_HideSpineCg")]
[DialogEvent("JT_隐藏动态Cg")]
public class HideSpineCg : IDialogEvent
{
    public void Execute(DialogCommand command, DialogEnvironment env, Action callback)
    {
        CgManager.Inst.HideSpineCg(callback);
    }
}