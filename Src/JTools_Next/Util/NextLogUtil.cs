using SkySwordKill.Next.DialogSystem;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools_Next.Util
{
    /// <summary>
    /// Log 日志打印工具类 - Next 相关扩展
    /// </summary>
    public static class NextLogUtil
    {
        #region Next 自定义指令日志打印

        /// <summary>
        /// DialogEvent 指令日志常规信息打印 (会自动解析指令名称)
        /// </summary>
        /// <param name="command">DialogCommand 对象</param>
        /// <param name="message">打印信息</param>
        public static void DialogEventLog(this DialogCommand command, object message = null)
        {
            (message == null ? $"正在执行自定义指令: {command.Command}" : $"正在执行自定义指令: {command.Command} ==> {message}").Log();
        }

        /// <summary>
        /// DialogEvent 指令日志警告信息打印 (会自动解析指令名称)
        /// </summary>
        /// <param name="command">DialogCommand 对象</param>
        /// <param name="message">打印信息</param>
        public static void DialogEventWarn(this DialogCommand command, object message = null)
        {
            (message == null ? $"正在执行自定义指令: {command.Command}" : $"正在执行自定义指令: {command.Command} ==> {message}").Warn();
        }

        /// <summary>
        /// DialogEvent 指令日志异常信息打印 (会自动解析指令名称)
        /// </summary>
        /// <param name="command">DialogCommand 对象</param>
        /// <param name="message">打印信息</param>
        public static void DialogEventError(this DialogCommand command, object message = null)
        {
            (message == null ? $"正在执行自定义指令: {command.Command}" : $"正在执行自定义指令: {command.Command} ==> {message}").Error();
        }

        /// <summary>
        /// DialogEnv 指令日志常规信息打印 (因为无法从对象中解析名称，所以需要手动传入名称)
        /// </summary>
        /// <param name="commandName">自定义指令名称</param>
        /// <param name="message">打印信息</param>
        public static void DialogEnvLog(this string commandName, object message = null)
        {
            (message == null ? $"正在执行自定义指令: {commandName}" : $"正在执行自定义指令: {commandName} ==> {message}").Log();
        }

        /// <summary>
        /// DialogEnv 指令日志警告信息打印 (因为无法从对象中解析名称，所以需要手动传入名称)
        /// </summary>
        /// <param name="commandName">自定义指令名称</param>
        /// <param name="message">打印信息</param>
        public static void DialogEnvWarn(this string commandName, object message = null)
        {
            (message == null ? $"正在执行自定义指令: {commandName}" : $"正在执行自定义指令: {commandName} ==> {message}").Warn();
        }

        /// <summary>
        /// DialogEnv 指令日志异常信息打印 (因为无法从对象中解析名称，所以需要手动传入名称)
        /// </summary>
        /// <param name="commandName">自定义指令名称</param>
        /// <param name="message">打印信息</param>
        public static void DialogEnvError(this string commandName, object message = null)
        {
            (message == null ? $"正在执行自定义指令: {commandName}" : $"正在执行自定义指令: {commandName} ==> {message}").Error();
        }

        #endregion
    }
}