using GUIPackage;
using HarmonyLib;
using JSONClass;
using Tab;
using TierneyJohn.MiChangSheng.JTools.Manager;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools.Patch;

[HarmonyPatch(typeof(item))]
public class ItemSeidPatch
{
    [HarmonyPatch(nameof(item.gongneng)), HarmonyPrefix]
    private static bool GongNeng_Prefix(item __instance)
    {
        var itemId = __instance.itemID;
        if (!_ItemJsonData.DataDict[itemId].seid.Contains(40)) return true;

        // 调用剧情
        var json = jsonData.instance.ItemsSeidJsonData[40][itemId.ToString()];
        var flowchartName = json.GetFieldStr("flowchart");
        var blockName = json.GetFieldStr("block");
        FungusManager.Inst.TryGetFlowchart(flowchartName, out var flowchart);
        flowchart.ExecuteBlock(blockName);

        // 关闭背包
        if (SingletonMono<TabUIMag>.Instance != null) SingletonMono<TabUIMag>.Instance.TryEscClose();
        return false;
    }
}