namespace TierneyJohn.MiChangSheng.JTools.Factory
{
    /// <summary>
    /// Buff Seid 数据工厂类
    /// </summary>
    public class BuffSeidFactory
    {
        /// <summary>
        /// 获取单值 Seid (特殊)
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="value">值</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetSingleSeidInstance(int id, float value)
        {
            var data = JSONObject.Create();
            data.AddField("id", id);
            data.AddField("value1", value);
            return data;
        }

        /// <summary>
        /// 获取 Seid167 数据
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="target">目标 (1:自身，2:敌方)</param>
        /// <param name="value">值</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetSeid167(int id, int target, int value)
        {
            var data = JSONObject.Create();
            data.AddField("id", id);
            data.AddField("target", target);
            data.AddField("value1", value);
            return data;
        }

        /// <summary>
        /// 获取涉及数据比较的 Seid 数据
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="target">目标 (1:自身，2:敌方)</param>
        /// <param name="value1">值1</param>
        /// <param name="compare">符号 ("大于" "小于" "等于")</param>
        /// <param name="value2">值2</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetCompareSeid(int id, int target, int value1, string compare, int value2)
        {
            var data = JSONObject.Create();
            data.AddField("id", id);
            data.AddField("target", target);
            data.AddField("value1", value1);
            data.AddField("panduan", compare);
            data.AddField("value2", value2);
            return data;
        }
    }
}