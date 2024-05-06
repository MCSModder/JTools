using BepInEx;
using BepInEx.Configuration;
using TierneyJohn.MiChangSheng.JTools;
using TierneyJohn.MiChangSheng.JTools_Editor.Manager;
using UnityEngine;
using GameObject = UnityEngine.GameObject;

namespace TierneyJohn.MiChangSheng.JTools_Editor
{
    [BepInDependency("TierneyJohn.MiChangSheng.JTools")]
    [BepInPlugin("TierneyJohn.MiChangSheng.JTools_Editor", "JTools_Editor", JToolsCoreMain.ModVersion)]
    public class JToolsEditorMain : BaseUnityPlugin
    {
        #region 静态公开字段

        public static JToolsEditorMain Instance { get; private set; }

        public static ConfigEntry<bool> UseEditor => Instance._useEditor;
        public static ConfigEntry<KeyCode> OpenEditor => Instance._openEditor;

        private ConfigEntry<bool> _useEditor;
        private ConfigEntry<KeyCode> _openEditor;

        #endregion

        #region Unity 事件函数

        private void Awake()
        {
            Instance = this;
            InitKeyCodeConfig();
            InitManager();
        }

        #endregion

        #region 私有方法

        private void InitKeyCodeConfig()
        {
            _useEditor = Config.Bind("编辑器配置", "编辑器启用配置", false, "是否开启游戏内置编辑器");
            _openEditor = Config.Bind("编辑器配置", "编辑器呼出快捷键", KeyCode.Alpha9, "游戏内点击该热键，可呼出游戏内置编辑器");
        }

        private void InitManager()
        {
            var editor = new GameObject("JTools_Editor", typeof(EditorManager));
            DontDestroyOnLoad(editor);
        }

        #endregion
    }
}