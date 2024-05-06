using Fungus;
using HarmonyLib;
using TierneyJohn.MiChangSheng.JTools.Fungus.JCommand;
using TierneyJohn.MiChangSheng.JTools.Util;
using UnityEngine;
using FungusManager = TierneyJohn.MiChangSheng.JTools.Manager.FungusManager;

namespace TierneyJohn.MiChangSheng.JTools.Patch
{
    [HarmonyPatch(typeof(Flowchart), "CheckEventSystem")]
    public class FlowchartPatch
    {
        private static void Postfix(Component __instance)
        {
            var parent = __instance.transform.parent;
            var name = parent == null ? __instance.name : parent.name;
            var operates = FungusManager.Inst.GetAllOperates().FindAll(operate =>
                operate.flowchartName.Equals(name) || $"{operate.flowchartName}(Clone)".Equals(name));

            foreach (var operate in operates)
            {
                foreach (var block in __instance.GetComponents<Block>())
                {
                    if (operate.blockId != block.ItemId) continue;

                    var commands = block.commandList;

                    for (var i = 0; i < commands.Count; i++)
                    {
                        var command = commands[i];
                        if (operate.commandId != command.ItemId) continue;

                        var jCommand = operate.isPrefixPatch
                            ? block.gameObject.AddComponent<JCall>().Create(operate, CallMode.WaitUntilFinished)
                            : block.gameObject.AddComponent<JCall>().Create(operate);

                        if (jCommand == null) goto patchFlag;

                        if (operate.isPrefixPatch)
                        {
                            jCommand.CommandIndex = command.CommandIndex;
                            jCommand.ItemId = command.GetFlowchart().NextItemId();
                            commands.Insert(i, jCommand);

                            for (var j = i + 1; j < commands.Count; j++)
                            {
                                commands[j].CommandIndex++;
                            }
                        }
                        else
                        {
                            jCommand.CommandIndex = command.CommandIndex;
                            jCommand.ItemId = command.ItemId;
                            commands[i] = jCommand;
                        }

                        operate.isExecute = true;
                        operate.FungusPatchSuccess();
                        goto patchFlag;
                    }
                }

                patchFlag: ;
            }
        }
    }
}