using System.Collections.Generic;

namespace TierneyJohn.MiChangSheng.JTools.Factory
{
    /// <summary>
    /// 特殊物品数据工厂类
    /// </summary>
    public class SpecialGoodsFactory
    {
        /// <summary>
        /// 获取指定参数的 SpecialGoodsItemJson 实例方法
        /// </summary>
        /// <param name="specialGoodsId">特殊物品编号</param>
        /// <param name="specialGoodsIconId">特殊物品图标编号</param>
        /// <param name="specialGoodsName">特殊物品名称</param>
        /// <param name="specialGoodsItemFlag">特殊物品</param>
        /// <param name="quality">特殊物品品阶</param>
        /// <param name="seid">特殊物品特性</param>
        /// <param name="vagueType">大类型(0不可使用，1消耗品)</param>
        /// <param name="canUseNumber">最大可使用次数</param>
        /// <param name="info">物品说明</param>
        /// <param name="desc">物品描述</param>
        /// <param name="maxNumber">最大堆叠数量 (默认1)</param>
        /// <param name="price">售价</param>
        /// <param name="unsalable">是否不可出售</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetInstance(
            int specialGoodsId,
            int specialGoodsIconId,
            string specialGoodsName,
            List<int> specialGoodsItemFlag,
            int quality,
            List<int> seid,
            int vagueType,
            int canUseNumber,
            string info,
            string desc,
            int maxNumber = 1,
            int price = 999999,
            int unsalable = 1
        )
        {
            // 默认不加入图鉴
            const int tuJianType = 0;
            // 默认不投放商店
            const int shopType = 99;
            // 默认物品类型为 特殊物品
            const int type = 16;
            // 默认 NPC 不可用
            const int npcCanUse = 0;
            // 默认词缀与领悟前置条件为空
            var empty = new List<int>();

            return ItemJsonFactory.GetInstance(specialGoodsId, specialGoodsIconId, maxNumber, specialGoodsName, "",
                empty, tuJianType, shopType, specialGoodsItemFlag, 0, 0, type, quality, 0, 0, seid, vagueType, price,
                info, desc, unsalable, 0, canUseNumber, npcCanUse, 0, 0, 0, 0, empty);
        }
    }
}