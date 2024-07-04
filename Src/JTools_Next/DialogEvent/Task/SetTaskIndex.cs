using System;
using SkySwordKill.Next.DialogEvent;
using SkySwordKill.Next.DialogSystem;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools_Next.DialogEvent.Task;

[DialogEvent("JT_SetTaskIndex")]
[DialogEvent("JT_任务跳转特定阶段")]
public class SetTaskIndex : IDialogEvent
{
    public void Execute(DialogCommand command, DialogEnvironment env, Action callback)
    {
        var taskId = command.GetInt(0);
        var taskIndex = command.GetInt(1);
        taskId.SetTaskIndex(taskIndex);
        callback?.Invoke();
    }
}