using System.Collections.Generic;
using System.Linq;
using GUIPackage;
using HarmonyLib;
using JSONClass;
using KBEngine;
using TierneyJohn.MiChangSheng.JTools.Util;
using UnityEngine;
using YSGame.Fight;
using Avatar = KBEngine.Avatar;
using Skill = GUIPackage.Skill;

namespace TierneyJohn.MiChangSheng.JTools.Patch;

[HarmonyPatch(typeof(Skill))]
public class SkillSeidPatch
{
    private static bool UseSeidExtension => JToolsCoreMain.UseSeidExtension.Value;
    private static bool InitSkillHigh { get; set; }

    [HarmonyPatch(nameof(Skill.CanRealizeSeid)), HarmonyPrefix]
    private static bool CanRealizeSeid_Prefix(
        Avatar attaker,
        Avatar receiver,
        Skill __instance,
        ref bool __result
    )
    {
        if (!UseSeidExtension) return true;

        // 神通高亮效果处理
        if (!InitSkillHigh)
        {
            InitSkillHigh = true;
            jsonData.instance.hightLightSkillID.AddRange([187, 192, 196, 197]);
        }

        foreach (var seid in _skillJsonData.DataDict[__instance.skill_ID].seid)
        {
            switch (seid)
            {
                case 187:
                    __result = CanRealizeSeid187(seid, __instance);
                    $"自定义 SkillSeid187 判定结果: {__result}".Log();
                    return false;
                case 192:
                    __result = CanRealizeSeid192(seid, attaker, __instance);
                    $"自定义 SkillSeid192 判定结果: {__result}".Log();
                    return false;
                case 196:
                    __result = CanRealizeSeid196(seid, attaker, __instance);
                    $"自定义 SkillSeid196 判定结果: {__result}".Log();
                    return false;
                case 197:
                    __result = CanRealizeSeid197(seid, attaker, __instance);
                    $"自定义 SkillSeid197 判定结果: {__result}".Log();
                    return false;
                case 208:
                    __result = CanRealizeSeid208(seid, __instance);
                    $"自定义 SkillSeid208 判定结果: {__result}".Log();
                    return false;
            }
        }

        return true;
    }

    [HarmonyPatch(nameof(Skill.realizeSeid)), HarmonyPrefix]
    private static bool RealizeSeid_Prefix(
        int seid,
        List<int> damage,
        Entity _attaker,
        Entity _receiver,
        int type,
        Skill __instance)
    {
        if (!UseSeidExtension) return true;

        var avatar = (Avatar)_attaker;
        var target = (Avatar)_receiver;

        switch (seid)
        {
            case 181:
                RealizeSeid181(seid, avatar, __instance);
                return false;
            case 182:
                RealizeSeid182(seid, avatar, __instance);
                return false;
            case 183:
                RealizeSeid183(seid, avatar, __instance);
                return false;
            case 184:
                RealizeSeid184(seid, avatar, __instance);
                return false;
            case 185:
                RealizeSeid185(seid, avatar, target, __instance);
                return false;
            case 186:
                RealizeSeid186(seid, avatar, target, __instance);
                return false;
            case 188:
                RealizeSeid188(seid, avatar, __instance);
                return false;
            case 189:
                RealizeSeid189(seid, target, __instance);
                return false;
            case 190:
                RealizeSeid190(seid, avatar, __instance);
                return false;
            case 191:
                RealizeSeid191(seid, __instance);
                return false;
            case 193:
                RealizeSeid193(seid, damage, avatar, target, __instance);
                return false;
            case 194:
                RealizeSeid194(seid, damage, avatar, target, __instance);
                return false;
            case 195:
                RealizeSeid195(seid, avatar, target, type, __instance);
                return false;
            case 198:
                RealizeSeid198(seid, avatar, __instance);
                return false;
            case 199:
                RealizeSeid199(seid, avatar, __instance);
                return false;
            case 200:
                RealizeSeid200(seid, damage, __instance);
                return false;
            case 201:
                RealizeSeid201(seid, target, __instance);
                return false;
            case 202:
                RealizeSeid202(seid, target, __instance);
                return false;
            case 203:
                RealizeSeid203(seid, avatar, __instance);
                return false;
            case 204:
                RealizeSeid204(seid, avatar, __instance);
                return false;
            case 205:
                RealizeSeid205(seid, avatar, __instance);
                return false;
            case 206:
                RealizeSeid206(seid, damage, avatar, target, type, __instance);
                return false;
            case 207:
                RealizeSeid207(seid, avatar, __instance);
                return false;
            default:
                return true;
        }
    }

