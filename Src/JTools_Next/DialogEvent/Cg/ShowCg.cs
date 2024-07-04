using System;
using SkySwordKill.Next.DialogEvent;
using SkySwordKill.Next.DialogSystem;
using TierneyJohn.MiChangSheng.JTools.Manager;

namespace TierneyJohn.MiChangSheng.JTools_Next.DialogEvent.Cg;

[DialogEvent("JT_ShowCg")]
[DialogEvent("JT_显示静态Cg")]
public class ShowCg : IDialogEvent
{
    public void Execute(DialogCommand command, DialogEnvironment env, Action callback)
    {
        var cg = command.GetStr(0);
        CgManager.Inst.ShowCg(cg, callback);
    }
}