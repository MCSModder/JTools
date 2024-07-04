using System;
using SkySwordKill.Next.DialogEvent;
using SkySwordKill.Next.DialogSystem;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools_Next.DialogEvent.Task;

[DialogEvent("JT_NextTask")]
[DialogEvent("JT_任务跳转阶段")]
public class NextTask : IDialogEvent
{
    public void Execute(DialogCommand command, DialogEnvironment env, Action callback)
    {
        var taskId = command.GetInt(0);
        taskId.NextTask();
        callback?.Invoke();
    }
}