    #region CanRealizeSeid方法

    /// <summary>
    /// 自定义 Skill Seid 187 如果玩家装备了特定武器，则触发后续特效
    /// </summary>
    /// <param name="seid">187</param>
    /// <param name="instance">Skill 对象实例</param>
    /// <returns>判定结果</returns>
    private static bool CanRealizeSeid187(int seid, Skill instance)
    {
        seid.RealizeSeidInfo(null, "Skill");

        var itemId = instance.getSeidJson(seid).GetFieldInt("value1");
        return PlayerEx.Player.equipItemList.values.Any(item => item.itemId.Equals(itemId));
    }

    /// <summary>
    /// 自定义 Skill Seid 192 若上一次使用的是 X 技能，则触发后续特性
    /// </summary>
    /// <param name="seid">192</param>
    /// <param name="avatar">释放角色</param>
    /// <param name="instance">Skill 对象实例</param>
    private static bool CanRealizeSeid192(int seid, Avatar avatar, Skill instance)
    {
        seid.RealizeSeidInfo(null, "Skill");

        var skillId = instance.getSeidJson(seid).GetFieldInt("value1");

        if (avatar.UsedSkills == null || avatar.UsedSkills.Count == 0) return false;

        return _skillJsonData.DataDict[avatar.UsedSkills.Last()].Skill_ID == skillId;
    }

    /// <summary>
    /// 自定义 Skill Seid 196 若本回合使用过 X 技能，则触发后续特性
    /// </summary>
    /// <param name="seid">196</param>
    /// <param name="avatar">释放角色</param>
    /// <param name="instance">Skill 对象实例</param>
    private static bool CanRealizeSeid196(int seid, Avatar avatar, Skill instance)
    {
        seid.RealizeSeidInfo(null, "Skill");

        var skillId = instance.getSeidJson(seid).GetFieldInt("value1");

        if (avatar.fightTemp.NowRoundUsedSkills == null || avatar.useSkillNum == 0) return false;

        return avatar.fightTemp.NowRoundUsedSkills
            .Select(id => _skillJsonData.DataDict[id].Skill_ID)
            .Any(id => id == skillId);
    }

    /// <summary>
    /// 自定义 Skill Seid 197 若本局战斗使用过 X 技能，则触发后续特性
    /// </summary>
    /// <param name="seid">197</param>
    /// <param name="avatar">释放角色</param>
    /// <param name="instance">Skill 对象实例</param>
    private static bool CanRealizeSeid197(int seid, Avatar avatar, Skill instance)
    {
        seid.RealizeSeidInfo(null, "Skill");

        var skillId = instance.getSeidJson(seid).GetFieldInt("value1");

        if (avatar.UsedSkills == null || avatar.UsedSkills.Count == 0) return false;

        return avatar.UsedSkills
            .Select(id => _skillJsonData.DataDict[id].Skill_ID)
            .Any(id => id == skillId);
    }

    /// <summary>
    /// 自定义 Skill Seid 208 X% 的概率,触发后续特性
    /// </summary>
    /// <param name="seid">208</param>
    /// <param name="instance">Skill 对象实例</param>
    private static bool CanRealizeSeid208(int seid, Skill instance)
    {
        seid.RealizeSeidInfo(null, "Skill");

        var probability = instance.getSeidJson(seid).GetFieldInt("value1");

        return probability >= Random.Range(0, 100);
    }

