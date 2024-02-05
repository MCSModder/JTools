using System.Collections.Generic;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools.Factory
{
    /// <summary>
    /// 功法数据工厂类
    /// </summary>
    public class StaticSkillFactory
    {
        /// <summary>
        /// 获取指定参数的 StaticSkillJson 数据
        /// </summary>
        /// <param name="id">功法编号</param>
        /// <param name="skillId">功法唯一编号</param>
        /// <param name="lever">功法等级</param>
        /// <param name="skillName">功法名称</param>
        /// <param name="affix">功法词缀</param>
        /// <param name="qingJiaoType">请教类型 (1:普通，2:门派，3:不传，5:不传，6:魔修，7:无法请教)</param>
        /// <param name="seid">功法特性</param>
        /// <param name="attackType">功法类型</param>
        /// <param name="skillIconId">功法图标</param>
        /// <param name="skillLv">功法品阶(1:人，2:地，3:天)</param>
        /// <param name="typePinJie">功法小品阶 (1:下，2:中，3:上)</param>
        /// <param name="skillCastTime">参悟时间</param>
        /// <param name="skillSpeed">修炼速度</param>
        /// <param name="df">斗法是否可用</param>
        /// <param name="info">功法描述</param>
        /// <param name="desc">功法图鉴描述</param>
        /// <param name="tuJianType">图鉴类型</param>
        /// <returns></returns>
        public static JSONObject GetInstance(
            int id,
            int skillId,
            int lever,
            string skillName,
            List<int> affix,
            List<int> seid,
            int attackType,
            int skillIconId,
            int skillLv,
            int typePinJie,
            int skillCastTime,
            int skillSpeed,
            string info,
            string desc,
            int qingJiaoType = 7,
            int df = 1,
            int tuJianType = 7
        )
        {
            var data = JSONObject.Create();
            data.AddField("id", id);
            data.AddField("Skill_ID", skillId);
            data.AddField("Skill_Lv", lever);
            data.AddField("name", skillName);
            data.AddField("Affix", affix.ToJsonObject());
            data.AddField("qingjiaotype", qingJiaoType);
            data.AddField("seid", seid.ToJsonObject());
            data.AddField("TuJiandescr", desc);
            data.AddField("descr", info);
            data.AddField("AttackType", attackType);
            data.AddField("icon", skillIconId);
            data.AddField("Skill_LV", skillLv);
            data.AddField("typePinJie", typePinJie);
            data.AddField("Skill_castTime", skillCastTime);
            data.AddField("Skill_Speed", skillSpeed);
            data.AddField("DF", df);
            data.AddField("TuJianType", tuJianType);
            return data;
        }
    }
}