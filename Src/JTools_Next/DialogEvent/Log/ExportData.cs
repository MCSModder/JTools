using System;
using SkySwordKill.Next.DialogEvent;
using SkySwordKill.Next.DialogSystem;
using TierneyJohn.MiChangSheng.JTools_Editor.Manager;

namespace TierneyJohn.MiChangSheng.JTools_Next.DialogEvent.Log;

[DialogEvent("JT_ExportData")]
[DialogEvent("JT_导出存档数据")]
public class ExportData : IDialogEvent
{
    public void Execute(DialogCommand command, DialogEnvironment env, Action callback)
    {
        EditorManager.Inst.ExportData();
        callback?.Invoke();
    }
}