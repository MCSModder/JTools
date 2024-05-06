using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TierneyJohn.MiChangSheng.JTools_Editor.UI.PlotPanel
{
    public class BlockItemUI : MonoBehaviour
    {
        #region 预制体组件

        private TextMeshProUGUI _blockName;
        private Button _button;

        #endregion

        #region Unity 事件函数

        private void Awake()
        {
            _blockName = transform.GetComponent<TextMeshProUGUI>();
            _button = transform.GetComponent<Button>();
        }

        #endregion

        #region 公开方法

        public void SetBlock(string blockName)
        {
            _blockName.text = blockName;
            _button.onClick.AddListener(() => { PlotPanelUI.Inst.BlockClick.Invoke(_blockName.text); });
        }

        #endregion
    }
}