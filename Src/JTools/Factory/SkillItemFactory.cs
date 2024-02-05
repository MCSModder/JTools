using System.Collections.Generic;

namespace TierneyJohn.MiChangSheng.JTools.Factory
{
    /// <summary>
    /// 神通物品数据工厂类
    /// </summary>
    public class SkillItemFactory
    {
        /// <summary>
        /// 获取指定参数的 SkillItemJson 实例方法
        /// </summary>
        /// <param name="skillId">技能书物品编号</param>
        /// <param name="skillName">技能名称</param>
        /// <param name="shopType">商店售卖类型</param>
        /// <param name="skillItemFlag">技能物品标签</param>
        /// <param name="quality">技能品阶 (1人，2地，3天)</param>
        /// <param name="typePinJie">技能小品阶 (1下，2中，3上)</param>
        /// <param name="stuTime">技能领悟时间</param>
        /// <param name="seid">技能书物品特性</param>
        /// <param name="price">技能书价格</param>
        /// <param name="info">技能书说明</param>
        /// <param name="desc">技能书描述</param>
        /// <param name="skillWuDao">领悟前置条件 (组)</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetInstance(
            int skillId,
            string skillName,
            int shopType,
            List<int> skillItemFlag,
            int quality,
            int typePinJie,
            int stuTime,
            List<int> seid,
            int price,
            string info,
            string desc,
            List<int> skillWuDao
        )
        {
            // 默认天阶技能书图标为 110000
            var skillIconId = quality == 3 ? 110000 : 120000;
            // 默认技能书堆叠上限为 1
            const int maxNumber = 1;
            // 默认技能书词缀为空
            var empty = new List<int>();
            // 默认技能书不加入图鉴
            const int tuJianType = 0;
            // 默认技能书类型为 3:技能书
            const int type = 3;
            // 默认技能书大类型 1:消耗品
            const int vagueType = 1;
            // 默认可出售
            const int unsalable = 0;
            // 默认可使用次数 0:无限
            const int canUseNumber = 0;
            // 默认 NPC 可以使用 (实际上 NPC 不会主动使用技能书)
            const int npcCanUse = 1;

            return ItemJsonFactory.GetInstance(skillId, skillIconId, maxNumber, skillName, "", empty, tuJianType, shopType,
                skillItemFlag, 0, 0, type, quality, typePinJie, stuTime, seid, vagueType, price, info, desc, unsalable,
                0, canUseNumber, npcCanUse, 0, 0, 0, 0, skillWuDao);
        }
    }
}