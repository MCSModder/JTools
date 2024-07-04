using System.Linq;
using script.Steam;

namespace TierneyJohn.MiChangSheng.JTools.Util;

/// <summary>
/// Mod 相关工具类
/// </summary>
public static class ModUtil
{
    /// <summary>
    /// 验证当前 Mod 是否激活
    /// </summary>
    /// <param name="steamId">steam 工坊编号</param>
    /// <returns>验证结果</returns>
    public static bool CheckModActive(this ulong steamId) { return CheckModActive(steamId.ToString()); }

    /// <summary>
    /// 验证当前 Mod 是否激活
    /// </summary>
    /// <param name="steamId">steam 工坊编号</param>
    /// <returns>验证结果</returns>
    public static bool CheckModActive(this string steamId)
    {
        return WorkshopTool.GetAllModDirectory()
            .Where(directory => directory.Name.Equals(steamId))
            .Any(_ => !WorkshopTool.CheckModIsDisable(steamId));
    }

    /// <summary>
    /// 获取指定工坊编号的 Mod 信息
    /// </summary>
    /// <param name="steamId">Mod 工坊编号</param>
    /// <param name="modInfo">Mod 信息</param>
    /// <returns>获取结果</returns>
    public static bool TryGetModInfo(this ulong steamId, out ModInfo modInfo)
    {
        modInfo = default;

        if (WorkShopMag.Inst != null && WorkShopMag.Inst.ModInfoDict.TryGetValue(steamId, out var value))
        {
            $"已查询的有效的 Mod 信息: {steamId}".Log();
            modInfo = value;
            return true;
        }

        $"未能查询的有效的 Mod 信息: {steamId}".Warn();
        return false;
    }

    /// <summary>
    /// 获取指定工坊编号的 Mod 名称信息
    /// </summary>
    /// <param name="steamId">Mod 工坊编号</param>
    /// <returns>Mod 名称</returns>
    public static string GetModName(this ulong steamId)
    {
        if (WorkShopMag.Inst != null && WorkShopMag.Inst.ModInfoDict.TryGetValue(steamId, out var modInfo))
        {
            $"已查询的有效的 Mod 名称: {steamId} - {modInfo.Name}".Log();
            return modInfo.Name;
        }

        $"未能查询的有效的 Mod 名称: {steamId}".Warn();
        return steamId.ToString();
    }

    /// <summary>
    /// 获取指定工坊编号的 Mod 完整路径
    /// </summary>
    /// <param name="steamId"></param>
    /// <returns></returns>
    public static string GetModPath(this string steamId)
    {
        return $"{WorkshopTool.GetModDirectory(steamId)?.FullName}/plugins";
    }
}