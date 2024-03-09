using HarmonyLib;
using TierneyJohn.MiChangSheng.JTools.Manager;

namespace TierneyJohn.MiChangSheng.JTools.Patch;

/// <summary>
/// 战斗相关剧情调用补丁
/// </summary>
[HarmonyPatch]
public class FightPatch
{
    /// <summary>
    /// 战斗时剧情调用补丁
    /// </summary>
    [HarmonyPatch(typeof(RoundManager), nameof(RoundManager.gameStart)), HarmonyPostfix]
    private static void RoundManager_gameStart_Postfix()
    {
        FungusManager.Inst.ExecuteInnerFightCache();
    }

    /// <summary>
    /// 战斗后剧情调用补丁
    /// </summary>
    [HarmonyPatch(typeof(CheckTool), nameof(CheckTool.showTalk)), HarmonyPrefix]
    private static bool CheckTool_showTalk_Prefix()
    {
        if (GlobalValue.GetTalk(0) != 444) return true;

        GlobalValue.SetTalk(0, 0);
        Tools.instance.CanShowFightUI = 0;
        FungusManager.Inst.ExecuteAfterFightCache();
        return false;
    }
}