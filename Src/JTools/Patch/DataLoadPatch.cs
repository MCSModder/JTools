using System.Collections.Generic;
using HarmonyLib;
using TierneyJohn.MiChangSheng.JTools.Manager;
using YSGame.TuJian;

namespace TierneyJohn.MiChangSheng.JTools.Patch;

[HarmonyPatch]
public class DataLoadPatch
{
    [HarmonyPatch(typeof(YSJSONHelper), nameof(YSJSONHelper.InitJSONClassData)), HarmonyPrefix]
    private static void YSJSONHelper_InitJSONClassData_Prefix() { DataManager.Inst.LoadData(); }

    [HarmonyPatch(typeof(NpcJieSuanManager), nameof(NpcJieSuanManager.InitCyData)), HarmonyPrefix]
    private static void Prefix() { DataManager.Inst.LoadAvatar(); }

    [HarmonyPatch(typeof(TuJianDB), "InitRuleTuJianData"), HarmonyPostfix]
    private static void TuJianDB_InitRuleTuJianData_Postfix()
    {
        foreach (var affix in DataManager.Inst.affixEntities)
        {
            TuJianDB.RuleCiZhuiIndexData[(int)affix.AffixType].Add(affix.Id);
            TuJianDB.RuleDoubleData.TryAdd(affix.Id, new DoubleItem(affix.Name, affix.Desc));
        }

        foreach (var gameplay in DataManager.Inst.gameplayEntities)
        {
            TuJianDB.RuleTuJianTypeChildDescData[506].Add(gameplay.Index, gameplay.Desc);
            TuJianDB.RuleTuJianFilterData[506].Add(new Dictionary<int, string> { { gameplay.Index, gameplay.Name } });
        }
    }
}