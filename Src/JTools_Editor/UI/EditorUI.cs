using TierneyJohn.MiChangSheng.JTools_Editor.Manager;
using TierneyJohn.MiChangSheng.JTools_Editor.UI.PlotPanel;
using TierneyJohn.MiChangSheng.JTools.Manager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TierneyJohn.MiChangSheng.JTools_Editor.UI
{
    /// <summary>
    /// 编辑器主界面
    /// </summary>
    public class EditorUI : MonoBehaviour, IUIClose
    {
        public static EditorUI Inst;

        #region 预制体组件

        private Transform _panel;
        private ToolPanelUI _toolPanel;
        private PlotPanelUI _plotPanel;
        private ResPanelUI _resPanel;

        private TextMeshProUGUI _panelTitle;
        private Button _exit;

        private Button _toolBtn;
        private Button _plotBtn;
        private Button _resBtn;

        private Sprite _normalSprite;
        private Sprite _highSprite;

        #endregion

        #region 常量定义

        private const string ToolTitle = "JTools 工具库";
        private const string PlotTitle = "JTools 剧情编辑器";
        private const string ResTitle = "JTools 资源面板";

        #endregion

        #region Unity 事件函数

        private void Awake()
        {
            Inst = this;

            _panel = transform.GetChild(0);
            _toolPanel = transform.GetChild(1).gameObject.AddMissingComponent<ToolPanelUI>();
            _plotPanel = transform.GetChild(2).gameObject.AddMissingComponent<PlotPanelUI>();
            _resPanel = transform.GetChild(3).gameObject.AddMissingComponent<ResPanelUI>();

            _panelTitle = _panel.GetChild(1).GetComponent<TextMeshProUGUI>();
            _exit = _panel.GetChild(2).GetComponent<Button>();

            _toolBtn = _panel.GetChild(3).GetChild(0).GetComponent<Button>();
            _plotBtn = _panel.GetChild(3).GetChild(1).GetComponent<Button>();
            _resBtn = _panel.GetChild(3).GetChild(2).GetComponent<Button>();

            _toolPanel.gameObject.SetActive(false);
            _plotPanel.gameObject.SetActive(false);
            _resPanel.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            UICloseManager.Inst.Register(this);
        }

        private void Start()
        {
            _exit.onClick.AddListener(TryClose);
            _toolBtn.onClick.AddListener(OnToolTab);
            _plotBtn.onClick.AddListener(OnPlotTab);
            _resBtn.onClick.AddListener(OnResTab);

            _normalSprite = Instantiate(_toolBtn.image.sprite);
            _highSprite = Instantiate(_toolBtn.spriteState.pressedSprite);
        }

        #endregion

        #region 公开方法

        public void TryClose()
        {
            EditorManager.Inst.editorState = false;
            UICloseManager.Inst.Logout(this);
            gameObject.SetActive(false);
        }

        #endregion

        #region 私有方法

        private void OnToolTab()
        {
            _panelTitle.text = ToolTitle;
            _toolPanel.gameObject.SetActive(true);
            _plotPanel.gameObject.SetActive(false);
            _resPanel.gameObject.SetActive(false);
            RefreshTab("Tool");
        }

        private void OnPlotTab()
        {
            if (PlayerEx.Player == null)
            {
                UIPopTip.Inst.Pop("该功能仅在游戏内有效！");
                return;
            }

            _panelTitle.text = PlotTitle;
            _toolPanel.gameObject.SetActive(false);
            _plotPanel.gameObject.SetActive(true);
            _resPanel.gameObject.SetActive(false);
            RefreshTab("Plot");
        }

        private void OnResTab()
        {
            _panelTitle.text = ResTitle;
            _toolPanel.gameObject.SetActive(false);
            _plotPanel.gameObject.SetActive(false);
            _resPanel.gameObject.SetActive(true);
            RefreshTab("Res");
        }

        private void RefreshTab(string tabBtn)
        {
            _toolBtn.image.sprite = "Tool".Equals(tabBtn) ? _highSprite : _normalSprite;
            _plotBtn.image.sprite = "Plot".Equals(tabBtn) ? _highSprite : _normalSprite;
            _resBtn.image.sprite = "Res".Equals(tabBtn) ? _highSprite : _normalSprite;
        }

        #endregion
    }
}