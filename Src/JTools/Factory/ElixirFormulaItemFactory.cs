using System.Collections.Generic;

namespace TierneyJohn.MiChangSheng.JTools.Factory
{
    /// <summary>
    /// 丹方物品数据工厂类
    /// </summary>
    public class ElixirFormulaItemFactory
    {
        /// <summary>
        /// 获取指定参数的 ElixirFormulaItem 实例方法
        /// </summary>
        /// <param name="elixirFormulaItemId">丹方物品编号</param>
        /// <param name="elixirFormulaIconId">丹方图标编号</param>
        /// <param name="elixirFormulaName">丹方名称</param>
        /// <param name="shopType">商店售卖类型</param>
        /// <param name="quality">丹方品阶</param>
        /// <param name="price">丹方价格</param>
        /// <param name="info">丹方效果</param>
        /// <param name="desc">丹方描述</param>
        /// <param name="refresh">丹方刷新时间</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetInstance(
            int elixirFormulaItemId,
            int elixirFormulaIconId,
            string elixirFormulaName,
            int shopType,
            int quality,
            int price,
            string info,
            string desc,
            int refresh = 0
        )
        {
            // 丹方堆叠上限默认采用 1 即可
            const int elixirFormulaMaxNumber = 1;
            // 默认不加入图鉴
            const int tuJianType = 0;
            // 添加默认丹方标签 10 默认丹方品阶 100x
            var elixirFormulaItemFlag = new List<int>
            {
                10, 1000 + quality
            };
            // 默认物品类型为丹方
            const int type = 10;
            // 默认丹方 seid 为 13
            var seid = new List<int>
            {
                13
            };
            // 默认丹方使用上限为 1
            const int canUseNumber = 1;
            // 丹方默认词缀与领悟前置条件为空
            var empty = new List<int>();

            return ItemJsonFactory.GetInstance(elixirFormulaItemId, elixirFormulaIconId, elixirFormulaMaxNumber,
                elixirFormulaName, "",
                empty, tuJianType, shopType, elixirFormulaItemFlag, 0, 0, type, quality, 0, 0, seid, 1, price,
                info, desc, 0, 0, canUseNumber, 1, 0, 0, 0, refresh, empty);
        }
    }
}