using System.Collections.Generic;

namespace TierneyJohn.MiChangSheng.JTools.Factory
{
    /// <summary>
    /// 功法物品数据工厂类
    /// </summary>
    public class StaticSkillItemFactory
    {
        /// <summary>
        /// 获取指定参数的 StaticSkillItemJson 实例方法
        /// </summary>
        /// <param name="staticSkillId">功法书物品编号</param>
        /// <param name="staticSkillName">功法名称</param>
        /// <param name="shopType">商店售卖类型</param>
        /// <param name="staticSkillItemFlag">功法物品标签</param>
        /// <param name="quality">功法品阶 (1人，2地，3天)</param>
        /// <param name="typePinJie">功法小品阶 (1下，2中，3上)</param>
        /// <param name="stuTime">功法领悟时间</param>
        /// <param name="seid">功法书物品特性</param>
        /// <param name="price">功法书价格</param>
        /// <param name="info">功法书说明</param>
        /// <param name="desc">功法书描述</param>
        /// <param name="staticSkillWuDao">领悟前置条件 (组)</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetInstance(
            int staticSkillId,
            string staticSkillName,
            int shopType,
            List<int> staticSkillItemFlag,
            int quality,
            int typePinJie,
            int stuTime,
            List<int> seid,
            int price,
            string info,
            string desc,
            List<int> staticSkillWuDao
        )
        {
            // 默认功法书图标为 110000
            const int skillIconId = 110000;
            // 默认功法书堆叠上限为 1
            const int maxNumber = 1;
            // 默认功法书词缀为空
            var empty = new List<int>();
            // 默认功法书不加入图鉴
            const int tuJianType = 0;
            // 默认功法书类型为 4:功法书
            const int type = 4;
            // 默认功法书大类型 1:消耗品
            const int vagueType = 1;
            // 默认可出售
            const int unsalable = 0;
            // 默认可使用次数 0:无限
            const int canUseNumber = 0;
            // 默认 NPC 可以使用 (实际上 NPC 不会主动使用技能书)
            const int npcCanUse = 1;

            return ItemJsonFactory.GetInstance(staticSkillId, skillIconId, maxNumber, staticSkillName, "", empty, tuJianType, shopType,
                staticSkillItemFlag, 0, 0, type, quality, typePinJie, stuTime, seid, vagueType, price, info, desc, unsalable,
                0, canUseNumber, npcCanUse, 0, 0, 0, 0, staticSkillWuDao);
        }
    }
}