using System.IO;
using System.IO.Compression;
using TierneyJohn.MiChangSheng.JTools_Editor.UI;
using TierneyJohn.MiChangSheng.JTools.Manager;
using UnityEngine;

namespace TierneyJohn.MiChangSheng.JTools_Editor.Manager
{
    /// <summary>
    /// 编辑器全局管理器
    /// </summary>
    public class EditorManager : MonoBehaviour
    {
        #region 字段/属性

        public static EditorManager Inst;
        private static Transform NewUI => NewUICanvas.Inst.transform;
        private static readonly bool UseEditor = JToolsEditorMain.UseEditor.Value;
        private static readonly KeyCode OpenEditorKeyCode = JToolsEditorMain.OpenEditor.Value;
        public bool editorState;

        #endregion

        #region 常量定义

        private const string EditorFileName = "jtoolseditor";
        private const string EditorComponentName = "JToolsEditor";

        private const string JToolsPath = "2951535735";
        private const string BepInExPath = "2824349934/BepInEx";
        private const string ConfigFileExtension = ".cfg";
        private const string LogFileExtension = ".log";

        #endregion

        #region Unity 事件函数

        private void Awake()
        {
            Inst = this;
        }

        private void Update()
        {
            if (!UseEditor) return;
            if (editorState || !Input.GetKeyDown(OpenEditorKeyCode)) return;

            editorState = true;
            LoadEditorUI();
        }

        #endregion

        #region 公开方法

        public void ExportData()
        {
            foreach (var file in WorkshopTool.GetModDirectory(BepInExPath).GetFiles())
            {
                if (!LogFileExtension.Equals(file.Extension)) continue;

                file.CopyTo($"{Paths.GetNewSavePath()}/{file.Name}", true);
            }

            var directory = new DirectoryInfo(Paths.GetNewSavePath());

            if (directory.Exists && directory.Parent != null && directory.Parent.Exists)
            {
                var fileName = $"{directory.Parent.FullName}/快捷导出存档数据.zip";

                var file = new FileInfo(fileName);
                if (file.Exists) file.Delete();

                ZipFile.CreateFromDirectory(directory.FullName, fileName);
                System.Diagnostics.Process.Start(directory.Parent.FullName);
            }
        }

        public void ExportLog()
        {
            foreach (var file in WorkshopTool.GetModDirectory(BepInExPath).GetFiles())
            {
                if (!LogFileExtension.Equals(file.Extension)) continue;

                System.Diagnostics.Process.Start(file.FullName);
                return;
            }
        }

        public void SettingLogConfig()
        {
            var jToolsDirectory = WorkshopTool.GetModDirectory(JToolsPath);
            var bepInExDirectory = WorkshopTool.GetModDirectory($"{BepInExPath}/config");

            foreach (var file in jToolsDirectory.GetFiles())
            {
                if (!ConfigFileExtension.Equals(file.Extension)) continue;

                file.CopyTo($"{bepInExDirectory.FullName}/BepInEx.cfg", true);
            }
        }

        #endregion

        #region 私有方法

        private void LoadEditorUI()
        {
            if (EditorUI.Inst)
            {
                EditorUI.Inst.gameObject.SetActive(true);
            }
            else
            {
                AssetBundleManager.Inst.SetAssetBundlePatch(typeof(JToolsEditorMain));
                AssetBundleManager.Inst.LoadUI<EditorUI>(EditorFileName, EditorComponentName, NewUI);
            }
        }

        #endregion
    }
}