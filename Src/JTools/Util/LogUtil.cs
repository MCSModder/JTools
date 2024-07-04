using System;
using System.IO;
using System.Text;
using TierneyJohn.MiChangSheng.JTools.Fungus;

namespace TierneyJohn.MiChangSheng.JTools.Util;

/// <summary>
/// Log 日志打印工具类
/// </summary>
public static class LogUtil
{
    #region 常规日志信息打印

    /// <summary>
    /// 封装控制台常规信息打印方法 (打印信息受控)
    /// </summary>
    /// <param name="message">常规信息</param>
    public static void Log(this object message)
    {
        if (JToolsCoreMain.UseInfoLog == null)
        {
            // 本地运行模式配置
            Console.WriteLine($"[JTools] {message}");
        }
        else if (JToolsCoreMain.UseInfoLog.Value)
        {
            // 线上模式配置
            JToolsCoreMain.Log(message);
        }
    }

    /// <summary>
    /// 封装控制台警告信息打印方法 (打印信息受控)
    /// </summary>
    /// <param name="message">警告信息</param>
    public static void Warn(this object message)
    {
        if (JToolsCoreMain.UseWarnLog == null)
        {
            // 本地运行模式配置
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[JTools] {message}");
            Console.ResetColor();
        }
        else if (JToolsCoreMain.UseWarnLog.Value)
        {
            // 线上模式配置
            JToolsCoreMain.Warn(message);
        }
    }

    /// <summary>
    /// 封装控制台异常信息打印方法 (打印信息受控)
    /// </summary>
    /// <param name="message">异常信息</param>
    public static void Error(this object message)
    {
        if (JToolsCoreMain.UseErrorLog == null)
        {
            // 本地运行模式配置
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[JTools] {message}");
            Console.ResetColor();
        }
        else if (JToolsCoreMain.UseErrorLog.Value)
        {
            // 线上模式配置
            JToolsCoreMain.Error(message);
        }
    }

    #endregion

    #region Mod标题信息打印

    /// <summary>
    /// 自定义标题信息打印
    /// </summary>
    /// <param name="title">标题信息</param>
    /// <param name="modName">Mod 名称</param>
    /// <param name="modVersion">Mod 版本</param>
    /// <param name="modInfo">Mod 描述</param>
    /// <param name="author">Mod 作者</param>
    public static void TitleLog(
        this string title,
        string modName,
        string author,
        string modVersion,
        string modInfo = ""
    )
    {
        Log($"===================={title} 开始加载====================");
        Log($"\t名称：{modName}");
        Log($"\t作者：{author}");
        Log($"\t版本：{modVersion}");
        Log($"\t描述：{modInfo}\n");
    }

    /// <summary>
    /// 自定义底部信息打印
    /// </summary>
    /// <param name="title">标题信息</param>
    public static void BottomLog(this string title) { Log($"===================={title} 加载完成===================="); }

    #endregion

    #region 存读档日志信息打印

    /// <summary>
    /// 文件存档常规信息打印
    /// </summary>
    /// <param name="fileName">文件名称</param>
    /// <param name="message">额外打印信息</param>
    public static void SaveInfo(this string fileName, object message = null)
    {
        Log(message == null ? $"[{fileName}]数据归档成功" : $"[{fileName}]数据归档成功: {message}");
    }

    /// <summary>
    /// 文件存档警告信息打印
    /// </summary>
    /// <param name="fileName">文件名称</param>
    /// <param name="message">额外打印信息</param>
    public static void SaveWarn(this string fileName, object message = null)
    {
        Warn(message == null ? $"[{fileName}]数据归档异常" : $"[{fileName}]数据归档异常: {message}");
    }

    /// <summary>
    /// 文件读取常规信息打印
    /// </summary>
    /// <param name="fileName">文件名称</param>
    /// <param name="message">额外打印信息</param>
    public static void LoadInfo(this string fileName, object message = null)
    {
        Log(message == null ? $"[{fileName}]数据读取成功" : $"[{fileName}]数据读取成功: {message}");
    }

    /// <summary>
    /// 文件读取常规信息打印
    /// </summary>
    /// <param name="fileName">文件名称</param>
    /// <param name="message">额外打印信息</param>
    public static void LoadWarn(this string fileName, object message = null)
    {
        Warn(message == null ? $"[{fileName}]数据读取失败" : $"[{fileName}]数据读取失败: {message}");
    }

    #endregion

    #region AssetBundle 数据信息打印

    public static void AssetBundleLoadInfo(this string fileName, object message = null)
    {
        Log(message == null ? $"AssetBundle[{fileName}]：数据加载成功" : $"AssetBundle[{fileName}]：{message}");
    }

    public static void AssetBundleLoadWarn(this string fileName, object message = null)
    {
        Warn(message == null ? $"AssetBundle[{fileName}]：数据加载异常" : $"AssetBundle[{fileName}]：{message}");
    }

    public static void AssetBundleLoadError(this string fileName, object message = null)
    {
        Error(message == null ? $"AssetBundle[{fileName}]：数据加载失败" : $"AssetBundle[{fileName}]：{message}");
    }

    #endregion

    #region Data 数据信息打印

    public static void DataLoadStart(this string title) { Log($"[{title}]数据开始加载"); }

    public static void DataLoadComplete(this string title) { Log($"[{title}]数据加载完成"); }

    public static void DataLoadWarn(this string title, int id) { Warn($"[{title}]数据加载时,编号 [{id}] 数据发生冲突,已执行替换操作"); }

    public static void DataLoadWarn(this string title, string id) { Warn($"[{title}]数据加载时,编号 [{id}] 数据发生冲突,已执行替换操作"); }

