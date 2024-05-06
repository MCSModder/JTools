using System.Collections.Generic;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools.Factory
{
    /// <summary>
    /// Seid 数据工厂类
    /// </summary>
    public class SeidJsonFactory
    {
        /// <summary>
        /// 消耗丹方物品获得炼制配方特性(丹方专属)
        /// </summary>
        /// <param name="elixirFormulaItemId">丹方物品编号</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetElixirFormulaSeidInstance(int elixirFormulaItemId)
        {
            var data = JSONObject.Create();
            data.AddField("id", elixirFormulaItemId);
            data.AddField("value1", elixirFormulaItemId);
            return data;
        }

        /// <summary>
        /// 消耗技能书获取指定技能 (功法神通通用)
        /// </summary>
        /// <param name="skillItemId">神通功法物品编号</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetSkillSeidInstance(int skillItemId)
        {
            var data = JSONObject.Create();
            data.AddField("id", skillItemId);
            data.AddField("value1", skillItemId);
            return data;
        }

        /// <summary>
        /// 获取单值 Seid
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="value">值</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetSingleSeidInstance(int id, int value)
        {
            var data = JSONObject.Create();
            data.AddField("id", id);
            data.AddField("value1", value);
            return data;
        }

        /// <summary>
        /// 获取单值 Seid
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="value">值</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetSingleSeidInstance(int id, List<int> value)
        {
            var data = JSONObject.Create();
            data.AddField("id", id);
            data.AddField("value1", value.ToJsonObject());
            return data;
        }

        /// <summary>
        /// 获取双值 Seid
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="value1">值</param>
        /// <param name="value2">值</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetDoubleSeidInstance(int id, int value1, int value2)
        {
            var data = JSONObject.Create();
            data.AddField("id", id);
            data.AddField("value1", value1);
            data.AddField("value2", value2);
            return data;
        }

        /// <summary>
        /// 获取双值 Seid
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="value1">值</param>
        /// <param name="value2">值</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetDoubleSeidInstance(int id, List<int> value1, List<int> value2)
        {
            var data = JSONObject.Create();
            data.AddField("id", id);
            data.AddField("value1", value1.ToJsonObject());
            data.AddField("value2", value2.ToJsonObject());
            return data;
        }

        /// <summary>
        /// 获取双值 Seid
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="value1">值</param>
        /// <param name="value2">值</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetDoubleSeidInstance(int id, List<int> value1, int value2)
        {
            var data = JSONObject.Create();
            data.AddField("id", id);
            data.AddField("value1", value1.ToJsonObject());
            data.AddField("value2", value2);
            return data;
        }

        /// <summary>
        /// 获取四值 Seid
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="value1">值</param>
        /// <param name="value2">值</param>
        /// <param name="value3">值</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetThreeSeidInstance(int id, int value1, List<int> value2, List<int> value3)
        {
            var data = JSONObject.Create();
            data.AddField("id", id);
            data.AddField("value1", value1);
            data.AddField("value2", value2.ToJsonObject());
            data.AddField("value3", value3.ToJsonObject());
            return data;
        }

        /// <summary>
        /// 获取四值 Seid
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="value1">值</param>
        /// <param name="value2">值</param>
        /// <param name="value3">值</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetThreeSeidInstance(int id, int value1, int value2, int value3)
        {
            var data = JSONObject.Create();
            data.AddField("id", id);
            data.AddField("value1", value1);
            data.AddField("value2", value2);
            data.AddField("value3", value3);
            return data;
        }

        /// <summary>
        /// 获取四值 Seid
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="value1">值</param>
        /// <param name="value2">值</param>
        /// <param name="value3">值</param>
        /// <param name="value4">值</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetFourSeidInstance(int id, int value1, int value2, int value3, int value4)
        {
            var data = JSONObject.Create();
            data.AddField("id", id);
            data.AddField("value1", value1);
            data.AddField("value2", value2);
            data.AddField("value3", value3);
            data.AddField("value4", value4);
            return data;
        }

        /// <summary>
        /// 获取四值 Seid
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="value1">值</param>
        /// <param name="value2">值</param>
        /// <param name="value3">值</param>
        /// <param name="value4">值</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetFourSeidInstance(int id, List<int> value1, List<int> value2, List<int> value3,
            List<int> value4)
        {
            var data = JSONObject.Create();
            data.AddField("id", id);
            data.AddField("value1", value1.ToJsonObject());
            data.AddField("value2", value2.ToJsonObject());
            data.AddField("value3", value3.ToJsonObject());
            data.AddField("value4", value4.ToJsonObject());
            return data;
        }
    }
}