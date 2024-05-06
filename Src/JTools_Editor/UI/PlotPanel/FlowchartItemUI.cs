using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TierneyJohn.MiChangSheng.JTools_Editor.UI.PlotPanel
{
    public class FlowchartItemUI : MonoBehaviour
    {
        #region 预制体组件

        private TextMeshProUGUI _flowchartName;
        private Button _button;

        #endregion

        #region Unity 事件函数

        private void Awake()
        {
            _flowchartName = transform.GetComponent<TextMeshProUGUI>();
            _button = transform.GetComponent<Button>();
        }

        #endregion

        #region 公开方法

        public void SetFlowchart(string flowchartName)
        {
            _flowchartName.text = flowchartName;
            _button.onClick.AddListener(() => { PlotPanelUI.Inst.FlowchartClick.Invoke(_flowchartName.text); });
        }

        #endregion
    }
}