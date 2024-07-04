using System;
using SkySwordKill.Next.DialogEvent;
using SkySwordKill.Next.DialogSystem;
using TierneyJohn.MiChangSheng.JTools.Manager;

namespace TierneyJohn.MiChangSheng.JTools_Next.DialogEvent.Archive;

[DialogEvent("JT_OnSaved")]
[DialogEvent("JT_调用存档事件")]
public class OnSaved : IDialogEvent
{
    public void Execute(DialogCommand command, DialogEnvironment env, Action callback)
    {
        ArchiveManager.Inst.Saved();
        callback?.Invoke();
    }
}