    public static void DataLoadError(this FileInfo file) { Error($"{file.Name} 数据加载失败,未知的数据类型"); }

    #endregion

    #region Spine 数据信息打印

    public static void SpineLoadInfo(this string fileName, object message = null)
    {
        Log(message == null ? $"Spine[{fileName}]：数据加载成功" : $"Spine[{fileName}]：{message}");
    }

    public static void SpineLoadWarn(this string fileName, object message = null)
    {
        Warn(message == null ? $"Spine[{fileName}]：数据加载异常" : $"Spine[{fileName}]：{message}");
    }

    public static void SpineLoadError(this string fileName, object message = null)
    {
        Error(message == null ? $"Spine[{fileName}]：数据加载失败" : $"Spine[{fileName}]：{message}");
    }

    public static void SpineConfigLoadInfo(this string fileName, object message = null)
    {
        Log(message == null ? $"SpineConfig[{fileName}]：数据加载成功" : $"SpineConfig[{fileName}]：{message}");
    }

    public static void SpineConfigLoadWarn(this string fileName, object message = null)
    {
        Warn(message == null ? $"SpineConfig[{fileName}]：数据加载异常" : $"SpineConfig[{fileName}]：{message}");
    }

    public static void SpineConfigLoadError(this string fileName, object message = null)
    {
        Error(message == null ? $"SpineConfig[{fileName}]：数据加载失败" : $"SpineConfig[{fileName}]：{message}");
    }

    #endregion

    #region jsonData 数据载入日志信息打印

    /// <summary>
    /// jsonData 数据载入常规信息打印
    /// </summary>
    /// <param name="dataInfo">数据信息</param>
    /// <param name="dataId">数据编号</param>
    public static void AddJsonDataInfo(this string dataInfo, string dataId = "")
    {
        Log(string.IsNullOrEmpty(dataId) ? $"正在载入{dataInfo}数据..." : $"正在载入{dataInfo}数据: {dataId}");
    }

    /// <summary>
    /// jsonData 数据修改警告信息打印
    /// </summary>
    /// <param name="dataInfo">数据信息</param>
    /// <param name="dataId">数据编号</param>
    public static void ChangeJsonDataWarn(this string dataInfo, string dataId = "")
    {
        Warn(string.IsNullOrEmpty(dataId) ? $"正在修改{dataInfo}数据..." : $"正在修改{dataInfo}数据: {dataId}");
    }

    /// <summary>
    /// jsonData 数据载入异常信息打印
    /// </summary>
    /// <param name="dataInfo">数据信息</param>
    /// <param name="message">异常信息</param>
    /// <param name="dataId">数据编号</param>
    public static void AddJsonDataError(this string dataInfo, object message, string dataId = "")
    {
        Error(string.IsNullOrEmpty(dataId) ? $"载入{dataInfo}数据失败: {message}" : $"载入{dataInfo}数据[{dataId}]失败: {message}");
    }

    #endregion

    #region 自定义Seid日志信息打印

    /// <summary>
    /// 自定义 Seid 常规信息打印
    /// </summary>
    /// <param name="seidId">Seid 编号</param>
    /// <param name="message">详细信息</param>
    /// <param name="title">Seid 类型</param>
    public static void RealizeSeidInfo(this object seidId, object message = null, object title = null)
    {
        var builder = new StringBuilder();
        builder.Append("正在执行");

        if (title != null)
        {
            builder.Append(title);
        }

        builder.Append("Seid").Append($"[{seidId}]");

        if (message != null)
        {
            builder.Append($": {message}");
        }

        Log(builder.ToString());
    }

    /// <summary>
    /// 自定义 Seid 警告信息打印
    /// </summary>
    /// <param name="seidId">Seid 编号</param>
    /// <param name="message">详细信息</param>
    /// <param name="title">Seid 类型</param>
    public static void RealizeSeidWarn(this object seidId, object message = null, object title = null)
    {
        var builder = new StringBuilder();
        builder.Append("正在执行");

        if (title != null)
        {
            builder.Append(title);
        }

        builder.Append("Seid").Append($"[{seidId}]");

        if (message != null)
        {
            builder.Append($": {message}");
        }

        Warn(builder.ToString());
    }

    /// <summary>
    /// 自定义 Seid 异常信息打印
    /// </summary>
    /// <param name="seidId">Seid 编号</param>
    /// <param name="message">详细信息</param>
    /// <param name="title">Seid 类型</param>
    public static void RealizeSeidError(this object seidId, object message = null, object title = null)
    {
        var builder = new StringBuilder();
        builder.Append("正在执行");

        if (title != null)
        {
            builder.Append(title);
        }

        builder.Append("Seid").Append($"[{seidId}]");

        if (message != null)
        {
            builder.Append($": {message}");
        }

        Error(builder.ToString());
    }

    #endregion

    #region Fungus 日志信息打印

    public static void FungusInfo(this object message) { Log($"Fungus 编辑器: {message}"); }

    public static void FungusWarn(this object message) { Warn($"Fungus 编辑器: {message}"); }

    public static void FungusError(this object message) { Error($"Fungus 编辑器: {message}"); }

    public static void FungusPatchSuccess(this PatchOperate operate)
    {
        $"成功添加剧情补丁: [{operate.flowchartName}] : [{operate.blockId}] : [{operate.commandId}] ===> [{operate.targetFlowchart}] : [{operate.targetBlock}]"
            .FungusInfo();
    }

    public static void FungusPatchConflict(this PatchOperate operate)
    {
        $"剧情补丁存在冲突: [{operate.flowchartName}] : [{operate.blockId}] : [{operate.commandId}] ===> 该补丁已存在".FungusInfo();
    }

    #endregion
}