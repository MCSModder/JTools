using SkySwordKill.Next.DialogSystem;
using TierneyJohn.MiChangSheng.JTools_Next.Util;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools_Next.DialogEnv.Task;

[DialogEnvQuery("JT_GetTaskFinalIndex")]
[DialogEnvQuery("JT_获取任务最终阶段索引")]
public class GetTaskFinalIndex : IDialogEnvQuery
{
    public object Execute(DialogEnvQueryContext context)
    {
        var taskId = context.GetValue<int>(0);
        return taskId.GetFinalIndex();
    }
}