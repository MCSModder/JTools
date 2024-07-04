using SkySwordKill.Next.DialogSystem;
using TierneyJohn.MiChangSheng.JTools_Next.Util;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools_Next.DialogEnv.Task;

[DialogEnvQuery("JT_GetTaskData")]
[DialogEnvQuery("JT_获取任务数据")]
public class GetTaskData : IDialogEnvQuery
{
    public object Execute(DialogEnvQueryContext context)
    {
        var taskId = context.GetValue<int>(0);
        return taskId.GetTaskData();
    }
}