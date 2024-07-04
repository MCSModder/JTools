using SkySwordKill.Next.DialogSystem;
using TierneyJohn.MiChangSheng.JTools_Next.Util;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools_Next.DialogEnv.Task;

[DialogEnvQuery("JT_GetTaskIndex")]
[DialogEnvQuery("JT_获取当前任务阶段")]
public class GetTaskIndex : IDialogEnvQuery
{
    public object Execute(DialogEnvQueryContext context)
    {
        var taskId = context.GetValue<int>(0);
        return taskId.GetTaskIndex();
    }
}