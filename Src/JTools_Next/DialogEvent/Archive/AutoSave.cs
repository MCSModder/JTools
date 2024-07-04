using System;
using SkySwordKill.Next.DialogEvent;
using SkySwordKill.Next.DialogSystem;
using TierneyJohn.MiChangSheng.JTools.Manager;

namespace TierneyJohn.MiChangSheng.JTools_Next.DialogEvent.Archive;

[DialogEvent("JT_AutoSave")]
[DialogEvent("JT_自动存档")]
[DialogEvent("JT_快速存档")]
public class AutoSave : IDialogEvent
{
    public void Execute(DialogCommand command, DialogEnvironment env, Action callback)
    {
        ArchiveManager.Inst.AutoSaveGame();
        callback?.Invoke();
    }
}