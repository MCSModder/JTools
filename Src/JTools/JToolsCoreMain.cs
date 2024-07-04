using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using TierneyJohn.MiChangSheng.JTools.Manager;
using UnityEngine;

namespace TierneyJohn.MiChangSheng.JTools;

/// <summary>
/// JTools 插件入口方法
/// </summary>
[BepInPlugin("TierneyJohn.MiChangSheng.JTools", "JTools", ModVersion)]
public class JToolsCoreMain : BaseUnityPlugin
{
    #region 公开静态字段/属性/方法

    /// <summary>
    /// JTools 插件版本信息
    /// </summary>
    public const string ModVersion = "2.1.15";

    /// <summary>
    /// JTools Log 日志打印方法封装
    /// </summary>
    /// <param name="message">常规信息</param>
    public static void Log(object message) => I.Logger.LogInfo(message);

    /// <summary>
    /// JTools Log 日志打印方法封装
    /// </summary>
    /// <param name="message">警告信息</param>
    public static void Warn(object message) => I.Logger.LogWarning(message);

    /// <summary>
    /// JTools Log 日志打印方法封装
    /// </summary>
    /// <param name="message">异常信息</param>
    public static void Error(object message) => I.Logger.LogError(message);

    public static ConfigEntry<bool> UseInfoLog { get; private set; }

    public static ConfigEntry<bool> UseWarnLog { get; private set; }

    public static ConfigEntry<bool> UseErrorLog { get; private set; }

    public static ConfigEntry<bool> UseSeidExtension { get; private set; }

    public static ConfigEntry<bool> UseNextExtension { get; private set; }

    #endregion

    #region 私有字段/属性

    /// <summary>
    /// JTools 插件 Main 方法单例对象
    /// </summary>
    private static JToolsCoreMain I { get; set; }

    private const string HarmonyPatchPath = "TierneyJohn.MiChangSheng.BepInExPlugin.JTools.Patch";
    private Harmony _harmony;

    #endregion

    #region Unity 事件函数

    private void Awake()
    {
        I = this;
        Log($"JTools 正在加载,当前版本为: {ModVersion}");
        InitHarmony();
        InitKeyCodeConfig();
        InitManager();
    }

    #endregion

    #region 私有方法

    private void InitHarmony()
    {
        _harmony = new Harmony(HarmonyPatchPath);
        _harmony.PatchAll();
    }

    private void InitKeyCodeConfig()
    {
        UseInfoLog = Config.Bind("模式开关", "是否打印常规信息", false, "开启后，会在控制台Info级别的日志信息；关闭后，将隐藏Info级别的日志信息");
        UseWarnLog = Config.Bind("模式开关", "是否打印警告信息", true, "开启后，会在控制台Warn级别的日志信息；关闭后，将隐藏Warn级别的日志信息");
        UseErrorLog = Config.Bind("模式开关", "是否打印异常信息", true, "开启后，会在控制台Error级别的日志信息；关闭后，将隐藏Error级别的日志信息");
        UseSeidExtension = Config.Bind("功能开关", "是否启用Seid扩展", true, "开启后，将获得额外的Seid特性支持；关闭后，提供的额外Seid支持将会失效");
        UseNextExtension = Config.Bind("功能开关", "是否启用Next扩展", true, "开启后，会在Next编辑器中提供扩展内容；关闭后，Next编辑器将保持原版内容");
    }

    private void InitManager()
    {
        DontDestroyOnLoad(
            new GameObject(
                "JTools",
                typeof(ArchiveManager),
                typeof(AssetBundleManager),
                typeof(CgManager),
                typeof(DataManager),
                typeof(FungusManager),
                typeof(MapEventManager),
                typeof(NpcPopManager),
                typeof(SpineManager),
                typeof(UICloseManager),
                typeof(TimeFlagManager)));
    }

    #endregion
}