    #endregion

    #region RealizeSeid方法

    /// <summary>
    /// 自定义 Skill Seid 181 将自身的所有 X 系灵气转化为 Y 系灵气
    /// </summary>
    /// <param name="seid">181</param>
    /// <param name="avatar">释放角色</param>
    /// <param name="instance">Skill 对象实例</param>
    private static void RealizeSeid181(int seid, Avatar avatar, Skill instance)
    {
        seid.RealizeSeidInfo(null, "Skill");

        var cardsX = instance.getSeidJson(seid).GetFieldList("value1");
        var cardsY = instance.getSeidJson(seid).GetFieldList("value2");

        if (cardsX.Count == 0)
        {
            seid.RealizeSeidWarn("value1 列表数据为空");
            return;
        }

        if (cardsY.Count == 0)
        {
            seid.RealizeSeidWarn("value2 列表数据为空");
            return;
        }

        if (cardsX.Count != cardsY.Count)
        {
            seid.RealizeSeidWarn("value1 和 value2 列表数据量不对等");
            return;
        }

        for (var index = 0; index < cardsX.Count; index++)
        {
            foreach (var card in avatar.cardMag._cardlist.Where(card => card.cardType == cardsX[index]))
            {
                card.cardType = cardsY[index];
                if (!avatar.isPlayer()) continue;
                --UIFightPanel.Inst.PlayerLingQiController.SlotList[cardsX[index]].LingQiCount;
                ++UIFightPanel.Inst.PlayerLingQiController.SlotList[cardsY[index]].LingQiCount;
            }
        }
    }

    /// <summary>
    /// 自定义 Skill Seid 182 将自身的所有 XBuff 变成 Y 倍 (整数)
    /// </summary>
    /// <param name="seid">182</param>
    /// <param name="avatar">释放角色</param>
    /// <param name="instance">Skill 对象实例</param>
    private static void RealizeSeid182(int seid, Avatar avatar, Skill instance)
    {
        seid.RealizeSeidInfo(null, "Skill");

        var buffs = instance.getSeidJson(seid).GetFieldList("value1");
        var nums = instance.getSeidJson(seid).GetFieldList("value2");

        if (buffs.Count == 0)
        {
            seid.RealizeSeidWarn("value1 列表数据为空");
            return;
        }

        if (nums.Count == 0)
        {
            seid.RealizeSeidWarn("value2 列表数据为空");
            return;
        }

        if (buffs.Count != nums.Count)
        {
            seid.RealizeSeidWarn("value1 和 value2 列表数据量不对等");
            return;
        }

        for (var index = 0; index < buffs.Count; index++)
        {
            if (!avatar.buffmag.HasBuff(buffs[index])) continue;
            var count = avatar.buffmag.getBuffByID(buffs[index]).Sum(list => list[1]);
            avatar.spell.addBuff(buffs[index], count * nums[index] - 1);
        }
    }

    /// <summary>
    /// 自定义 Skill Seid 183 获得自身 XBuff 数量的 YBuff
    /// </summary>
    /// <param name="seid">183</param>
    /// <param name="avatar">释放角色</param>
    /// <param name="instance">Skill 对象实例</param>
    private static void RealizeSeid183(int seid, Avatar avatar, Skill instance)
    {
        seid.RealizeSeidInfo(null, "Skill");

        var buffX = instance.getSeidJson(seid).GetFieldInt("value1");
        var buffY = instance.getSeidJson(seid).GetFieldInt("value2");

        if (!avatar.buffmag.HasBuff(buffX)) return;
        var count = avatar.buffmag.getBuffByID(buffX).Sum(list => list[1]);
        avatar.spell.addBuff(buffY, count);
    }

