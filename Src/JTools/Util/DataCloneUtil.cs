using System.Collections.Generic;
using System.Linq;

namespace TierneyJohn.MiChangSheng.JTools.Util
{
    /// <summary>
    /// 数据 Clone 相关工具扩展
    /// </summary>
    public static class DataCloneUtil
    {
        /// <summary>
        /// List 数据深度 Clone 方法
        /// </summary>
        /// <param name="origin">原始数据</param>
        /// <typeparam name="T">数据类型</typeparam>
        /// <returns>Clone 数据</returns>
        public static List<T> Clone<T>(this IEnumerable<T> origin)
        {
            return origin == null ? [] : origin.ToList();
        }

        /// <summary>
        /// Dictionary 数据深度 Clone 方法
        /// </summary>
        /// <param name="origin">原始数据</param>
        /// <typeparam name="TK">Key 值类型</typeparam>
        /// <typeparam name="TV">Value 值类型</typeparam>
        /// <returns>Clone 数据</returns>
        public static Dictionary<TK, TV> Clone<TK, TV>(this Dictionary<TK, TV> origin)
        {
            return origin == null || !origin.Any() ? [] : origin.ToDictionary(item => item.Key, item => item.Value);
        }
    }
}