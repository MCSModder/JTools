using HarmonyLib;
using TierneyJohn.MiChangSheng.JTools.Manager;

namespace TierneyJohn.MiChangSheng.JTools.Patch;

/// <summary>
/// 数据存读档补丁
/// </summary>
[HarmonyPatch(typeof(YSNewSaveSystem))]
public class ArchivePatch
{
    [HarmonyPatch(nameof(YSNewSaveSystem.SaveAvatar)), HarmonyPostfix]
    private static void SaveAvatar_Postfix() { ArchiveManager.Inst.Saved(); }

    [HarmonyPatch(nameof(YSNewSaveSystem.LoadSave)), HarmonyPostfix]
    private static void LoadSave_Postfix() { ArchiveManager.Inst.Loaded(); }
}