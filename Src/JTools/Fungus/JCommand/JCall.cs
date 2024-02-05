using System;
using System.Collections;
using System.Linq;
using Fungus;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools.Fungus.JCommand
{
    /// <summary>
    /// JTools 封装 Call 指令
    /// </summary>
    [Serializable]
    public class JCall : Call
    {
        #region 字段/属性

        protected string CallFlowchartName;
        protected string CallBlockName;
        protected int CommandItemId;

        #endregion

        #region 构造方法

        /// <summary>
        /// 跳转到其他 Fungus 块指令
        /// </summary>
        /// <param name="callBlock">目标 Block 对象</param>
        /// <param name="callFlowchart">目标 Flowchart 对象 (若为空则从当前 Flowchart 中查找)</param>
        /// <param name="commandItemId">执行目标 Block 对象时，从指定 Command 开始执行</param>
        /// <param name="mode">跳转模式 (默认跳转后直接关闭原始 Block)</param>
        /// <returns>JCall 对象</returns>
        public JCall Create(Block callBlock, Flowchart callFlowchart = null, int commandItemId = -1,
            CallMode mode = CallMode.Stop)
        {
            targetBlock = callBlock;
            targetFlowchart = callFlowchart;
            CommandItemId = commandItemId;
            callMode = mode;
            return this;
        }

        /// <summary>
        /// 跳转到其他 Fungus 块指令
        /// </summary>
        /// <param name="callBlockName">目标 Block 对象名称</param>
        /// <param name="callFlowchartName">目标 Flowchart 对象名称 (若为空则从当前 Flowchart 中查找)</param>
        /// <param name="commandItemId">执行目标 Block 对象时，从指定 Command 开始执行</param>
        /// <param name="mode">跳转模式 (默认跳转后直接关闭原始 Block)</param>
        /// <returns>JCall 对象</returns>
        public JCall Create(string callBlockName, string callFlowchartName = null, int commandItemId = -1,
            CallMode mode = CallMode.Stop)
        {
            CallFlowchartName = callFlowchartName;
            CallBlockName = callBlockName;
            CommandItemId = commandItemId;
            callMode = mode;
            return this;
        }

        /// <summary>
        /// 跳转到其他 Fungus 块指令
        /// </summary>
        /// <param name="operate">剧情补丁数据类</param>
        /// <param name="mode">跳转模式 (默认跳转后直接关闭原始 Block)</param>
        /// <returns>JCall 对象</returns>
        public JCall Create(PatchOperate operate, CallMode mode = CallMode.Stop) =>
            Create(operate.targetBlock, operate.targetFlowchart, mode: mode);

        #endregion

        #region 公开方法

        public override void OnEnter()
        {
            InitFungus();
            var flowchart = GetFlowchart();

            if (targetBlock != null)
            {
                if (ParentBlock != null && ParentBlock.Equals(targetBlock))
                {
                    Continue(0);
                    return;
                }

                if (targetBlock.IsExecuting())
                {
                    Continue();
                    return;
                }

                Action onComplete = null;

                if (callMode == CallMode.WaitUntilFinished)
                {
                    onComplete = Continue;
                }

                var commandIndex = startIndex;

                if (startLabel.Value != "")
                {
                    var labelIndex = targetBlock.GetLabelIndex(startLabel.Value);

                    if (labelIndex != -1)
                    {
                        commandIndex = labelIndex;
                    }
                }

                if (targetFlowchart == null || flowchart.Equals(targetFlowchart))
                {
                    if (flowchart.SelectedBlock == ParentBlock)
                    {
                        flowchart.SelectedBlock = targetBlock;
                    }

                    if (callMode == CallMode.StopThenCall)
                    {
                        StopParentBlock();
                    }

                    StartCoroutine(targetBlock.Execute(commandIndex, onComplete));
                }
                else
                {
                    if (callMode == CallMode.StopThenCall)
                    {
                        StopParentBlock();
                    }

                    StartCoroutine(AfterExecute(commandIndex, onComplete));
                }
            }

            if (callMode == CallMode.Stop)
            {
                StopParentBlock();
            }

            if (callMode == CallMode.Continue)
            {
                Continue();
            }
        }

        #endregion

        #region 私有方法

        private void InitFungus()
        {
            if (targetBlock == null)
            {
                if (CallFlowchartName == null)
                {
                    var flowchart = GetFlowchart();

                    if (flowchart != null)
                    {
                        targetBlock = flowchart.GetBlockByFlowchart(CallBlockName);
                    }

                    if (targetBlock == null)
                    {
                        $"Block 数据获取失败，未找到对应数据: [{flowchart.name}] : [{CallBlockName}]".FungusError();
                    }
                }
                else
                {
                    targetFlowchart = CallFlowchartName.GetFlowchartByName();

                    if (targetFlowchart == null)
                    {
                        $"Flowchart 数据获取失败，未找到对应数据: [{CallFlowchartName}]".FungusError();
                        return;
                    }

                    targetBlock = targetFlowchart.GetBlockByFlowchart(CallBlockName);

                    if (targetBlock == null)
                    {
                        $"Block 数据获取失败，未找到对应数据: [{CallFlowchartName}] : [{CallBlockName}]".FungusError();
                    }
                }
            }

            if (CommandItemId != -1)
            {
                foreach (var command in targetBlock.commandList.Where(command => command.ItemId == CommandItemId))
                {
                    startIndex = command.CommandIndex;
                }
            }
        }

        private IEnumerator AfterExecute(int commandIndex, Action onComplete)
        {
            yield return null;
            targetFlowchart.enabled = true;
            targetFlowchart.ExecuteBlock(targetBlock, commandIndex, onComplete);
        }

        private IEnumerator AfterBlockExecuting(int commandIndex)
        {
            yield return null;
            yield return targetBlock.Execute(commandIndex);
        }

        #endregion
    }
}