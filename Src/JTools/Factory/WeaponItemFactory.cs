using System.Collections.Generic;

namespace TierneyJohn.MiChangSheng.JTools.Factory;

/// <summary>
/// 武器物品数据工厂类
/// </summary>
public class WeaponItemFactory
{
    /// <summary>
    /// 获取指定参数的 WeaponItem 实例方法
    /// </summary>
    /// <param name="weaponId">武器物品编号</param>
    /// <param name="weaponIconId">武器图标编号</param>
    /// <param name="weaponName">武器名称</param>
    /// <param name="faBaoType">武器样式</param>
    /// <param name="affix">武器词缀</param>
    /// <param name="shopType">商店类型</param>
    /// <param name="weaponFlag">武器标签</param>
    /// <param name="quality">武器品阶</param>
    /// <param name="typePinJie">武器小品阶</param>
    /// <param name="seid">武器特性</param>
    /// <param name="price">武器价格</param>
    /// <param name="info">武器效果</param>
    /// <param name="desc">武器描述</param>
    /// <param name="unsalable">是否非卖品</param>
    /// <returns>JSONObject 实例</returns>
    public static JSONObject GetInstance(
        int weaponId,
        int weaponIconId,
        string weaponName,
        string faBaoType,
        List<int> affix,
        int shopType,
        List<int> weaponFlag,
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
        // 武器类型
        const int weaponType = 0;
        // 大类型
        const int vagueType = 0;

        return ItemJsonFactory.GetInstance(weaponId, weaponIconId, maxNumber, weaponName, faBaoType, affix, 0, shopType,
            weaponFlag, 0, 0, weaponType, quality, typePinJie, 0, seid, vagueType, price, info, desc, unsalable, 0, 0,
            0, 0, 0, 0, 0, []);
    }
}