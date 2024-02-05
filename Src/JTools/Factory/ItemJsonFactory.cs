using System.Collections.Generic;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools.Factory
{
    /// <summary>
    /// 物品数据工厂类
    /// </summary>
    public class ItemJsonFactory
    {
        /// <summary>
        /// 获取指定参数的 ItemJson 实例方法
        /// </summary>
        /// <param name="itemId">物品编号</param>
        /// <param name="itemIconId">物品图标编号</param>
        /// <param name="maxNumber">物品最大堆叠数量</param>
        /// <param name="name">物品名称</param>
        /// <param name="faBaoType">法宝类型(法宝专用)</param>
        /// <param name="affix">法宝词缀(法宝专用)</param>
        /// <param name="tuJianType">图鉴类型(1草药，2矿物，3妖兽材料，4丹药)</param>
        /// <param name="shopType">商店售卖类型</param>
        /// <param name="itemFlag">物品标签</param>
        /// <param name="wuWeiType">五维类型(炼器材料专用)</param>
        /// <param name="shuXingType">属性类别(炼器材料专用)</param>
        /// <param name="type">物品类型(0武器1衣服2饰品3技能书4功法书5丹药6药材7任务8矿石9丹炉10丹方11药渣12书籍13书籍（需要时间）14灵舟15秘药16其它)</param>
        /// <param name="quality">物品品阶</param>
        /// <param name="typePinJie">功法技能品阶(功法技能专用)</param>
        /// <param name="stuTime">领悟时间(功法技能专用)</param>
        /// <param name="seid">物品特性</param>
        /// <param name="vagueType">大类型(0不可使用，1消耗品)</param>
        /// <param name="price">价格</param>
        /// <param name="info">物品说明</param>
        /// <param name="desc">物品描述</param>
        /// <param name="unsalable">是否是非卖品</param>
        /// <param name="danDu">丹毒量(丹药专属)</param>
        /// <param name="canUseNumber">可使用次数(丹药书籍专属)</param>
        /// <param name="npcCanUse">NPC是否可以使用</param>
        /// <param name="drugPrimer">药引药性(草药专属)</param>
        /// <param name="mainDrug">主药药性(草药专属)</param>
        /// <param name="adjuvant">辅药药性(草药专属)</param>
        /// <param name="shuaXin">刷新时间</param>
        /// <param name="wuDao">领悟前置条件(功法神通专属)</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetInstance(
            int itemId,
            int itemIconId,
            int maxNumber,
            string name,
            string faBaoType,
            List<int> affix,
            int tuJianType,
            int shopType,
            List<int> itemFlag,
            int wuWeiType,
            int shuXingType,
            int type,
            int quality,
            int typePinJie,
            int stuTime,
            List<int> seid,
            int vagueType,
            int price,
            string info,
            string desc,
            int unsalable,
            int danDu,
            int canUseNumber,
            int npcCanUse,
            int drugPrimer,
            int mainDrug,
            int adjuvant,
            int shuaXin,
            List<int> wuDao
        )
        {
            var data = JSONObject.Create();
            data.AddField("id", itemId);
            data.AddField("ItemIcon", itemIconId);
            data.AddField("maxNum", maxNumber);
            data.AddField("name", name);
            data.AddField("FaBaoType", faBaoType);
            data.AddField("Affix", affix.ToJsonObject());
            data.AddField("TuJianType", tuJianType);
            data.AddField("ShopType", shopType);
            data.AddField("ItemFlag", itemFlag.ToJsonObject());
            data.AddField("WuWeiType", wuWeiType);
            data.AddField("ShuXingType", shuXingType);
            data.AddField("type", type);
            data.AddField("quality", quality);
            data.AddField("typePinJie", typePinJie);
            data.AddField("StuTime", stuTime);
            data.AddField("seid", seid.ToJsonObject());
            data.AddField("vagueType", vagueType);
            data.AddField("price", price);
            data.AddField("desc", info);
            data.AddField("desc2", desc);
            data.AddField("CanSale", unsalable);
            data.AddField("DanDu", danDu);
            data.AddField("CanUse", canUseNumber);
            data.AddField("NPCCanUse", npcCanUse);
            data.AddField("yaoZhi1", drugPrimer);
            data.AddField("yaoZhi2", mainDrug);
            data.AddField("yaoZhi3", adjuvant);
            data.AddField("ShuaXin", shuaXin);
            data.AddField("wuDao", wuDao.ToJsonObject());
            return data;
        }
    }
}