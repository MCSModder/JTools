using System;
using SkySwordKill.Next.DialogEvent;
using SkySwordKill.Next.DialogSystem;
using TierneyJohn.MiChangSheng.JTools.Manager;

namespace TierneyJohn.MiChangSheng.JTools_Next.DialogEvent.Archive;

[DialogEvent("JT_AutoLoad")]
[DialogEvent("JT_自动读档")]
[DialogEvent("JT_快速读档")]
public class AutoLoad : IDialogEvent
{
    public void Execute(DialogCommand command, DialogEnvironment env, Action callback)
    {
        ArchiveManager.Inst.AutoLoadGame();
        callback?.Invoke();
    }
}