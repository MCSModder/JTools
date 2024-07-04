using SkySwordKill.Next.DialogSystem;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools_Next.DialogEnv.Fight;

/// <summary>
/// 获取上一次的战斗结果 (1: 常规 2: 战斗胜利 3: 战斗失败 4: 战斗逃跑)
/// </summary>
[DialogEnvQuery("JT_GetFightResult")]
[DialogEnvQuery("JT_获取战斗结果")]
public class GetFightResult : IDialogEnvQuery
{
    public object Execute(DialogEnvQueryContext context) { return (int)FightUtil.GetFightResult(); }
}