    /// <summary>
    /// 自定义 Skill Seid 184 获得自身 XBuff 数量的 YBuff
    /// </summary>
    /// <param name="seid">184</param>
    /// <param name="avatar">释放角色</param>
    /// <param name="instance">Skill 对象实例</param>
    private static void RealizeSeid184(int seid, Avatar avatar, Skill instance)
    {
        seid.RealizeSeidInfo(null, "Skill");

        var buffX = instance.getSeidJson(seid).GetFieldInt("value1");
        var buffY = instance.getSeidJson(seid).GetFieldInt("value2");

        if (!avatar.buffmag.HasBuff(buffX)) return;
        var count = avatar.buffmag.getBuffByID(buffX).Sum(list => list[1]);
        avatar.spell.addBuff(buffY, count);
    }

    /// <summary>
    /// 自定义 Skill Seid 185 给目标自身 XBuff 数量的 YBuff
    /// </summary>
    /// <param name="seid">185</param>
    /// <param name="avatar">释放角色</param>
    /// <param name="target">目标角色</param>
    /// <param name="instance">Skill 对象实例</param>
    private static void RealizeSeid185(int seid, Avatar avatar, Avatar target, Skill instance)
    {
        seid.RealizeSeidInfo(null, "Skill");

        var buffX = instance.getSeidJson(seid).GetFieldInt("value1");
        var buffY = instance.getSeidJson(seid).GetFieldInt("value2");

        if (!avatar.buffmag.HasBuff(buffX)) return;
        var count = avatar.buffmag.getBuffByID(buffX).Sum(list => list[1]);
        target.spell.addBuff(buffY, count);
    }

    /// <summary>
    /// 自定义 Skill Seid 186 给目标自身 XBuff 数量的 YBuff
    /// </summary>
    /// <param name="seid">186</param>
    /// <param name="avatar">释放角色</param>
    /// <param name="target">目标角色</param>
    /// <param name="instance">Skill 对象实例</param>
    private static void RealizeSeid186(int seid, Avatar avatar, Avatar target, Skill instance)
    {
        seid.RealizeSeidInfo(null, "Skill");

        var buffX = instance.getSeidJson(seid).GetFieldInt("value1");
        var buffY = instance.getSeidJson(seid).GetFieldInt("value2");

        if (!avatar.buffmag.HasBuff(buffX)) return;
        var count = avatar.buffmag.getBuffByID(buffX).Sum(list => list[1]);
        target.spell.addBuff(buffY, count);
    }

    /// <summary>
    /// 自定义 Skill Seid 188 双方同时获得 XBuff Y层
    /// </summary>
    /// <param name="seid">188</param>
    /// <param name="avatar">释放角色</param>
    /// <param name="instance">Skill 对象实例</param>
    private static void RealizeSeid188(int seid, Avatar avatar, Skill instance)
    {
        seid.RealizeSeidInfo(null, "Skill");

        var buffs = instance.getSeidJson(seid).GetFieldList("value1");
        var counts = instance.getSeidJson(seid).GetFieldList("value2");

        if (buffs.Count == 0)
        {
            seid.RealizeSeidWarn("value1 列表数据为空");
            return;
        }

        if (counts.Count == 0)
        {
            seid.RealizeSeidWarn("value2 列表数据为空");
            return;
        }

        if (buffs.Count != counts.Count)
        {
            seid.RealizeSeidWarn("value1 和 value2 列表数据量不对等");
            return;
        }

        for (var index = 0; index < buffs.Count; index++)
        {
            avatar.spell.addBuff(buffs[index], counts[index]);
            avatar.OtherAvatar.spell.addBuff(buffs[index], counts[index]);
        }
    }

