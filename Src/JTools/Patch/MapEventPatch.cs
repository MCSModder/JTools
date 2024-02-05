using System.Collections.Generic;
using Fungus;
using HarmonyLib;
using KBEngine;
using QiYu;
using TierneyJohn.MiChangSheng.JTools.Manager;
using TierneyJohn.MiChangSheng.JTools.Util;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using YSGame;
using Avatar = KBEngine.Avatar;
using FungusManager = Fungus.FungusManager;
using GameObject = UnityEngine.GameObject;

namespace TierneyJohn.MiChangSheng.JTools.Patch
{
    /// <summary>
    /// 大地图事件补丁
    /// </summary>
    [HarmonyPatch]
    public class MapEventPatch
    {
        /// <summary>
        /// 地图节点事件执行补丁
        /// 后续会改为 IL 修补方式，减少改动范围
        /// </summary>
        /// <returns>固定拦截原始方法</returns>
        [HarmonyPrefix]
        [HarmonyPatch(typeof(MapComponent), nameof(MapComponent.NewEventRandom))]
        private static bool NewEventRandomPrefix(MapComponent __instance)
        {
            MapEventManager.Inst.RefreshMapEventData();
            if (!__instance.CanClick())
                return false;
            __instance.fuBenSetClick();
            __instance.NewMovaAvatar();
            if (__instance.IsStatic)
                return false;
            var next = new Queue<UnityAction>();
            next.Enqueue(UnityAction);
            YSFuncList.Ints.AddFunc(next);
            return false;

            void UnityAction()
            {
                var avatar = (Avatar)KBEngineApp.app.player();
                var instanceName = __instance.GetType().Name;
                var nodeIndex = __instance.NodeIndex;
                var nodeData = avatar.AllMapRandomNode.GetField(nodeIndex.ToString());

                var taskID = avatar.nomelTaskMag.AutoAllMapPlaceHasNTask(new List<int> { nodeIndex });
                if (taskID != -1)
                {
                    var jsonObject = avatar.nomelTaskMag.IsNTaskZiXiangInLuJin(taskID, new List<int> { nodeIndex });
                    var childIdSuiJiJson = avatar.nomelTaskMag.GetNowChildIDSuiJiJson(taskID);
                    if (jsonObject.GetFieldInt("type") == 5)
                    {
                        avatar.randomFuBenMag.GetInRandomFuBen(nodeIndex);
                    }
                    else
                    {
                        GlobalValue.Set(401, childIdSuiJiJson.GetFieldInt("Value"), $"{instanceName}.EventRandom");
                        GlobalValue.Set(402, taskID, $"{instanceName}.EventRandom");
                        Object.Instantiate(Resources.Load<GameObject>(
                            $"talkPrefab/TalkPrefab/talk{jsonObject.GetFieldStr("talkID")}"));
                    }

                    YSFuncList.Ints.Continue();
                }
                else
                {
                    var eventId = nodeData.GetFieldInt("EventId");
                    var eventIdKey = eventId.ToString();

                    switch (nodeData.GetFieldInt("Type"))
                    {
                        case 2:
                        case 5:
                            if (FungusManager.Instance.jieShaBlock == null)
                            {
                                FungusManager.Instance.jieShaBlock = Object.Instantiate(
                                        Resources.Load<GameObject>("talkPrefab/TalkPrefab/talk4010"))
                                    .GetComponentInChildren<Flowchart>();
                            }
                            else if (GlobalValue.Get(171, $"{instanceName}.EventRandom") == 1)
                            {
                                GlobalValue.Set(171, 0, $"{instanceName}.EventRandom");
                            }
                            else
                            {
                                FungusManager.Instance.jieShaBlock.Reset(false, true);
                                FungusManager.Instance.jieShaBlock.ExecuteBlock("Splash");
                            }

                            __instance.ResteAllMapNode();
                            Tools.instance.getPlayer().AllMapSetNode();
                            YSFuncList.Ints.Continue();
                            break;
                        default:
                            if (eventId == 0)
                            {
                                goto case 2;
                            }

                            // 执行自定义大地图事件判定
                            if (MapEventManager.Inst.HasMapEventData(eventId))
                            {
                                // 自定义逻辑 - 直接调用事件对话框
                                // 后续自定义逻辑通过 QiYuUIMag 实现
                                __instance.addOption(eventId);
                                __instance.ResteAllMapNode();
                                Tools.instance.getPlayer().AllMapSetNode();
                                YSFuncList.Ints.Continue();
                                break;
                            }

                            // 原始逻辑
                            var mapRandomData = __instance.MapRandomJsonData.GetField(eventIdKey);
                            var eventData = mapRandomData.GetFieldInt("EventData");

                            if (mapRandomData.GetFieldInt("once") != 0)
                            {
                                if (!avatar.SuiJiShiJian.HasField(Tools.getScreenName()))
                                    avatar.SuiJiShiJian.AddField(Tools.getScreenName(), JSONObject.arr);
                                avatar.SuiJiShiJian[Tools.getScreenName()].Add(eventId);
                            }

                            switch (mapRandomData.GetFieldInt("EventList"))
                            {
                                case 0:
                                    Object.Instantiate(
                                        Resources.Load<GameObject>($"talkPrefab/TalkPrefab/talk{eventData}"));
                                    break;
                                case 1:
                                    __instance.addOption(eventData);
                                    break;
                                case 2:
                                    Tools.instance.MonstarID = mapRandomData.GetFieldInt("MosterID");
                                    Object.Instantiate(
                                        Resources.Load<GameObject>($"talkPrefab/FightPrefab/Fight{eventData}"));
                                    break;
                                case 3:
                                    __instance.OpenDadituCaiJi();
                                    break;
                            }

                            __instance.ResteAllMapNode();
                            Tools.instance.getPlayer().AllMapSetNode();
                            YSFuncList.Ints.Continue();
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 修正 大地图奇遇事件 对话框数据显示逻辑
        /// </summary>
        /// <returns></returns>
        [HarmonyPrefix]
        [HarmonyPatch(typeof(QiYuUIMag), nameof(QiYuUIMag.Show))]
        private static bool ShowPrefix(int id, QiYuUIMag __instance)
        {
            if (!MapEventManager.Inst.HasMapEventData(id))
            {
                // 当前事件不在自定义事件库中，回归原始方法
                return true;
            }

            // 数据挖掘
            var inst = Traverse.Create(__instance);
            var eventName = inst.Field("EventName").GetValue<Text>();
            var eventContent = inst.Field("EventContent").GetValue<Text>();
            var option = inst.Field("Option").GetValue<GameObject>();
            var okBtn = inst.Field("OkBtn").GetValue<GameObject>();
            var optionList = inst.Field("OptionList").GetValue<Transform>();

            LoadUIMag(id, eventName, eventContent, optionList, option, okBtn);
            return false;
        }

        /// <summary>
        /// QiYuUIMag 数据加载方法
        /// </summary>
        /// <param name="eventId">事件编号</param>
        /// <param name="eventName">QiYuUIMag 组件</param>
        /// <param name="eventContent">QiYuUIMag 组件</param>
        /// <param name="optionList">QiYuUIMag 组件</param>
        /// <param name="option">QiYuUIMag 组件</param>
        /// <param name="okBtn">QiYuUIMag 组件</param>
        private static void LoadUIMag(int eventId, Text eventName, Text eventContent, Transform optionList,
            GameObject option, GameObject okBtn)
        {
            Tools.ClearChild(optionList);
            var mapEventData = MapEventManager.Inst.GetMapEventData(eventId);
            var optionsCount = mapEventData.Options.Count;

            if (mapEventData.isFinal)
            {
                mapEventData.Action.Invoke();
                QiYuUIMag.Inst.Close();
                return;
            }

            // 数据替换
            eventName.text = mapEventData.title;
            eventContent.text = $"　　{mapEventData.content.Replace("{huanhang}", "\n")}";

            if (optionsCount == 0)
            {
                option.Inst(optionList).GetComponent<QiYuOption>().Init("完成事件", () =>
                {
                    mapEventData.Action.Invoke();
                    okBtn.SetActive(true);
                    optionList.gameObject.SetActive(false);
                });

                return;
            }

            mapEventData.Action.Invoke();

            if (optionsCount > 0)
            {
                var optionData = mapEventData.Options[0];
                option.Inst(optionList).GetComponent<QiYuOption>().Init(optionData.Item2, () =>
                {
                    LoadUIMag(optionData.Item1, eventName, eventContent, optionList, option, okBtn);
                    okBtn.SetActive(true);
                    optionList.gameObject.SetActive(false);
                });
            }

            if (optionsCount > 1)
            {
                var optionData = mapEventData.Options[1];
                option.Inst(optionList).GetComponent<QiYuOption>().Init(optionData.Item2, () =>
                {
                    LoadUIMag(optionData.Item1, eventName, eventContent, optionList, option, okBtn);
                    okBtn.SetActive(true);
                    optionList.gameObject.SetActive(false);
                });
            }

            if (optionsCount > 2)
            {
                var optionData = mapEventData.Options[2];
                option.Inst(optionList).GetComponent<QiYuOption>().Init(optionData.Item2, () =>
                {
                    LoadUIMag(optionData.Item1, eventName, eventContent, optionList, option, okBtn);
                    okBtn.SetActive(true);
                    optionList.gameObject.SetActive(false);
                });
            }

            // if (optionsCount > 3)
            // 原版事件对话框显示超过 3 个会造成显示问题，因此暂时舍弃后续选项
            // 后续优化后再考虑恢复功能
        }
    }
}