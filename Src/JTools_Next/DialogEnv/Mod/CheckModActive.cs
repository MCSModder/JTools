using SkySwordKill.Next.DialogSystem;
using TierneyJohn.MiChangSheng.JTools_Next.Util;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools_Next.DialogEnv.Mod;

[DialogEnvQuery("JT_CheckModActive")]
[DialogEnvQuery("JT_检测Mod是否启用")]
public class CheckModActive : IDialogEnvQuery
{
    public object Execute(DialogEnvQueryContext context)
    {
        var steamId = context.GetValue<string>(0);
        return steamId.CheckModActive();
    }
}