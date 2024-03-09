using System.Collections.Generic;

namespace TierneyJohn.MiChangSheng.JTools.Factory;

/// <summary>
/// 饰品物品数据工厂类
/// </summary>
public class OrnamentsItemFactory
{
    /// <summary>
    /// 获取指定参数的 OrnamentsItem 实例方法
    /// </summary>
    /// <param name="ornamentsId">饰品物品编号</param>
    /// <param name="ornamentsIconId">饰品图标编号</param>
    /// <param name="ornamentsName">饰品名称</param>
    /// <param name="affix">饰品词缀</param>
    /// <param name="shopType">商店类型</param>
    /// <param name="ornamentsFlag">饰品标签</param>
    /// <param name="quality">饰品品阶</param>
    /// <param name="typePinJie">饰品小品阶</param>
    /// <param name="seid">饰品特性</param>
    /// <param name="price">饰品价格</param>
    /// <param name="info">饰品效果</param>
    /// <param name="desc">饰品描述</param>
    /// <param name="unsalable">是否非卖品</param>
    /// <returns>JSONObject 实例</returns>
    public static JSONObject GetInstance(
        int ornamentsId,
        int ornamentsIconId,
        string ornamentsName,
        List<int> affix,
        int shopType,
        List<int> ornamentsFlag,
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
        // 饰品类型 1
        const int ornamentsType = 2;
        // 大类型
        const int vagueType = 0;

        return ItemJsonFactory.GetInstance(ornamentsId, ornamentsIconId, maxNumber, ornamentsName, "", affix, 0,
            shopType, ornamentsFlag, 0, 0, ornamentsType, quality, typePinJie, 0, seid, vagueType, price, info, desc,
            unsalable, 0, 0, 0, 0, 0, 0, 0, []);
    }
}