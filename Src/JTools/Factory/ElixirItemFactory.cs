using System.Collections.Generic;

namespace TierneyJohn.MiChangSheng.JTools.Factory
{
    /// <summary>
    /// 丹药物品数据工厂类
    /// </summary>
    public class ElixirItemFactory
    {
        /// <summary>
        /// 获取指定参数的 ElixirItem 实例方法
        /// </summary>
        /// <param name="elixirId">丹药物品编号</param>
        /// <param name="elixirIconId">丹药图标编号</param>
        /// <param name="elixirName">丹药名称</param>
        /// <param name="shopType">商店售卖类型</param>
        /// <param name="elixirItemFlag">丹药标签</param>
        /// <param name="quality">丹药品阶</param>
        /// <param name="seid">丹药特性</param>
        /// <param name="price">丹药价格</param>
        /// <param name="danDu">丹药毒性</param>
        /// <param name="canUseNumber">丹药耐药上限</param>
        /// <param name="info">丹药效果</param>
        /// <param name="desc">丹药描述</param>
        /// <param name="unsalable">是否非卖品</param>
        /// <param name="npcCanUse">NPC是否可以使用</param>
        /// <param name="refresh">丹药刷新时间</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetInstance(
            int elixirId,
            int elixirIconId,
            string elixirName,
            int shopType,
            List<int> elixirItemFlag,
            int quality,
            List<int> seid,
            int price,
            int danDu,
            int canUseNumber,
            string info,
            string desc,
            int unsalable = 0,
            int npcCanUse = 1,
            int refresh = 0
        )
        {
            // 丹药堆叠上限默认采用 99999 即可
            const int elixirMaxNumber = 99999;
            // 默认加入丹药图鉴
            const int tuJianType = 4;
            // 添加默认丹药标签 6 默认丹药品阶标签 60x
            elixirItemFlag.Add(6);
            elixirItemFlag.Add(600 + quality);
            // 默认物品类型为丹药
            const int type = 5;
            // 丹药默认词缀与领悟前置条件为空
            var empty = new List<int>();

            return ItemJsonFactory.GetInstance(elixirId, elixirIconId, elixirMaxNumber, elixirName, "", empty,
                tuJianType, shopType, elixirItemFlag, 0, 0, type, quality, 0, 0, seid, 1, price, info, desc, unsalable,
                danDu, canUseNumber, npcCanUse, 0, 0, 0, refresh, empty);
        }
    }
}