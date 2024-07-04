using SkySwordKill.Next.DialogSystem;
using TierneyJohn.MiChangSheng.JTools_Next.Util;
using TierneyJohn.MiChangSheng.JTools.Manager;

namespace TierneyJohn.MiChangSheng.JTools_Next.DialogEnv.Spine;

[DialogEnvQuery("JT_CheckSpine")]
[DialogEnvQuery("JT_验证Spine数据")]
public class CheckSpine : IDialogEnvQuery
{
    public object Execute(DialogEnvQueryContext context)
    {
        var id = context.GetValue<int>(0);
        return SpineManager.Inst.CheckSpine(id);
    }
}