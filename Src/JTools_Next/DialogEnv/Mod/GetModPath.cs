using SkySwordKill.Next.DialogSystem;
using TierneyJohn.MiChangSheng.JTools_Next.Util;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools_Next.DialogEnv.Mod;

[DialogEnvQuery("JT_GetModPath")]
[DialogEnvQuery("JT_获取Mod路径")]
public class GetModPath : IDialogEnvQuery
{
    public object Execute(DialogEnvQueryContext context)
    {
        var steamId = context.GetValue<string>(0);
        return steamId.GetModPath();
    }
}