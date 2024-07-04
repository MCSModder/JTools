using SkySwordKill.Next.DialogSystem;
using TierneyJohn.MiChangSheng.JTools_Next.Util;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools_Next.DialogEnv.Mod;

[DialogEnvQuery("JT_GetModName")]
[DialogEnvQuery("JT_获取Mod名称")]
public class GetModName : IDialogEnvQuery
{
    public object Execute(DialogEnvQueryContext context)
    {
        var steamId = context.GetValue<string>(0);
        return ulong.Parse(steamId).GetModName();
    }
}