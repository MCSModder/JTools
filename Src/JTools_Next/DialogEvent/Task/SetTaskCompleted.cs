using System;
using SkySwordKill.Next.DialogEvent;
using SkySwordKill.Next.DialogSystem;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools_Next.DialogEvent.Task;

[DialogEvent("JT_SetTaskCompleted")]
[DialogEvent("JT_任务完成")]
public class SetTaskCompleted : IDialogEvent
{
    public void Execute(DialogCommand command, DialogEnvironment env, Action callback)
    {
        var taskId = command.GetInt(0);
        taskId.SetTaskCompleted();
        callback?.Invoke();
    }
}