    /// <summary>
    /// 自定义 Skill Seid 189 触发目标 XBuff Y 次
    /// </summary>
    /// <param name="seid">189</param>
    /// <param name="target">目标角色</param>
    /// <param name="instance">Skill 对象实例</param>
    private static void RealizeSeid189(int seid, Avatar target, Skill instance)
    {
        seid.RealizeSeidInfo(null, "Skill");

        var buffs = instance.getSeidJson(seid).GetFieldList("value1");
        var counts = instance.getSeidJson(seid).GetFieldList("value2");

        if (buffs.Count == 0)
        {
            seid.RealizeSeidWarn("value1 列表数据为空");
            return;
        }

        if (counts.Count == 0)
        {
            seid.RealizeSeidWarn("value2 列表数据为空");
            return;
        }

        if (buffs.Count != counts.Count)
        {
            seid.RealizeSeidWarn("value1 和 value2 列表数据量不对等");
            return;
        }

        Dictionary<int, int> tickBuffs = [];

        for (var index = 0; index < target.bufflist.Count; index++)
        {
            for (var i = 0; i < buffs.Count; i++)
            {
                if (target.bufflist[index][2] != buffs[i]) continue;
                tickBuffs.Add(index, counts[i]);
                break;
            }
        }

        foreach (var tickBuff in tickBuffs)
        {
            for (var count = 0; count < tickBuff.Value; count++)
            {
                target.spell.onBuffTick(tickBuff.Key, [0]);
            }
        }
    }

    /// <summary>
    /// 自定义 Skill Seid 190 将自身所有 XBuff 转化为 YBuff
    /// </summary>
    /// <param name="seid">190</param>
    /// <param name="avatar">释放角色</param>
    /// <param name="instance">Skill 对象实例</param>
    private static void RealizeSeid190(int seid, Avatar avatar, Skill instance)
    {
        seid.RealizeSeidInfo(null, "Skill");

        var buffX = instance.getSeidJson(seid).GetFieldInt("value1");
        var buffY = instance.getSeidJson(seid).GetFieldInt("value2");

        if (!avatar.buffmag.HasBuff(buffX)) return;
        var count = instance.RemoveBuff(avatar, buffX);
        avatar.spell.addBuff(buffY, count);
    }

    /// <summary>
    /// 自定义 Skill Seid 191 多段效果
    /// 同 SkillSeid11
    /// </summary>
    /// <param name="seid">191</param>
    /// <param name="instance">Skill 对象实例</param>
    private static void RealizeSeid191(int seid, Skill instance)
    {
        seid.RealizeSeidInfo(null, "Skill");

        var count = instance.getSeidJson(seid).GetFieldInt("value1");
        var skill = instance.getSeidJson(seid).GetFieldInt("value2");
        var attack = instance.getSeidJson(seid).GetFieldInt("value3");

        for (var index = 0; index < count; index++)
        {
            instance.LateDamages ??= [];

            instance.LateDamages.Add(new LateDamage
            {
                SkillId = skill,
                Damage = attack
            });
        }
    }

    /// <summary>
    /// 自定义 Skill Seid 193 遁速每比对方高 X 点,伤害增加 Y 点
    /// </summary>
    /// <param name="seid">193</param>
    /// <param name="damage">伤害数据</param>
    /// <param name="avatar">释放角色</param>
    /// <param name="target">目标角色</param>
    /// <param name="instance">Skill 对象实例</param>
    private static void RealizeSeid193(int seid, IList<int> damage, Avatar avatar, Avatar target, Skill instance)
    {
        seid.RealizeSeidInfo(null, "Skill");

        var count = instance.getSeidJson(seid).GetFieldInt("value1");
        var attack = instance.getSeidJson(seid).GetFieldInt("value2");

        var agile = avatar.dunSu - target.dunSu;
        if (agile <= 0) return;

        damage[0] += (int)((double)agile / count * attack);
    }

