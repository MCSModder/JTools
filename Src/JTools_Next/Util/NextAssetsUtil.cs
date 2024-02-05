using System.Text;

namespace TierneyJohn.MiChangSheng.JTools_Next.Util
{
    /// <summary>
    /// Next 资源处理工具类
    /// </summary>
    public static class NextAssetsUtil
    {
        /// <summary>
        /// 将常规资源名称整型为Next支持的资源名称
        /// </summary>
        /// <param name="assetName">资源名称</param>
        /// <returns>Next标准资源名称</returns>
        public static string ToNextAssetsName(this string assetName)
        {
            return new StringBuilder(assetName.ToLower())
                .Replace("assets/", "")
                .Replace("buff", "Buff")
                .Replace("item", "Item")
                .Replace("skill", "Skill")
                .Replace("staticskill", "StaticSkill")
                .Replace("staticSkill", "StaticSkill")
                .Replace("icon", "Icon")
                .Replace("cg", "CG")
                .Replace("res/effect/prefab/gameentity", "Effect/Prefab/gameEntity")
                .Replace("res/newui/tujian/image", "NewUI/TuJian/Image")
                .Replace("avater", "Avater")
                .Replace("dialogimage", "DialogImage")
                .Replace(".png", "")
                .ToString();
        }
    }
}