using System;
using SkySwordKill.Next.DialogEvent;
using SkySwordKill.Next.DialogSystem;
using TierneyJohn.MiChangSheng.JTools_Editor.Manager;

namespace TierneyJohn.MiChangSheng.JTools_Next.DialogEvent.Log;

[DialogEvent("JT_SettingLogConfig")]
[DialogEvent("JT_修改日志配置")]
public class SettingLogConfig : IDialogEvent
{
    public void Execute(DialogCommand command, DialogEnvironment env, Action callback)
    {
        EditorManager.Inst.SettingLogConfig();
        callback?.Invoke();
    }
}