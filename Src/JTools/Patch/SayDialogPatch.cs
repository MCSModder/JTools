using Fungus;
using HarmonyLib;
using TierneyJohn.MiChangSheng.JTools.Util;
using UnityEngine;
using UnityEngine.UI;

namespace TierneyJohn.MiChangSheng.JTools.Patch
{
    /// <summary>
    /// 对话框角色定位修正补丁
    /// </summary>
    [HarmonyPatch(typeof(SayDialog))]
    public class SayDialogPatch
    {
        private const string DialogPatch = "DialogImage";

        /// <summary>
        /// SayDialog 初始化标记
        /// </summary>
        /// <param name="__state"></param>
        [HarmonyPatch(nameof(SayDialog.GetSayDialog)), HarmonyPrefix]
        private static void GetSayDialogPrefix(out bool __state)
        {
            __state = SayDialog.ActiveSayDialog == null;
        }

        /// <summary>
        /// SayDialogImage 定位调整
        /// </summary>
        /// <param name="__state"></param>
        [HarmonyPatch(nameof(SayDialog.GetSayDialog)), HarmonyPostfix]
        private static void GetSayDialogPostfix(bool __state)
        {
            if (__state) SayDialogImageOffset();
        }

        /// <summary>
        /// SayDialog 增强补丁
        /// </summary>
        [HarmonyPatch(nameof(SayDialog.SetCharacterImage)), HarmonyPostfix]
        private static void SetCharacterImagePostfix(Sprite image, int characterID)
        {
            if (image != null)
            {
                // JSay 方法执行结果，直接处理
                SayDialog.ActiveSayDialog.transform.GetChild(1).GetChild(1).GetChild(1).gameObject.SetActive(false);
                return;
            }

            // 尝试获取 DialogImage
            var sprite = ResManager.inst.LoadSprite($"{DialogPatch}/{NPCEx.NPCIDToOld(characterID)}");

            if (sprite == null) return;

            // 成功获取 DialogImage 执行 JSay 处理
            var img = SayDialog.ActiveSayDialog.transform.GetChild(1).GetChild(3).GetComponent<Image>();
            img.sprite = sprite;
            img.gameObject.SetActive(true);
            SayDialog.ActiveSayDialog.transform.GetChild(1).GetChild(1).GetChild(1).gameObject.SetActive(false);
        }

        /// <summary>
        /// SayDialogImage 定位调整
        /// 不会影响其他角色显示，SayDialogImage 是在独立层显示的
        /// </summary>
        private static void SayDialogImageOffset()
        {
            var rect = SayDialog.ActiveSayDialog.transform.GetChild(1).GetChild(3).GetComponent<Image>().rectTransform;
            rect.localPosition = rect.localPosition.ToNew(-100, -50);
            rect.localScale = new Vector3(1.7f, 1.7f, 1f);
            "SayDialog: 自定义角色对话显示位置修正".Log();
        }
    }
}