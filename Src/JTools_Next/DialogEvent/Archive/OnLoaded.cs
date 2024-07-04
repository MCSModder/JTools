using System;
using SkySwordKill.Next.DialogEvent;
using SkySwordKill.Next.DialogSystem;
using TierneyJohn.MiChangSheng.JTools.Manager;

namespace TierneyJohn.MiChangSheng.JTools_Next.DialogEvent.Archive;

[DialogEvent("JT_OnLoaded")]
[DialogEvent("JT_调用读档事件")]
public class OnLoaded : IDialogEvent
{
    public void Execute(DialogCommand command, DialogEnvironment env, Action callback)
    {
        ArchiveManager.Inst.Loaded();
        callback?.Invoke();
    }
}