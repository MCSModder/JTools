using TierneyJohn.MiChangSheng.JTools_Editor.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace TierneyJohn.MiChangSheng.JTools_Editor.UI
{
    public class ToolPanelUI : MonoBehaviour
    {
        public static ToolPanelUI Inst;

        #region 预制体组件

        private Transform _bug;

        private Button _exportBtn;
        private Button _logSettingBtn;
        private Button _logExportBtn;

        #endregion

        #region Unity 事件函数

        private void Awake()
        {
            Inst = this;

            _bug = transform.GetChild(0);

            _exportBtn = _bug.GetChild(1).GetComponent<Button>();
            _logSettingBtn = _bug.GetChild(3).GetComponent<Button>();
            _logExportBtn = _bug.GetChild(5).GetComponent<Button>();
        }

        private void Start()
        {
            _exportBtn.onClick.AddListener(EditorManager.Inst.ExportData);
            _logExportBtn.onClick.AddListener(EditorManager.Inst.ExportLog);
            _logSettingBtn.onClick.AddListener(EditorManager.Inst.SettingLogConfig);
        }

        #endregion
    }
}