using System.Collections.Generic;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools.Factory
{
    /// <summary>
    /// 神通数据工厂类
    /// </summary>
    public class SkillFactory
    {
        /// <summary>
        /// 获取指定参数的 SkillJson 数据
        /// </summary>
        /// <param name="id">神通编号</param>
        /// <param name="skillId">神通唯一编号</param>
        /// <param name="lever">神通等级</param>
        /// <param name="skillEffect">神通特效</param>
        /// <param name="priority">释放优先级</param>
        /// <param name="skillName">神通名称</param>
        /// <param name="qingJiaoType">请教类型 (1:普通，2:门派，3:不传，5:不传，6:魔修，7:无法请教)</param>
        /// <param name="seid">神通特性</param>
        /// <param name="oldAffix">老词缀</param>
        /// <param name="affix">新词缀</param>
        /// <param name="info">神通描述</param>
        /// <param name="desc">神通图鉴描述</param>
        /// <param name="attackType">攻击类型 (0金，1木。2水，3火，4土，5气，6神，7剑，8阵，9禁制，10隐匿，11魔，12结丹，13秘术...)</param>
        /// <param name="script">攻击对象 (SkillAttack:对敌方,SkillSelf:对自己)</param>
        /// <param name="hp">神通基础伤害</param>
        /// <param name="speed">神通移动速度 (已弃用，必须填0)</param>
        /// <param name="skillIconId">神通图标</param>
        /// <param name="skillDisplayType">释放方式 (已弃用，必须填0)</param>
        /// <param name="skillSameCastNum">同系灵气消耗</param>
        /// <param name="skillCastType">五行灵气消耗类型</param>
        /// <param name="skillCast">五行灵气消耗数量</param>
        /// <param name="skillLv">神通品阶 (1:人，2:地，3:天)</param>
        /// <param name="typePinJie">神通小品阶 (1:下，2:中，3:上)</param>
        /// <param name="df">斗法是否可用</param>
        /// <param name="tuJianType">图鉴类型</param>
        /// <param name="skillOpen">学习境界需求</param>
        /// <param name="skillCastTime">参悟时间 (月)</param>
        /// <param name="canUseDistMax">攻击距离 (已弃用，必须填30)</param>
        /// <param name="cd">冷却时间 (已弃用，必须填10000)</param>
        /// <returns></returns>
        public static JSONObject GetInstance(
            int id,
            int skillId,
            int lever,
            string skillEffect,
            int priority,
            string skillName,
            int qingJiaoType,
            List<int> seid,
            List<int> oldAffix,
            List<int> affix,
            List<int> attackType,
            string script,
            int hp,
            int skillIconId,
            List<int> skillSameCastNum,
            List<int> skillCastType,
            List<int> skillCast,
            int skillLv,
            int typePinJie,
            int skillOpen,
            int skillCastTime,
            string info,
            string desc,
            int df,
            int tuJianType,
            int speed = 0,
            int skillDisplayType = 0,
            int canUseDistMax = 30,
            int cd = 10000
        )
        {
            var data = JSONObject.Create();
            data.AddField("id", id);
            data.AddField("Skill_ID", skillId);
            data.AddField("Skill_Lv", lever);
            data.AddField("skillEffect", skillEffect);
            data.AddField("Skill_Type", priority);
            data.AddField("name", skillName);
            data.AddField("qingjiaotype", qingJiaoType);
            data.AddField("seid", seid.ToJsonObject());
            data.AddField("Affix", oldAffix.ToJsonObject());
            data.AddField("Affix2", affix.ToJsonObject());
            data.AddField("descr", info);
            data.AddField("TuJiandescr", desc);
            data.AddField("AttackType", attackType.ToJsonObject());
            data.AddField("script", script);
            data.AddField("HP", hp);
            data.AddField("speed", speed);
            data.AddField("icon", skillIconId);
            data.AddField("Skill_DisplayType", skillDisplayType);
            data.AddField("skill_SameCastNum", skillSameCastNum.ToJsonObject());
            data.AddField("skill_CastType", skillCastType.ToJsonObject());
            data.AddField("skill_Cast", skillCast.ToJsonObject());
            data.AddField("Skill_LV", skillLv);
            data.AddField("typePinJie", typePinJie);
            data.AddField("DF", df);
            data.AddField("TuJianType", tuJianType);
            data.AddField("Skill_Open", skillOpen);
            data.AddField("Skill_castTime", skillCastTime);
            data.AddField("canUseDistMax", canUseDistMax);
            data.AddField("CD", cd);
            return data;
        }

        /// <summary>
        /// 获取指定参数的 SkillJson 数据
        /// </summary>
        /// <param name="id">神通编号</param>
        /// <param name="skillId">神通唯一编号</param>
        /// <param name="lever">神通等级</param>
        /// <param name="skillEffect">神通特效</param>
        /// <param name="priority">释放优先级</param>
        /// <param name="skillName">神通名称</param>
        /// <param name="qingJiaoType">请教类型 (1:普通，2:门派，3:不传，5:不传，6:魔修，7:无法请教)</param>
        /// <param name="seid">神通特性</param>
        /// <param name="affix">神通词缀</param>
        /// <param name="attackType">攻击类型 (0金，1木。2水，3火，4土，5气，6神，7剑，8阵，9禁制，10隐匿，11魔，12结丹，13秘术...)</param>
        /// <param name="script">攻击对象 (SkillAttack:对敌方,SkillSelf:对自己)</param>
        /// <param name="attack">神通基础伤害</param>
        /// <param name="skillSameCastNumber">同系灵气消耗</param>
        /// <param name="skillCastType">五行灵气消耗类型</param>
        /// <param name="skillCast">五行灵气消耗数量</param>
        /// <param name="skillLv">神通品阶 (1:人，2:地，3:天)</param>
        /// <param name="typePinJie">神通小品阶 (1:下，2:中，3:上)</param>
        /// <param name="skillOpen">学习境界需求</param>
        /// <param name="skillCastTime">参悟时间 (月)</param>
        /// <param name="info">神通描述</param>
        /// <param name="desc">神通图鉴描述</param>
        /// <param name="df">斗法是否可用 (0:不可用，1:可用)</param>
        /// <returns></returns>
        public static JSONObject GetSkillInstance(
            int id,
            int skillId,
            int lever,
            string skillEffect,
            int priority,
            string skillName,
            int qingJiaoType,
            List<int> seid,
            List<int> affix,
            List<int> attackType,
            string script,
            int attack,
            List<int> skillSameCastNumber,
            List<int> skillCastType,
            List<int> skillCast,
            int skillLv,
            int typePinJie,
            string info,
            string desc,
            int skillOpen = 0,
            int skillCastTime = 1,
            int df = 1
        )
        {
            // 默认不使用老词缀
            var oldAffix = new List<int>();
            // SkillIconId 默认使用 SkillId
            var skillIconId = skillId;
            // 默认图鉴类型 6: 神通
            const int tuJianType = 6;
            // 默认允许启用斗法
            return GetInstance(id, skillId, lever, skillEffect, priority, skillName, qingJiaoType, seid, oldAffix,
                affix, attackType, script, attack, skillIconId, skillSameCastNumber, skillCastType, skillCast, skillLv,
                typePinJie, skillOpen, skillCastTime, info, desc, df, tuJianType);
        }
    }
}