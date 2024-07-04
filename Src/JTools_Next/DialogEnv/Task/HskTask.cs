using SkySwordKill.Next.DialogSystem;
using TierneyJohn.MiChangSheng.JTools_Next.Util;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools_Next.DialogEnv.Task;

[DialogEnvQuery("JT_HasTask")]
[DialogEnvQuery("JT_验证任务是否存在")]
public class HskTask : IDialogEnvQuery
{
    public object Execute(DialogEnvQueryContext context)
    {
        var taskId = context.GetValue<int>(0);
        return taskId.HasTask();
    }
}