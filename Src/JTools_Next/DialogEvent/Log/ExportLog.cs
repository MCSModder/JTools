using System;
using SkySwordKill.Next.DialogEvent;
using SkySwordKill.Next.DialogSystem;
using TierneyJohn.MiChangSheng.JTools_Editor.Manager;

namespace TierneyJohn.MiChangSheng.JTools_Next.DialogEvent.Log;

[DialogEvent("JT_ExportLog")]
[DialogEvent("JT_导出日志")]
public class ExportLog : IDialogEvent
{
    public void Execute(DialogCommand command, DialogEnvironment env, Action callback)
    {
        EditorManager.Inst.ExportLog();
        callback?.Invoke();
    }
}