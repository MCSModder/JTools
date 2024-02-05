namespace TierneyJohn.MiChangSheng.JTools.Factory
{
    /// <summary>
    /// 丹方数据工厂类
    /// </summary>
    public class ElixirFormulaFactory
    {
        /// <summary>
        /// 获取指定参数丹方数据方法
        /// </summary>
        /// <param name="elixirFormulaId">丹方编号</param>
        /// <param name="elixirName">丹药名称</param>
        /// <param name="drugPrimer">药引编号</param>
        /// <param name="drugPrimerNumber">药引数量</param>
        /// <param name="mainDrugA">主药1编号</param>
        /// <param name="mainDrugNumberA">主药1数量</param>
        /// <param name="mainDrugB">主药2编号</param>
        /// <param name="mainDrugNumberB">主药2数量</param>
        /// <param name="adjuvantA">辅药1编号</param>
        /// <param name="adjuvantNumberA">辅药1数量</param>
        /// <param name="adjuvantB">辅药2编号</param>
        /// <param name="adjuvantNumberB">辅药2数量</param>
        /// <param name="castTime">炼制时长</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetInstance(
            int elixirFormulaId,
            string elixirName,
            int drugPrimer,
            int drugPrimerNumber,
            int mainDrugA,
            int mainDrugNumberA,
            int mainDrugB,
            int mainDrugNumberB,
            int adjuvantA,
            int adjuvantNumberA,
            int adjuvantB,
            int adjuvantNumberB,
            int castTime = 1
        )
        {
            var data = JSONObject.Create();
            data.AddField("id", elixirFormulaId);
            // 丹药编号和丹方编号相差 1000
            data.AddField("ItemID", elixirFormulaId - 1000);
            data.AddField("name", elixirName);
            data.AddField("value1", drugPrimer);
            data.AddField("num1", drugPrimerNumber);
            data.AddField("value2", mainDrugA);
            data.AddField("num2", mainDrugNumberA);
            data.AddField("value3", mainDrugB);
            data.AddField("num3", mainDrugNumberB);
            data.AddField("value4", adjuvantA);
            data.AddField("num4", adjuvantNumberA);
            data.AddField("value5", adjuvantB);
            data.AddField("num5", adjuvantNumberB);
            data.AddField("castTime", castTime);
            return data;
        }
    }
}