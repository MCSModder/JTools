using BepInEx;
using HarmonyLib;
using SkySwordKill.Next.Mod;
using TierneyJohn.MiChangSheng.JTools;
using TierneyJohn.MiChangSheng.JTools_Editor;
using TierneyJohn.MiChangSheng.JTools_Next.Util;

namespace TierneyJohn.MiChangSheng.JTools_Next
{
    [BepInDependency("TierneyJohn.MiChangSheng.JTools")]
    [BepInDependency("TierneyJohn.MiChangSheng.JTools_Editor")]
    [BepInDependency("skyswordkill.plugin.Next")]
    [BepInPlugin("TierneyJohn.MiChangSheng.JTools_Next", "JTools_Next", JToolsCoreMain.ModVersion)]
    public class JToolsNextMain : BaseUnityPlugin
    {
        #region NextConfig 配置键声明

        private const string UseInfoLogKey = "JTools_UseInfoLog";
        private const string UseWarnLogKey = "JTools_UseWarnLog";
        private const string UseErrorLogKey = "JTools_UseErrorLog";
        private const string UseSeidExtensionKey = "JTools_UseSeidExtension";
        private const string UseNextExtensionKey = "JTools_UseNextExtension";
        private const string UseEditor = "JTools_Editor_UseEditor";

        #endregion

        #region 静态公开字段

        public static JToolsNextMain Instance { get; private set; }

        #endregion

        #region 私有字段

        private Harmony _harmony;

        #endregion

        #region Unity 事件函数

        private void Awake()
        {
            Instance = this;
            InitHarmony();
            InitModManager();
        }

        #endregion

        #region 私有方法

        private void InitHarmony()
        {
            _harmony = new Harmony("TierneyJohn.MiChangSheng.BepInExPlugin.JTools_Next.Patch");
            _harmony.PatchAll();
        }

        private void InitModManager()
        {
            InitSettingAction();
            ModManager.ModLoadComplete += InitLoadComplete;
            ModManager.ModSettingChanged += InitSettingChanged;
        }

        private void InitSettingAction()
        {
            JToolsCoreMain.UseInfoLog.InitModSettingAction(UseInfoLogKey);
            JToolsCoreMain.UseWarnLog.InitModSettingAction(UseWarnLogKey);
            JToolsCoreMain.UseErrorLog.InitModSettingAction(UseErrorLogKey);
            JToolsCoreMain.UseSeidExtension.InitModSettingAction(UseSeidExtensionKey);
            JToolsCoreMain.UseNextExtension.InitModSettingAction(UseNextExtensionKey);
            JToolsEditorMain.UseEditor.InitModSettingAction(UseEditor);
        }

        private void InitLoadComplete()
        {
            JToolsCoreMain.UseInfoLog.InitModLoadComplete(UseInfoLogKey);
            JToolsCoreMain.UseWarnLog.InitModLoadComplete(UseWarnLogKey);
            JToolsCoreMain.UseErrorLog.InitModLoadComplete(UseErrorLogKey);
            JToolsCoreMain.UseSeidExtension.InitModLoadComplete(UseSeidExtensionKey);
            JToolsCoreMain.UseNextExtension.InitModLoadComplete(UseNextExtensionKey);
            JToolsEditorMain.UseEditor.InitModLoadComplete(UseEditor);
        }

        private void InitSettingChanged()
        {
            JToolsCoreMain.UseInfoLog.InitModSettingChanged(UseInfoLogKey);
            JToolsCoreMain.UseWarnLog.InitModSettingChanged(UseWarnLogKey);
            JToolsCoreMain.UseErrorLog.InitModSettingChanged(UseErrorLogKey);
            JToolsCoreMain.UseSeidExtension.InitModSettingChanged(UseSeidExtensionKey);
            JToolsCoreMain.UseNextExtension.InitModSettingChanged(UseNextExtensionKey);
            JToolsEditorMain.UseEditor.InitModSettingChanged(UseEditor);
        }

        #endregion
    }
}