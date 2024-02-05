using System.Linq;
using HarmonyLib;
using KBEngine;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools.Patch
{
    [HarmonyPatch(typeof(Buff))]
    public class BuffSeidPatch
    {
        private static bool UseSeidExtension => JToolsCoreMain.UseSeidExtension.Value;

        [HarmonyPrefix, HarmonyPatch(nameof(Buff.CanRealizeSeid))]
        public static bool PrefixCanRealizeSeid(
            Avatar _avatar,
            int nowSeid,
            Buff __instance,
            ref bool __result)
        {
            if (!UseSeidExtension) return true;

            switch (nowSeid)
            {
                case 320:
                    __result = CanRealizeSeid320(nowSeid, _avatar, __instance);
                    $"自定义 BuffSeid320 判定结果: {__result}".Log();
                    return false;
                case 327:
                    __result = CanRealizeSeid327(nowSeid, _avatar, __instance);
                    $"自定义 BuffSeid327 判定结果: {__result}".Log();
                    return false;
                case 328:
                    __result = CanRealizeSeid328(nowSeid, _avatar, __instance);
                    $"自定义 BuffSeid328 判定结果: {__result}".Log();
                    return false;
                default:
                    return true;
            }
        }

        [HarmonyPrefix, HarmonyPatch(nameof(Buff.loopRealizeSeid))]
        public static bool PrefixLoopRealizeSeid(
            int seid,
            Entity _avatar,
            Buff __instance)
        {
            if (!UseSeidExtension) return true;

            var avatar = (Avatar)_avatar;
            switch (seid)
            {
                case 201:
                    // Seid 201 判定增强处理
                    return Traverse.Create(RoundManager.instance.gameObject.GetComponent<JieYingManager>())
                        .Field("State").GetValue<int>() == 2;
                case 316:
                    ListRealizeSeid316(seid, avatar, __instance);
                    return false;
                case 317:
                    ListRealizeSeid317(seid, avatar, __instance);
                    return false;
                case 318:
                    ListRealizeSeid318(seid, avatar, __instance);
                    return false;
                case 319:
                    ListRealizeSeid319(seid, avatar, __instance);
                    return false;
                case 321:
                    ListRealizeSeid321(seid, avatar, __instance);
                    return false;
                case 322:
                    ListRealizeSeid322(seid, avatar, __instance);
                    return false;
                case 323:
                    ListRealizeSeid323(seid, avatar, __instance);
                    return false;
                case 324:
                    ListRealizeSeid324(seid, avatar, __instance);
                    return false;
                case 325:
                    ListRealizeSeid325(seid, avatar, __instance);
                    return false;
                case 326:
                    ListRealizeSeid326(seid, avatar, __instance);
                    return false;
                default:
                    return true;
            }
        }

        /// <summary>
        /// 自定义 Buff Seid 320 若角色背包拥有指定数量的对应物品,则触发后续特效
        /// </summary>
        /// <param name="seid">320</param>
        /// <param name="avatar">待修改角色</param>
        /// <param name="instance">Buff 对象实例</param>
        /// <returns>判定结果</returns>
        private static bool CanRealizeSeid320(int seid, Avatar avatar, Buff instance)
        {
            seid.RealizeSeidInfo(null, "Buff");

            var itemList = instance.getSeidJson(seid).GetFieldList("value1");
            var countList = instance.getSeidJson(seid).GetFieldList("value2");

            if (itemList.Count == 0)
            {
                seid.RealizeSeidWarn("value1 列表数据为空");
                return false;
            }

            if (countList.Count == 0)
            {
                seid.RealizeSeidWarn("value2 列表数据为空");
                return false;
            }

            if (itemList.Count != countList.Count)
            {
                seid.RealizeSeidWarn("value1 和 value2 列表数据量不对等");
                return false;
            }

            var avatarItemList = avatar.itemList.values;

            for (var i = 0; i < itemList.Count; i++)
            {
                // 数据校验标识
                var flag = false;

                foreach (var unused in avatarItemList.Where(itemInfo =>
                             itemInfo.itemId == itemList[i] && itemInfo.itemCount >= countList[i]))
                {
                    // 已查询到指定数据
                    flag = true;
                }

                if (!flag)
                {
                    // 未查询到对应数量的物品,不满足判定条件
                    return false;
                }
            }

            // 所有条件均满足,可以执行后续特性
            return true;
        }

        /// <summary>
        /// 自定义 Buff Seid 327 将当前角色与对方的境界做比较，满足条件时触发后续特性
        /// </summary>
        /// <param name="seid">327</param>
        /// <param name="avatar">待修改角色</param>
        /// <param name="instance">Buff 对象实例</param>
        /// <returns>判定结果</returns>
        private static bool CanRealizeSeid327(int seid, Avatar avatar, Buff instance)
        {
            seid.RealizeSeidInfo(null, "Buff");
            var levelDiff = instance.getSeidJson(seid).GetFieldInt("value1");

            var avatarLevel = avatar.level;
            var otherLevel = avatar.OtherAvatar.level;

            if (levelDiff > 0 && avatarLevel >= otherLevel + levelDiff)
            {
                return true;
            }

            if (levelDiff < 0 && avatarLevel <= otherLevel + levelDiff)
            {
                return true;
            }

            return avatarLevel == otherLevel;
        }

        /// <summary>
        /// 自定义 Buff Seid 328 将当前角色与对方的大境界做比较，满足条件时触发后续特性
        /// </summary>
        /// <param name="seid">328</param>
        /// <param name="avatar">待修改角色</param>
        /// <param name="instance">Buff 对象实例</param>
        /// <returns>判定结果</returns>
        private static bool CanRealizeSeid328(int seid, Avatar avatar, Buff instance)
        {
            seid.RealizeSeidInfo(null, "Buff");
            var levelDiff = instance.getSeidJson(seid).GetFieldInt("value1");

            var avatarLevel = avatar.getLevelType();
            var otherLevel = avatar.OtherAvatar.getLevelType();

            if (levelDiff > 0 && avatarLevel >= otherLevel + levelDiff)
            {
                return true;
            }

            if (levelDiff < 0 && avatarLevel <= otherLevel + levelDiff)
            {
                return true;
            }

            return avatarLevel == otherLevel;
        }

        /// <summary>
        /// 自定义 Buff Seid 316 将角色血量修改为固定值
        /// </summary>
        /// <param name="seid">316</param>
        /// <param name="avatar">待修改角色</param>
        /// <param name="instance">Buff 对象实例</param>
        private static void ListRealizeSeid316(int seid, Avatar avatar, Buff instance)
        {
            seid.RealizeSeidInfo(null, "Buff");

            var hp = instance.getSeidJson(seid).GetFieldInt("value1");
            avatar.SafeSetHp(hp);
        }

        /// <summary>
        /// 自定义 Buff Seid 317 移除玩家当前战斗面板指定技能
        /// </summary>
        /// <param name="seid">317</param>
        /// <param name="avatar">待修改角色</param>
        /// <param name="instance">Buff 对象实例</param>
        private static void ListRealizeSeid317(int seid, Avatar avatar, Buff instance)
        {
            seid.RealizeSeidInfo(null, "Buff");

            if (!avatar.isPlayer())
            {
                seid.RealizeSeidWarn("当前修改对象并非玩家,已跳过执行");
                return;
            }

            var skillList = instance.getSeidJson(seid).GetFieldList("value1");

            if (skillList.Count == 0)
            {
                seid.RealizeSeidWarn("value1 列表数据为空");
                return;
            }

            foreach (var skillId in skillList)
            {
                avatar.FightClearSkill(skillId);
            }
        }

        /// <summary>
        /// 自定义 Buff Seid 318 在当前战斗面板添加指定技能
        /// </summary>
        /// <param name="seid">318</param>
        /// <param name="avatar">待修改角色</param>
        /// <param name="instance">Buff 对象实例</param>
        private static void ListRealizeSeid318(int seid, Avatar avatar, Buff instance)
        {
            seid.RealizeSeidInfo(null, "Buff");

            if (!avatar.isPlayer())
            {
                seid.RealizeSeidWarn("当前修改对象并非玩家,已跳过执行");
                return;
            }

            var skillList = instance.getSeidJson(seid).GetFieldList("value1");

            if (skillList.Count == 0)
            {
                seid.RealizeSeidWarn("value1 列表数据为空");
                return;
            }

            foreach (var skillId in skillList)
            {
                avatar.FightAddSkill(skillId);
            }
        }

        /// <summary>
        /// 自定义 Buff Seid 319 在当前战斗面板替换指定技能
        /// </summary>
        /// <param name="seid">319</param>
        /// <param name="avatar">待修改角色</param>
        /// <param name="instance">Buff 对象实例</param>
        private static void ListRealizeSeid319(int seid, Avatar avatar, Buff instance)
        {
            seid.RealizeSeidInfo(null, "Buff");

            if (!avatar.isPlayer())
            {
                seid.RealizeSeidWarn("当前修改对象并非玩家,已跳过执行");
                return;
            }

            var skillList = instance.getSeidJson(seid).GetFieldList("value1");
            var toSkillList = instance.getSeidJson(seid).GetFieldList("value2");

            if (skillList.Count == 0)
            {
                seid.RealizeSeidWarn("value1 列表数据为空");
                return;
            }

            if (toSkillList.Count == 0)
            {
                seid.RealizeSeidWarn("value2 列表数据为空");
                return;
            }

            if (skillList.Count != toSkillList.Count)
            {
                seid.RealizeSeidWarn("value1 和 value2 列表数据量不对等");
                return;
            }

            for (var i = 0; i < skillList.Count; i++)
            {
                avatar.FightChangeSkill(skillList[i], toSkillList[i]);
            }
        }

        /// <summary>
        /// 自定义 Buff Seid 321 移除角色背包指定数量物品
        /// </summary>
        /// <param name="seid">321</param>
        /// <param name="avatar">待修改角色</param>
        /// <param name="instance">Buff 对象实例</param>
        private static void ListRealizeSeid321(int seid, Avatar avatar, Buff instance)
        {
            seid.RealizeSeidInfo(null, "Buff");

            var itemList = instance.getSeidJson(seid).GetFieldList("value1");
            var countList = instance.getSeidJson(seid).GetFieldList("value2");

            if (itemList.Count == 0)
            {
                seid.RealizeSeidWarn("value1 列表数据为空");
                return;
            }

            if (countList.Count == 0)
            {
                seid.RealizeSeidWarn("value2 列表数据为空");
                return;
            }

            if (itemList.Count != countList.Count)
            {
                seid.RealizeSeidWarn("value1 和 value2 列表数据量不对等");
                return;
            }

            var avatarItemList = avatar.itemList.values;

            var uuidList = itemList.Select(item => avatarItemList.Find(itemInfo => itemInfo.itemId == item).uuid)
                .ToList();

            if (uuidList.Count != countList.Count)
            {
                seid.RealizeSeidWarn("检索物品数据量不对等");
                return;
            }

            for (var i = 0; i < uuidList.Count; i++)
            {
                avatar.removeItem(uuidList[i], countList[i]);
                seid.RealizeSeidInfo($"已移除角色物品 {itemList[i]} : {countList[i]}");
            }
        }

        /// <summary>
        /// 自定义 Buff Seid 322 移除玩家背包指定数量物品 (不论改buff由谁触发)
        /// </summary>
        /// <param name="seid">322</param>
        /// <param name="avatar">玩家</param>
        /// <param name="instance">Buff 对象实例</param>
        private static void ListRealizeSeid322(int seid, Avatar avatar, Buff instance)
        {
            seid.RealizeSeidInfo(null, "Buff");

            if (!avatar.isPlayer())
            {
                seid.RealizeSeidWarn("当前修改对象并非玩家,正在修改目标对象");
                avatar = PlayerEx.Player;
            }

            var itemList = instance.getSeidJson(seid).GetFieldList("value1");
            var countList = instance.getSeidJson(seid).GetFieldList("value2");

            if (itemList.Count == 0)
            {
                seid.RealizeSeidWarn("value1 列表数据为空");
                return;
            }

            if (countList.Count == 0)
            {
                seid.RealizeSeidWarn("value2 列表数据为空");
                return;
            }

            if (itemList.Count != countList.Count)
            {
                seid.RealizeSeidWarn("value1 和 value2 列表数据量不对等");
                return;
            }

            var avatarItemList = avatar.itemList.values;

            var uuidList = itemList.Select(item => avatarItemList.Find(itemInfo => itemInfo.itemId == item).uuid)
                .ToList();

            if (uuidList.Count != countList.Count)
            {
                seid.RealizeSeidWarn("检索物品数据量不对等");
                return;
            }

            for (var i = 0; i < uuidList.Count; i++)
            {
                avatar.removeItem(uuidList[i], countList[i]);
                seid.RealizeSeidInfo($"已移除玩家物品 {itemList[i]} : {countList[i]}");
            }
        }

        /// <summary>
        /// 自定义 Buff Seid 323 给角色背包添加指定数量物品
        /// </summary>
        /// <param name="seid">323</param>
        /// <param name="avatar">待修改角色</param>
        /// <param name="instance">Buff 对象实例</param>
        private static void ListRealizeSeid323(int seid, Avatar avatar, Buff instance)
        {
            seid.RealizeSeidInfo(null, "Buff");

            var itemList = instance.getSeidJson(seid).GetFieldList("value1");
            var countList = instance.getSeidJson(seid).GetFieldList("value2");

            if (itemList.Count == 0)
            {
                seid.RealizeSeidWarn("value1 列表数据为空");
                return;
            }

            if (countList.Count == 0)
            {
                seid.RealizeSeidWarn("value2 列表数据为空");
                return;
            }

            if (itemList.Count != countList.Count)
            {
                seid.RealizeSeidWarn("value1 和 value2 列表数据量不对等");
                return;
            }

            for (var i = 0; i < itemList.Count; i++)
            {
                avatar.addItem(itemList[i], null, countList[i]);
                seid.RealizeSeidInfo($"已添加角色物品 {itemList[i]} : {countList[i]}");
            }
        }

        /// <summary>
        /// 自定义 Buff Seid 324 给玩家背包添加指定数量物品 (不论改buff由谁触发)
        /// </summary>
        /// <param name="seid">324</param>
        /// <param name="avatar">玩家</param>
        /// <param name="instance">Buff 对象实例</param>
        private static void ListRealizeSeid324(int seid, Avatar avatar, Buff instance)
        {
            seid.RealizeSeidInfo(null, "Buff");

            if (!avatar.isPlayer())
            {
                seid.RealizeSeidWarn("当前修改对象并非玩家,正在修改目标对象");
                avatar = PlayerEx.Player;
            }

            var itemList = instance.getSeidJson(seid).GetFieldList("value1");
            var countList = instance.getSeidJson(seid).GetFieldList("value2");

            if (itemList.Count == 0)
            {
                seid.RealizeSeidWarn("value1 列表数据为空");
                return;
            }

            if (countList.Count == 0)
            {
                seid.RealizeSeidWarn("value2 列表数据为空");
                return;
            }

            if (itemList.Count != countList.Count)
            {
                seid.RealizeSeidWarn("value1 和 value2 列表数据量不对等");
                return;
            }

            for (var i = 0; i < itemList.Count; i++)
            {
                avatar.addItem(itemList[i], null, countList[i]);
                seid.RealizeSeidInfo($"已添加玩家物品 {itemList[i]} : {countList[i]}");
            }
        }

        /// <summary>
        /// 自定义 Buff Seid 325 随机释放神通
        /// </summary>
        /// <param name="seid">325</param>
        /// <param name="avatar">释放角色</param>
        /// <param name="instance">Buff 对象实例</param>
        private static void ListRealizeSeid325(int seid, Avatar avatar, Buff instance)
        {
            seid.RealizeSeidInfo(null, "Buff");

            var skillList = instance.getSeidJson(seid).GetFieldList("value1");

            var skillCount = skillList.Count;

            if (skillCount == 0)
            {
                seid.RealizeSeidWarn("value1 列表数据为空");
                return;
            }

            avatar.FightUseSkill(skillList.GetRandomOne(), instance);
        }

        /// <summary>
        /// 自定义 Buff Seid 326 连续释放多个神通
        /// </summary>
        /// <param name="seid">326</param>
        /// <param name="avatar">释放角色</param>
        /// <param name="instance">Buff 对象实例</param>
        private static void ListRealizeSeid326(int seid, Avatar avatar, Buff instance)
        {
            seid.RealizeSeidInfo(null, "Buff");

            var skillList = instance.getSeidJson(seid).GetFieldList("value1");

            var skillCount = skillList.Count;

            if (skillCount == 0)
            {
                seid.RealizeSeidWarn("value1 列表数据为空");
                return;
            }

            foreach (var skillId in skillList)
            {
                avatar.FightUseSkill(skillId, instance);
            }
        }
    }
}