    /// <summary>
    /// 自定义 Skill Seid 194 遁速每比对方高 X 点,伤害提升 Y%
    /// </summary>
    /// <param name="seid">194</param>
    /// <param name="damage">伤害数据</param>
    /// <param name="avatar">释放角色</param>
    /// <param name="target">目标角色</param>
    /// <param name="instance">Skill 对象实例</param>
    private static void RealizeSeid194(int seid, IList<int> damage, Avatar avatar, Avatar target, Skill instance)
    {
        seid.RealizeSeidInfo(null, "Skill");

        var count = instance.getSeidJson(seid).GetFieldInt("value1");
        var attack = instance.getSeidJson(seid).GetFieldInt("value2");

        var agile = avatar.dunSu - target.dunSu;
        if (agile <= 0) return;

        damage[0] += (int)((double)agile / count * attack / 100 * damage[0]);
    }

    /// <summary>
    /// 自定义 Skill Seid 195 技能可额外释放 X 次
    /// </summary>
    /// <param name="seid">195</param>
    /// <param name="avatar">释放角色</param>
    /// <param name="target">目标角色</param>
    /// <param name="type">触发类型</param>
    /// <param name="instance">Skill 对象实例</param>
    private static void RealizeSeid195(int seid, Entity avatar, Entity target, int type, Skill instance)
    {
        seid.RealizeSeidInfo(null, "Skill");

        if (type == 99) return;

        var count = instance.getSeidJson(seid).GetFieldInt("value1");

        for (var i = 0; i < count; i++)
        {
            instance.PutingSkill(avatar, target, 99);
        }
    }

    /// <summary>
    /// 自定义 Skill Seid 198 获得自身 XBuff 数量的 YBuff Z倍
    /// </summary>
    /// <param name="seid">198</param>
    /// <param name="avatar">释放角色</param>
    /// <param name="instance">Skill 对象实例</param>
    private static void RealizeSeid198(int seid, Avatar avatar, Skill instance)
    {
        seid.RealizeSeidInfo(null, "Skill");

        var buffX = instance.getSeidJson(seid).GetFieldInt("value1");
        var buffs = instance.getSeidJson(seid).GetFieldList("value2");
        var counts = instance.getSeidJson(seid).GetFieldList("value3");

        if (buffs.Count == 0)
        {
            seid.RealizeSeidWarn("value2 列表数据为空");
            return;
        }

        if (counts.Count == 0)
        {
            seid.RealizeSeidWarn("value3 列表数据为空");
            return;
        }

        if (buffs.Count != counts.Count)
        {
            seid.RealizeSeidWarn("value2 和 value3 列表数据量不对等");
            return;
        }

        if (!avatar.buffmag.HasBuff(buffX)) return;
        var count = avatar.buffmag.getBuffByID(buffX).Sum(list => list[1]);

        for (var index = 0; index < buffs.Count; index++)
        {
            avatar.spell.addBuff(buffs[index], count * counts[index]);
        }
    }

    /// <summary>
    /// 自定义 Skill Seid 199 将自身当前血量的 X% 转化为生命上限
    /// </summary>
    /// <param name="seid">199</param>
    /// <param name="avatar">释放角色</param>
    /// <param name="instance">Skill 对象实例</param>
    private static void RealizeSeid199(int seid, Avatar avatar, Skill instance)
    {
        seid.RealizeSeidInfo(null, "Skill");

        var percentage = instance.getSeidJson(seid).GetFieldInt("value1");

        var hp = (int)((double)avatar.HP / 100 * percentage);

        avatar.HP -= hp;
        avatar.spell.addBuff(32, hp);
    }

    /// <summary>
    /// 自定义 Skill Seid 200 该次伤害 * X倍
    /// </summary>
    /// <param name="seid">200</param>
    /// <param name="damage">伤害数据</param>
    /// <param name="instance">Skill 对象实例</param>
    private static void RealizeSeid200(int seid, IList<int> damage, Skill instance)
    {
        seid.RealizeSeidInfo(null, "Skill");

        var number = instance.getSeidJson(seid).GetFieldInt("value1");
        damage[0] *= number;
    }

