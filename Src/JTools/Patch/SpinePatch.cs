using System.Linq;
using Fungus;
using HarmonyLib;
using JiaoYi;
using PaiMai;
using TierneyJohn.MiChangSheng.JTools.Manager;
using TierneyJohn.MiChangSheng.JTools.Model.Spine;
using UnityEngine;
using UnityEngine.SceneManagement;
using Avatar = KBEngine.Avatar;
using GameObject = UnityEngine.GameObject;

namespace TierneyJohn.MiChangSheng.JTools.Patch;

/// <summary>
/// Spine 角色立绘补丁
/// </summary>
[HarmonyPatch]
public class SpinePatch
{
    [HarmonyPatch(typeof(SayDialog), nameof(SayDialog.SetCharacterImage)), HarmonyPrefix]
    private static bool SayDialog_SetCharacterImage_Prefix(int characterID)
    {
        if (SayDialog.ActiveSayDialog == null) return true;

        var parent = SayDialog.ActiveSayDialog.transform.GetChild(1);
        var face = parent.GetChild(1);

        var spines = SpineManager.Inst.InitSpines(parent, face);
        SpineManager.Inst.CloseAllSpines(spines);

        if (!SpineManager.Inst.CheckSpine(characterID))
        {
            face.gameObject.SetActive(true);
            return true;
        }

        SpineManager.Inst.CreateSpine(
            characterID,
            parent,
            face,
            SpineConfigMode.SayDialog,
            spine =>
            {
                spine.localPosition -= new Vector3(-36, 250);
                spine.localScale *= 0.36f;
                SpineManager.Inst.GetSkeletonGraphic(spine).localScale *= 0.8f;
            });

        parent.GetChild(4).gameObject.SetActive(true);
        return false;
    }

    [HarmonyPatch(typeof(UINPCJiaoHuPop), nameof(UINPCJiaoHuPop.RefreshUI)), HarmonyPostfix]
    private static void UINPCJiaoHuPop_RefreshUI_Postfix(UINPCJiaoHuPop __instance)
    {
        NpcPopManager.Inst.ChangePopButton(__instance);

        var id = UINPCJiaoHu.Inst.NowJiaoHuNPC.ID;
        var parent = __instance.transform.GetChild(11).GetChild(0).GetChild(0).GetChild(0);
        var face = parent.GetChild(0);

        SpineManager.Inst.CreateSpine(
            id,
            parent,
            face,
            SpineConfigMode.Pop,
            spine =>
            {
                spine.gameObject.AddComponent<SpineMask>().ChangeMode();
                spine.localPosition = new Vector3(20, -80);
            });
    }

    [HarmonyPatch(typeof(UINPCInfoPanel), nameof(UINPCInfoPanel.RefreshUI)), HarmonyPostfix]
    private static void UINPCInfoPanel_RefreshUI_Postfix(UINPCInfoPanel __instance)
    {
        var id = __instance.npc.ID;
        var parent = __instance.transform.GetChild(1).GetChild(0);
        var content = parent.GetChild(0).GetChild(0);

        SpineManager.Inst.CreateSpine(
            id,
            parent,
            content,
            SpineConfigMode.Info,
            spine =>
            {
                spine.gameObject.AddComponent<SpineMask>().ChangeMode();
                spine.localPosition = new Vector3(15, 0);
            });
    }

    [HarmonyPatch(typeof(JiaoYiUIMag), "InitNpcData"), HarmonyPostfix]
    private static void JiaoYiUIMag_InitNpcData_Postfix()
    {
        var id = JiaoYiUIMag.Inst.NpcId;
        var parent = JiaoYiUIMag.Inst.transform.GetChild(2);
        var head = parent.GetChild(2);

        SpineManager.Inst.CreateSpine(
            id,
            parent,
            head,
            SpineConfigMode.Shop,
            spine =>
            {
                spine.gameObject.AddComponent<SpineMask>().ChangeMode(SpineMaskMode.小头像);
                spine.localPosition += new Vector3(6, 5);
            });
    }

    [HarmonyPatch(typeof(AvatarUI), nameof(AvatarUI.Init)), HarmonyPostfix]
    private static void AvatarUI_Init_Postfix(AvatarUI __instance)
    {
        var id = Traverse.Create(__instance).Field("_avatar").GetValue<PaiMaiAvatar>().NpcId;
        var parent1 = __instance.transform.GetChild(0);
        var bg1 = parent1.GetChild(0);
        var head1 = parent1.GetChild(1);

        SpineManager.Inst.CreateSpine(
            id,
            parent1,
            head1,
            SpineConfigMode.Auction,
            spine =>
            {
                spine.gameObject.AddComponent<SpineMask>().ChangeMode();
                spine.localPosition -= new Vector3(-10, 10);
                parent1.GetChild(5).SetAsFirstSibling();
                bg1.transform.SetAsFirstSibling();
            });
    }

