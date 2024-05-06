using HarmonyLib;
using SkySwordKill.NextModEditor.Mod;
using TierneyJohn.MiChangSheng.JTools;
using TierneyJohn.MiChangSheng.JTools_Next.Data;

namespace TierneyJohn.MiChangSheng.JTools_Next.Patch;

[HarmonyPatch(typeof(ModEditorManager))]
public class ModEditorPatch
{
    [HarmonyPatch(nameof(ModEditorManager.Init)), HarmonyPostfix]
    private static void Init_Postfix()
    {
        if (!JToolsCoreMain.UseNextExtension.Value) return;
        BuffSeidMetaData.Inst.Load();
        ItemSeidMetaData.Inst.Load();
        SkillSeidMetaData.Inst.Load();
    }
}