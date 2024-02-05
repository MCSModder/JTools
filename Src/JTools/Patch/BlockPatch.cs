using Fungus;
using TierneyJohn.MiChangSheng.JTools.Fungus.JCommand;
using TierneyJohn.MiChangSheng.JTools.Util;
using FungusManager = TierneyJohn.MiChangSheng.JTools.Manager.FungusManager;

namespace TierneyJohn.MiChangSheng.JTools.Patch
{
    /// <summary>
    /// 暂不需要对 Block 进行额外操作，后续如果有相关需求再恢复该补丁
    /// </summary>
    // [HarmonyPatch(typeof(Block), "SetExecutionInfo")]
    public class BlockPatch
    {
        private static void Postfix(Block __instance)
        {
            var flowchart = __instance.GetFlowchart();
            var parent = flowchart.transform.parent;
            var name = parent == null ? flowchart.name : parent.name;
            var blockId = __instance.ItemId;

            var operates = FungusManager.Inst.GetAllOperates().FindAll(operate =>
                (operate.flowchartName.Equals(name) || $"{operate.flowchartName}(Clone)".Equals(name)) &&
                operate.blockId == blockId);

            foreach (var operate in operates)
            {
                var commands = __instance.commandList;

                for (var i = 0; i < commands.Count; i++)
                {
                    var command = commands[i];
                    if (operate.commandId != command.ItemId) continue;

                    var jCommand = command.gameObject.AddComponent<JCall>()
                        .Create(operate.targetBlock, operate.targetFlowchart);
                    if (jCommand == null) break;

                    jCommand.CommandIndex = command.CommandIndex;
                    jCommand.ItemId = command.ItemId;
                    commands[i] = jCommand;
                    operate.isExecute = true;
                    operate.FungusPatchSuccess();
                }
            }
        }
    }
}