    /// <summary>
    /// 自定义 Skill Seid 201 降低目标血量上限 X 点
    /// </summary>
    /// <param name="seid">201</param>
    /// <param name="target">目标角色</param>
    /// <param name="instance">Skill 对象实例</param>
    private static void RealizeSeid201(int seid, Avatar target, Skill instance)
    {
        seid.RealizeSeidInfo(null, "Skill");

        var hp = instance.getSeidJson(seid).GetFieldInt("value1");

        // 剩余血量上限校验
        if (hp > target.HP_Max)
        {
            // 血量上限不足
            target.HP_Max = 1;
            target.HP = 0;
            return;
        }

        target.HP_Max -= hp;

        // 当前血量校验
        if (target.HP > target.HP_Max) target.HP = target.HP_Max;
    }

    /// <summary>
    /// 自定义 Skill Seid 202 降低目标血量上限 X 点
    /// </summary>
    /// <param name="seid">202</param>
    /// <param name="target">目标角色</param>
    /// <param name="instance">Skill 对象实例</param>
    private static void RealizeSeid202(int seid, Avatar target, Skill instance)
    {
        seid.RealizeSeidInfo(null, "Skill");

        var hp = instance.getSeidJson(seid).GetFieldInt("value1");

        // 剩余血量上限校验
        if (hp > target.HP_Max)
        {
            // 血量上限不足
            target.HP_Max = 1;
            target.HP = 0;
            return;
        }

        target.HP_Max -= hp;

        // 当前血量校验
        if (target.HP > target.HP_Max) target.HP = target.HP_Max;
    }

    /// <summary>
    /// 自定义 Skill Seid 203 消耗自身 X 点血量,获得等量的 YBuff * Z
    /// </summary>
    /// <param name="seid">203</param>
    /// <param name="avatar">释放角色</param>
    /// <param name="instance">Skill 对象实例</param>
    private static void RealizeSeid203(int seid, Avatar avatar, Skill instance)
    {
        seid.RealizeSeidInfo(null, "Skill");

        var hp = instance.getSeidJson(seid).GetFieldInt("value1");
        var buffs = instance.getSeidJson(seid).GetFieldList("value2");
        var counts = instance.getSeidJson(seid).GetFieldList("value3");

        if (buffs.Count == 0)
        {
            seid.RealizeSeidWarn("value2 列表数据为空");
            return;
        }

        if (counts.Count == 0)
        {
            seid.RealizeSeidWarn("value3 列表数据为空");
            return;
        }

        if (buffs.Count != counts.Count)
        {
            seid.RealizeSeidWarn("value2 和 value3 列表数据量不对等");
            return;
        }

        avatar.HP -= hp;

        for (var index = 0; index < buffs.Count; index++)
        {
            avatar.spell.addBuff(buffs[index], counts[index] * hp);
        }
    }

    /// <summary>
    /// 自定义 Skill Seid 204 消耗自身 X% 血量,获得等量的 YBuff * Z
    /// </summary>
    /// <param name="seid">204</param>
    /// <param name="avatar">释放角色</param>
    /// <param name="instance">Skill 对象实例</param>
    private static void RealizeSeid204(int seid, Avatar avatar, Skill instance)
    {
        seid.RealizeSeidInfo(null, "Skill");

        var percentage = instance.getSeidJson(seid).GetFieldInt("value1");
        var buffs = instance.getSeidJson(seid).GetFieldList("value2");
        var counts = instance.getSeidJson(seid).GetFieldList("value3");

        if (buffs.Count == 0)
        {
            seid.RealizeSeidWarn("value2 列表数据为空");
            return;
        }

        if (counts.Count == 0)
        {
            seid.RealizeSeidWarn("value3 列表数据为空");
            return;
        }

        if (buffs.Count != counts.Count)
        {
            seid.RealizeSeidWarn("value2 和 value3 列表数据量不对等");
            return;
        }

        var hp = (int)((double)avatar.HP / 100 * percentage);

        avatar.HP -= hp;

        for (var index = 0; index < buffs.Count; index++)
        {
            avatar.spell.addBuff(buffs[index], counts[index] * hp);
        }
    }