    [HarmonyPatch(typeof(AvatarUI), nameof(AvatarUI.SetState)), HarmonyPostfix]
    private static void AvatarUI_SetState_Postfix(PaiMaiAvatar.StateType state, AvatarUI __instance)
    {
        if (state != PaiMaiAvatar.StateType.放弃) return;

        var id = Traverse.Create(__instance).Field("_avatar").GetValue<PaiMaiAvatar>().NpcId;
        var parent2 = __instance.transform.GetChild(1);
        var bg2 = parent2.GetChild(0);
        var head2 = parent2.GetChild(1);

        SpineManager.Inst.CreateSpine(
            id,
            parent2,
            head2,
            SpineConfigMode.Auction,
            spine =>
            {
                spine.gameObject.AddComponent<SpineMask>().ChangeMode();
                spine.localPosition -= new Vector3(-10, 10);
                parent2.GetChild(6).SetAsFirstSibling();
                bg2.transform.SetAsFirstSibling();
            });
    }

    [HarmonyPatch(typeof(UINPCSVItem), nameof(UINPCSVItem.RefreshUI)), HarmonyPostfix]
    private static void UINPCSVItem_RefreshUI_Postfix(UINPCSVItem __instance)
    {
        var id = __instance.NPCData.ID;
        var parent = __instance.transform;
        var head = parent.GetChild(1);

        SpineManager.Inst.CreateSpine(
            id,
            parent,
            head,
            SpineConfigMode.Left,
            spine =>
            {
                spine.gameObject.AddComponent<SpineMask>().ChangeMode(SpineMaskMode.小头像);
                spine.localScale *= 5;
            });
    }

    [HarmonyPatch(typeof(NpcController), nameof(NpcController.Init)), HarmonyPostfix]
    private static void NpcController_Init_Postfix(NpcController __instance)
    {
        var id = LunDaoManager.inst.npcId;
        var parent = __instance.transform.GetChild(0).GetChild(0);
        var content = parent.GetChild(0).GetChild(0);

        SpineManager.Inst.CreateSpine(
            id,
            parent,
            content,
            SpineConfigMode.Tao,
            spine =>
            {
                spine.gameObject.AddComponent<SpineMask>().ChangeMode();
                spine.localPosition = new Vector3(15, 0);
            });
    }

    [HarmonyPatch(typeof(FpUIMag), nameof(FpUIMag.Init)), HarmonyPostfix]
    private static void FpUIMag_Init_Postfix()
    {
        var id = FpUIMag.inst.npcId;
        var parent = FpUIMag.inst.transform.GetChild(2).GetChild(0);
        var content = parent.GetChild(0).GetChild(0);

        SpineManager.Inst.CreateSpine(
            id,
            parent,
            content,
            SpineConfigMode.FightPop,
            spine =>
            {
                spine.gameObject.AddComponent<SpineMask>().ChangeMode();
                parent.GetChild(2).SetAsFirstSibling();
            });
    }

    [HarmonyPatch(typeof(RoundManager), nameof(RoundManager.initAvatarInfo)), HarmonyPostfix]
    private static void RoundManager_initAvatarInfo_Postfix(Avatar avatar)
    {
        if (avatar.isPlayer()) return;

        var id = Tools.instance.MonstarID;
        var root = SceneManager.GetActiveScene().GetRootGameObjects();
        var parent = root.First(go => go.name.Equals("Avatar_11")).transform.GetChild(0);
        var face = parent.GetChild(0);

        SpineManager.Inst.CreateSpine(
            id,
            parent,
            face,
            SpineConfigMode.Fight,
            spine =>
            {
                SpineManager.Inst.GetSkeletonGraphic(spine).localPosition = new Vector3(500, -150);
                SpineManager.Inst.GetSkeletonGraphic(spine).localScale = new Vector3(0.1f, 0.1f, 1f);
                SpineManager.Inst.GetSkeletonGraphic(spine).localRotation = new Quaternion(0, 180, 0, 0);
                spine.gameObject.AddComponent<SpineFightControl>();
                ((GameObject)avatar.renderObj).transform.localPosition += new Vector3(0, 0, 10);
            });
    }
}