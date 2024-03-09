using TierneyJohn.MiChangSheng.JTools_Editor.Event;
using TierneyJohn.MiChangSheng.JTools.Manager;
using TierneyJohn.MiChangSheng.JTools.Util;
using UnityEngine;
using UnityEngine.UI;

namespace TierneyJohn.MiChangSheng.JTools_Editor.UI.PlotPanel
{
    public class PlotPanelUI : MonoBehaviour
    {
        #region 字段/属性声明

        public static PlotPanelUI Inst;

        private string _activeFlowchart;
        private string _activeBlock;

        public readonly PlotPanelEvent FlowchartClick = new();
        public readonly PlotPanelEvent BlockClick = new();

        #endregion


        #region 预制体组件

        private Transform _flowcharts;
        private Transform _blocks;

        private RectTransform _flowchartContent;
        private RectTransform _blockContent;

        private FlowchartItemUI _flowchartItem;
        private BlockItemUI _blockItem;

        private Button _execute;

        #endregion

        #region Unity 事件函数

        private void Awake()
        {
            Inst = this;

            _flowcharts = transform.GetChild(0).GetChild(1);
            _blocks = transform.GetChild(0).GetChild(2);

            _flowchartContent = _flowcharts.GetComponent<ScrollRect>().content;
            _blockContent = _blocks.GetComponent<ScrollRect>().content;

            _flowchartItem = transform.GetChild(0).GetChild(3).gameObject.AddComponent<FlowchartItemUI>();
            _blockItem = transform.GetChild(0).GetChild(4).gameObject.AddComponent<BlockItemUI>();

            _execute = transform.GetChild(2).GetComponent<Button>();
            _execute.enabled = false;
        }

        private void Start()
        {
            // 事件监听
            FlowchartClick.AddListener(FlowchartClickedListener);
            BlockClick.AddListener(BlockClickedListener);

            // Flowchart 修正显示大小
            var flowchartNames = FungusManager.Inst.GetAllFlowchartName();
            var newSize = _flowchartContent.sizeDelta.ChangeY(40 * flowchartNames.Count);
            _flowchartContent.sizeDelta = newSize;

            // Flowchart 数据加载
            foreach (var flowchartName in flowchartNames)
            {
                Instantiate(_flowchartItem, _flowchartContent).SetFlowchart(flowchartName);
            }

            _blockContent.gameObject.SetActive(false);
            _execute.onClick.AddListener(ExecuteListener);

            _flowchartItem.gameObject.SetActive(false);
            _blockItem.gameObject.SetActive(false);
        }

        #endregion

        #region 私有方法

        private void FlowchartClickedListener(string flowchartName)
        {
            _activeFlowchart = flowchartName;
            _execute.enabled = false;

            // 加载 Block 数据
            FungusManager.Inst.TryGetFlowchart(_activeFlowchart, out var flowchart);

            if (flowchart == null) return;

            // 重置 blockContent 数据
            _blockContent.gameObject.SetActive(true);
            _blockItem.gameObject.SetActive(true);
            _blockContent.transform.DestoryAllChild();

            // Block 修正显示大小
            var blockNames = flowchart.GetFlowchartBlockNames();
            var newSize = _blockContent.sizeDelta.ChangeY(40 * blockNames.Count);
            _blockContent.sizeDelta = newSize;

            // Block 数据加载
            foreach (var blockName in blockNames)
            {
                Instantiate(_blockItem, _blockContent).SetBlock(blockName);
            }

            _blockItem.gameObject.SetActive(false);
        }

        private void BlockClickedListener(string blockName)
        {
            _activeBlock = blockName;
            _execute.enabled = true;
        }

        private void ExecuteListener()
        {
            EditorUI.Inst.Close();
            FungusManager.Inst.TryGetFlowchart(_activeFlowchart, out var flowchart);
            flowchart.ExecuteBlock(_activeBlock);
            $"已通过剧情编辑面板执行：[{_activeFlowchart}]=>[{_activeBlock}]".Warn();
        }

        #endregion
    }
}