using Newtonsoft.Json.Linq;
using SkySwordKill.Next.DialogSystem;

namespace TierneyJohn.MiChangSheng.JTools_Next.Util
{
    /// <summary>
    /// Next Dialog 指令数据获取扩展工具
    /// </summary>
    public static class NextDialogUtil
    {
        /// <summary>
        /// DialogCommand 数据获取方法
        /// </summary>
        /// <param name="command">DialogCommand 实例</param>
        /// <param name="index">数据索引值</param>
        /// <param name="defaultValue">默认值</param>
        /// <typeparam name="T">数据类型</typeparam>
        /// <returns>返回数据</returns>
        public static T GetValue<T>(this DialogCommand command, int index, T defaultValue = default)
        {
            var args = JArray.FromObject(command.ParamList);
            if (index >= args.Count) return defaultValue;
            var result = args[index].ToObject<T>();
            return result == null ? defaultValue : result;
        }

        /// <summary>
        /// DialogEnvQueryContext 数据获取方法
        /// </summary>
        /// <param name="context">DialogEnvQueryContext 实例</param>
        /// <param name="index">数据索引值</param>
        /// <param name="defaultValue">默认值</param>
        /// <typeparam name="T">数据类型</typeparam>
        /// <returns>返回数据</returns>
        public static T GetValue<T>(this DialogEnvQueryContext context, int index, T defaultValue = default)
        {
            var args = JArray.FromObject(context.Args);
            if (index >= args.Count) return defaultValue;
            var result = args[index].ToObject<T>();
            return result == null ? defaultValue : result;
        }
    }
}