using System.Collections.Generic;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools.Factory
{
    /// <summary>
    /// 神通 Seid 数据工厂类
    /// </summary>
    public class SkillSeidFactory
    {
        /// <summary>
        /// 获取异火 Seid 特性
        /// </summary>
        /// <param name="skillId">神通编号</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GerFireSeidInstance(int skillId)
        {
            var data = JSONObject.Create();
            data.AddField("skillid", skillId);
            data.AddField("value1", 410);
            data.AddField("value2", 1);
            data.AddField("value3", 4236);
            data.AddField("value4", 1);
            return data;
        }

        /// <summary>
        /// 获取单值 Seid
        /// </summary>
        /// <param name="skillId">神通编号</param>
        /// <param name="value">值</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetSingleSeidInstance(int skillId, int value)
        {
            var data = JSONObject.Create();
            data.AddField("skillid", skillId);
            data.AddField("value1", value);
            return data;
        }

        /// <summary>
        /// 获取单值 Seid
        /// </summary>
        /// <param name="skillId">神通编号</param>
        /// <param name="value">值</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetSingleSeidInstance(int skillId, List<int> value)
        {
            var data = JSONObject.Create();
            data.AddField("skillid", skillId);
            data.AddField("value1", value.ToJsonObject());
            return data;
        }

        /// <summary>
        /// 获取双值 Seid
        /// </summary>
        /// <param name="skillId">神通编号</param>
        /// <param name="value1">值</param>
        /// <param name="value2">值</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetDoubleSeidInstance(int skillId, int value1, int value2)
        {
            var data = JSONObject.Create();
            data.AddField("skillid", skillId);
            data.AddField("value1", value1);
            data.AddField("value2", value2);
            return data;
        }

        /// <summary>
        /// 获取双值 Seid
        /// </summary>
        /// <param name="skillId">神通编号</param>
        /// <param name="value1">值</param>
        /// <param name="value2">值</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetDoubleSeidInstance(int skillId, List<int> value1, List<int> value2)
        {
            var data = JSONObject.Create();
            data.AddField("skillid", skillId);
            data.AddField("value1", value1.ToJsonObject());
            data.AddField("value2", value2.ToJsonObject());
            return data;
        }

        /// <summary>
        /// 获取三值 Seid
        /// </summary>
        /// <param name="skillId">神通编号</param>
        /// <param name="value1">值</param>
        /// <param name="value2">值</param>
        /// <param name="value3">值</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetThreeSeidInstance(int skillId, int value1, int value2, int value3)
        {
            var data = JSONObject.Create();
            data.AddField("skillid", skillId);
            data.AddField("value1", value1);
            data.AddField("value2", value2);
            data.AddField("value3", value3);
            return data;
        }

        /// <summary>
        /// 获取三值 Seid
        /// </summary>
        /// <param name="skillId">神通编号</param>
        /// <param name="value1">值</param>
        /// <param name="value2">值</param>
        /// <param name="value3">值</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetThreeSeidInstance(int skillId, List<int> value1, List<int> value2, List<int> value3)
        {
            var data = JSONObject.Create();
            data.AddField("skillid", skillId);
            data.AddField("value1", value1.ToJsonObject());
            data.AddField("value2", value2.ToJsonObject());
            data.AddField("value3", value3.ToJsonObject());
            return data;
        }

        /// <summary>
        /// Seid148 专属方法
        /// </summary>
        /// <param name="skillId">功法编号</param>
        /// <param name="target">目标 (1:自身，2:敌方)</param>
        /// <param name="value1">XBuff</param>
        /// <param name="panDuan">符号 ("大于" "小于" "等于")</param>
        /// <param name="value2">层数</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetSeid148Instance(int skillId, int target, int value1, string panDuan, int value2)
        {
            var data = JSONObject.Create();
            data.AddField("skillid", skillId);
            data.AddField("target", target);
            data.AddField("value1", value1);
            data.AddField("panduan", panDuan);
            data.AddField("value2", value2);
            return data;
        }

        /// <summary>
        /// Seid150 专属方法
        /// </summary>
        /// <param name="skillId">功法编号</param>
        /// <param name="value1">特性验证 X</param>
        /// <param name="value2">触发特性 Y</param>
        /// <param name="value3">触发特性 Z</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetSeid150Instance(int skillId, int value1, List<int> value2, List<int> value3)
        {
            var data = JSONObject.Create();
            data.AddField("skillid", skillId);
            data.AddField("value1", value1);
            data.AddField("value2", value2.ToJsonObject());
            data.AddField("value3", value3.ToJsonObject());
            return data;
        }

        /// <summary>
        /// Seid151 专属方法
        /// </summary>
        /// <param name="skillId">功法编号</param>
        /// <param name="value1">特性验证 X</param>
        /// <param name="value2">触发特性 Y</param>
        /// <param name="value3">触发特性 Z</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetSeid151Instance(int skillId, int value1, List<int> value2, List<int> value3)
        {
            var data = JSONObject.Create();
            data.AddField("skillid", skillId);
            data.AddField("value1", value1);
            data.AddField("value2", value2.ToJsonObject());
            data.AddField("value3", value3.ToJsonObject());
            return data;
        }

        /// <summary>
        /// Seid153 专属方法
        /// </summary>
        /// <param name="skillId">功法编号</param>
        /// <param name="target">目标 (1:自身，2:敌方)</param>
        /// <param name="value1">XBuff</param>
        /// <param name="value2">Y 层</param>
        /// <returns></returns>
        public static JSONObject GetSeid153Instance(int skillId, int target, int value1, int value2)
        {
            var data = JSONObject.Create();
            data.AddField("skillid", skillId);
            data.AddField("target", target);
            data.AddField("value1", value1);
            data.AddField("value2", value2);
            return data;
        }

        /// <summary>
        /// StaticSeid1 专属方法
        /// </summary>
        /// <param name="skillId">功法编号</param>
        /// <param name="target"></param>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public static JSONObject GetStaticSeid1Instance(int skillId, int target, List<int> value1, List<int> value2)
        {
            var data = JSONObject.Create();
            data.AddField("skillid", skillId);
            data.AddField("target", target);
            data.AddField("value1", value1.ToJsonObject());
            data.AddField("value2", value2.ToJsonObject());
            return data;
        }

        /// <summary>
        /// StaticSeid9 专属方法
        /// </summary>
        /// <param name="skillId">功法编号</param>
        /// <param name="spine"></param>
        /// <param name="onMoveExit"></param>
        /// <param name="onLoopMoveEnter"></param>
        /// <param name="onMoveEnter"></param>
        /// <param name="onLoopMoveExit"></param>
        /// <returns></returns>
        public static JSONObject GetStaticSeid9Instance(
            int skillId,
            string spine,
            string onMoveExit,
            string onLoopMoveEnter,
            string onMoveEnter = "",
            string onLoopMoveExit = ""
        )
        {
            var data = JSONObject.Create();
            data.AddField("skillid", skillId);
            data.AddField("Spine", spine);
            data.AddField("OnMoveEnter", onMoveEnter);
            data.AddField("OnMoveExit", onMoveExit);
            data.AddField("OnLoopMoveEnter", onLoopMoveEnter);
            data.AddField("OnLoopMoveExit", onLoopMoveExit);
            return data;
        }
    }
}