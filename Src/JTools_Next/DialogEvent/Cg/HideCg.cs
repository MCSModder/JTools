using System;
using SkySwordKill.Next.DialogEvent;
using SkySwordKill.Next.DialogSystem;
using TierneyJohn.MiChangSheng.JTools.Manager;

namespace TierneyJohn.MiChangSheng.JTools_Next.DialogEvent.Cg;

[DialogEvent("JT_HideCg")]
[DialogEvent("JT_隐藏静态Cg")]
public class HideCg : IDialogEvent
{
    public void Execute(DialogCommand command, DialogEnvironment env, Action callback)
    {
        CgManager.Inst.HideCg(callback);
    }
}