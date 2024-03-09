using System.Collections.Generic;

namespace TierneyJohn.MiChangSheng.JTools.Factory;

/// <summary>
/// 防具物品数据工厂类
/// </summary>
public class ArmorItemFactory
{
    /// <summary>
    /// 获取指定参数的 ArmorItem 实例方法
    /// </summary>
    /// <param name="armorId">防具物品编号</param>
    /// <param name="armorIconId">防具图标编号</param>
    /// <param name="armorName">防具名称</param>
    /// <param name="affix">防具词缀</param>
    /// <param name="shopType">商店类型</param>
    /// <param name="armorFlag">防具标签</param>
    /// <param name="quality">防具品阶</param>
    /// <param name="typePinJie">防具小品阶</param>
    /// <param name="seid">防具特性</param>
    /// <param name="price">防具价格</param>
    /// <param name="info">防具效果</param>
    /// <param name="desc">防具描述</param>
    /// <param name="unsalable">是否非卖品</param>
    /// <returns>JSONObject 实例</returns>
    public static JSONObject GetInstance(
        int armorId,
        int armorIconId,
        string armorName,
        List<int> affix,
        int shopType,
        List<int> armorFlag,
        int quality,
        int typePinJie,
        List<int> seid,
        int price,
        string info,
        string desc,
        int unsalable = 0
    )
    {
        // 最大堆叠数量 1
        const int maxNumber = 1;
        // 防具类型 1
        const int armorType = 1;
        // 大类型
        const int vagueType = 0;

        return ItemJsonFactory.GetInstance(armorId, armorIconId, maxNumber, armorName, "", affix, 0, shopType,
            armorFlag, 0, 0, armorType, quality, typePinJie, 0, seid, vagueType, price, info, desc, unsalable, 0, 0, 0,
            0, 0, 0, 0, []);
    }
}