    /// <summary>
    /// 自定义 Skill Seid 205 消耗自身 X% 血量上限的血量,获得等量的 YBuff * Z
    /// </summary>
    /// <param name="seid">205</param>
    /// <param name="avatar">释放角色</param>
    /// <param name="instance">Skill 对象实例</param>
    private static void RealizeSeid205(int seid, Avatar avatar, Skill instance)
    {
        seid.RealizeSeidInfo(null, "Skill");

        var percentage = instance.getSeidJson(seid).GetFieldInt("value1");
        var buffs = instance.getSeidJson(seid).GetFieldList("value2");
        var counts = instance.getSeidJson(seid).GetFieldList("value3");

        if (buffs.Count == 0)
        {
            seid.RealizeSeidWarn("value2 列表数据为空");
            return;
        }

        if (counts.Count == 0)
        {
            seid.RealizeSeidWarn("value3 列表数据为空");
            return;
        }

        if (buffs.Count != counts.Count)
        {
            seid.RealizeSeidWarn("value2 和 value3 列表数据量不对等");
            return;
        }

        var hp = (int)((double)avatar.HP_Max / 100 * percentage);

        avatar.HP -= hp;

        for (var index = 0; index < buffs.Count; index++)
        {
            avatar.spell.addBuff(buffs[index], counts[index] * hp);
        }
    }

    /// <summary>
    /// 自定义 Skill Seid 206 吸收灵气 X 点，若其中包含 Y 灵气 则触发 Z 特性
    /// </summary>
    /// <param name="seid">206</param>
    /// <param name="damage">伤害数据</param>
    /// <param name="avatar">释放角色</param>
    /// <param name="target">目标角色</param>
    /// <param name="type">触发类型</param>
    /// <param name="instance">Skill 对象实例</param>
    private static void RealizeSeid206(int seid, List<int> damage, Avatar avatar, Avatar target, int type,
        Skill instance)
    {
        seid.RealizeSeidInfo(null, "Skill");

        var count = instance.getSeidJson(seid).GetFieldInt("value1");
        var reikiList = instance.getSeidJson(seid).GetFieldList("value2");
        var seidList = instance.getSeidJson(seid).GetFieldList("value3");

        if (reikiList.Count == 0)
        {
            seid.RealizeSeidWarn("value2 列表数据为空");
            return;
        }

        if (seidList.Count == 0)
        {
            seid.RealizeSeidWarn("value3 列表数据为空");
            return;
        }

        if (reikiList.Count != seidList.Count)
        {
            seid.RealizeSeidWarn("value2 和 value3 列表数据量不对等");
            return;
        }

        var randomReikiList = new List<int>();

        while (count-- > 0)
        {
            var reiki = RoundManager.instance.GetRandomLingQiType(avatar);
            RoundManager.instance.DrawCardCreatSpritAndAddCrystal(avatar, reiki);
            randomReikiList.Add(reiki);
        }

        RoundManager.instance.chengeCrystal();

        for (var index = 0; index < reikiList.Count; index++)
        {
            if (!randomReikiList.Contains(reikiList[index])) continue;
            instance.NowSkillSeid = [seidList[index]];
            instance.triggerStartSeid(instance.NowSkillSeid, damage, avatar, target, type);
        }
    }

    /// <summary>
    /// 自定义 Skill Seid 207 改变目标神识 X 点
    /// </summary>
    /// <param name="seid">207</param>
    /// <param name="avatar">释放角色</param>
    /// <param name="instance">Skill 对象实例</param>
    private static void RealizeSeid207(int seid, Avatar avatar, Skill instance)
    {
        seid.RealizeSeidInfo(null, "Skill");

        var spirit = instance.getSeidJson(seid).GetFieldInt("value1");

        avatar.OtherAvatar.shengShi += spirit;
    }

    #endregion
}