using System.Linq;
using JSONClass;
using TierneyJohn.MiChangSheng.JTools_Editor.Manager;
using TierneyJohn.MiChangSheng.JTools.Tool;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TierneyJohn.MiChangSheng.JTools_Editor.UI
{
    public class ToolPanelUI : MonoBehaviour
    {
        public static ToolPanelUI Inst;

        private string SceneNameInput => _sceneInput.text;

        #region 预制体组件

        private Transform _bug;

        private Button _exportBtn;
        private Button _logSettingBtn;
        private Button _logExportBtn;

        private Transform _scene;

        private TMP_InputField _sceneInput;
        private Button _loadSceneBtn;
        private Button _loadGameBtn;

        #endregion

        #region Unity 事件函数

        private void Awake()
        {
            Inst = this;

            _bug = transform.GetChild(0);
            _exportBtn = _bug.GetChild(0).GetComponent<Button>();
            _logSettingBtn = _bug.GetChild(1).GetComponent<Button>();
            _logExportBtn = _bug.GetChild(2).GetComponent<Button>();

            _scene = transform.GetChild(1);
            _sceneInput = _scene.GetChild(0).GetComponent<TMP_InputField>();
            _loadSceneBtn = _scene.GetChild(1).GetComponent<Button>();
            _loadGameBtn = _scene.GetChild(2).GetComponent<Button>();
        }

        private void Start()
        {
            _exportBtn.onClick.AddListener(EditorManager.Inst.ExportData);
            _logExportBtn.onClick.AddListener(EditorManager.Inst.ExportLog);
            _logSettingBtn.onClick.AddListener(EditorManager.Inst.SettingLogConfig);

            _loadSceneBtn.onClick.AddListener(() => CheckSceneName().LoadScene());
            _loadGameBtn.onClick.AddListener(() => CheckSceneName().LoadGame());
        }

        #endregion

        #region 私有方法

        private string CheckSceneName()
        {
            foreach (var sceneData in SceneNameJsonData.DataList
                         .Where(sceneData => sceneData.EventName.Equals(SceneNameInput)))
            {
                return sceneData.id;
            }

            return SceneNameInput;
        }

        #endregion
    }
}