using System;
using SkySwordKill.Next.DialogEvent;
using SkySwordKill.Next.DialogSystem;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools_Next.DialogEvent.Task;

[DialogEvent("JT_AddTask")]
[DialogEvent("JT_添加任务")]
public class AddTask : IDialogEvent
{
    public void Execute(DialogCommand command, DialogEnvironment env, Action callback)
    {
        var taskId = command.GetInt(0);
        taskId.TryAddTask();
        callback?.Invoke();
    }
}