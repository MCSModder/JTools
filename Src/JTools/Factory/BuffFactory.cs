using System.Collections.Generic;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools.Factory
{
    /// <summary>
    /// Buff 数据工厂类
    /// </summary>
    public class BuffFactory
    {
        /// <summary>
        /// 获取指定参数的 BuffJson 实例方法
        /// </summary>
        /// <param name="buffId">Buff 编号</param>
        /// <param name="buffIconId">Buff 图标编号</param>
        /// <param name="buffName">Buff 名称</param>
        /// <param name="affix">Buff 词缀</param>
        /// <param name="buffType">Buff 类型 (1负面，2正面，3指示物，4阵法，5形态，6功法被动，7装备被动，8丹药)</param>
        /// <param name="seid">Buff Seid 特性</param>
        /// <param name="startTrigger">Buff 触发条件</param>
        /// <param name="removeTrigger">Buff 移除条件</param>
        /// <param name="overlayType">Buff 叠加类型 (0叠加，1覆盖，2增加，3放技能)</param>
        /// <param name="desc">Buff 描述</param>
        /// <param name="isHide">是否隐藏</param>
        /// <param name="showOnlyOne">是否只显示1层</param>
        /// <param name="loopTime">Buff 循环时间</param>
        /// <param name="totalTime">Buff 持续时间</param>
        /// <param name="script">script 类型 (默认 Buff)</param>
        /// <param name="skillEffect">Buff 技能特效 (默认采用 fx_Summoner_o)</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetInstance(
            int buffId,
            int buffIconId,
            string buffName,
            List<int> affix,
            int buffType,
            List<int> seid,
            int startTrigger,
            int removeTrigger,
            int overlayType,
            string desc,
            int isHide = 0,
            int showOnlyOne = 0,
            int loopTime = 1,
            int totalTime = 1,
            string script = "Buff",
            string skillEffect = "fx_Summoner_o"
        )
        {
            var data = JSONObject.Create();
            data.AddField("buffid", buffId);
            data.AddField("BuffIcon", buffIconId);
            data.AddField("skillEffect", skillEffect);
            data.AddField("name", buffName);
            data.AddField("Affix", affix.ToJsonObject());
            data.AddField("bufftype", buffType);
            data.AddField("seid", seid.ToJsonObject());
            data.AddField("descr", desc);
            data.AddField("trigger", startTrigger);
            data.AddField("removeTrigger", removeTrigger);
            data.AddField("script", script);
            data.AddField("looptime", loopTime);
            data.AddField("totaltime", totalTime);
            data.AddField("BuffType", overlayType);
            data.AddField("isHide", isHide);
            data.AddField("ShowOnlyOne", showOnlyOne);
            return data;
        }

        /// <summary>
        /// 获取指定参数的丹药 BuffJson 实例方法
        /// </summary>
        /// <param name="elixirBuffId">丹药 Buff 编号 (默认使用丹药编号)</param>
        /// <param name="elixirBuffName">丹药 Buff 名称 (默认使用丹药名称)</param>
        /// <param name="seid">丹药 Buff Seid 特性</param>
        /// <param name="startTrigger">丹药 Buff 触发条件</param>
        /// <param name="desc">丹药 Buff 描述</param>
        /// <returns></returns>
        public static JSONObject GetElixirBuffInstance(
            int elixirBuffId,
            string elixirBuffName,
            List<int> seid,
            int startTrigger,
            string desc
        )
        {
            // 默认丹药 Buff 图片采用 5205
            const int buffIconId = 5205;
            // 默认丹药 Buff 的 Affix 为空
            var affix = new List<int>();
            // 默认丹药 Buff 的类型为 8: 丹药
            const int buffType = 8;
            // 默认丹药 Buff 移除类型为 7:不主动移除
            const int removeTrigger = 7;
            // 默认丹药 Buff 的叠加类型为 0:叠加
            const int overlayType = 0;
            return GetInstance(
                elixirBuffId,
                buffIconId,
                elixirBuffName,
                affix,
                buffType,
                seid,
                startTrigger,
                removeTrigger,
                overlayType,
                desc);
        }

        /// <summary>
        /// 获取指定参数的 SimpleBuffJson 实例方法
        /// </summary>
        /// <param name="simpleBuffId">Buff 编号</param>
        /// <param name="seid">Buff Seid 特性</param>
        /// <param name="startTrigger">Buff 触发条件</param>
        /// <param name="removeTrigger">Buff 移除条件</param>
        /// <param name="overlayType">Buff 叠加类型 (0叠加，1覆盖，2增加，3放技能)</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetSimpleBuffInstance(int simpleBuffId, List<int> seid, int startTrigger,
            int removeTrigger = 7, int overlayType = 0)
        {
            // 默认 SimpleBuff 的名称采用 id
            var simpleBuffName = simpleBuffId.ToString();
            // 默认 SimpleBuff 的 Affix 为空
            var affix = new List<int>();
            // 默认 SimpleBuff 的类型为 6: 功法被动
            const int buffType = 6;
            // 默认 SimpleBuff 的描述为空
            const string desc = "";
            return GetInstance(simpleBuffId, simpleBuffId, simpleBuffName, affix, buffType, seid, startTrigger,
                removeTrigger, overlayType, desc, 1);
        }
    }
}