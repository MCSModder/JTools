using HarmonyLib;
using SkySwordKill.NextModEditor.Mod;
using TierneyJohn.MiChangSheng.JTools;
using TierneyJohn.MiChangSheng.JTools_Next.Data;

namespace TierneyJohn.MiChangSheng.JTools_Next.Patch
{
    [HarmonyPatch(typeof(ModEditorManager), nameof(ModEditorManager.Init))]
    public class ModEditorPatch
    {
        private static void Postfix()
        {
            if (JToolsCoreMain.UseNextExtension.Value) ModSeidMetaData.Inst.Load();
        }
    }
}