using SkySwordKill.Next.DialogSystem;
using TierneyJohn.MiChangSheng.JTools_Next.Util;
using TierneyJohn.MiChangSheng.JTools.Manager;

namespace TierneyJohn.MiChangSheng.JTools_Next.DialogEnv.Spine;

[DialogEnvQuery("JT_GetSpineSkin")]
[DialogEnvQuery("JT_获取当前Spine数据皮肤")]
public class GetSpineSkin : IDialogEnvQuery
{
    public object Execute(DialogEnvQueryContext context)
    {
        var id = context.GetValue<int>(0);
        return SpineManager.Inst.GetSpineSkin(id);
    }
}