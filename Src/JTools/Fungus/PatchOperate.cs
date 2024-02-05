using System;

namespace TierneyJohn.MiChangSheng.JTools.Fungus
{
    /// <summary>
    /// Fungus 剧情补丁数据类
    /// </summary>
    [Serializable]
    public class PatchOperate
    {
        /// <summary>
        /// Flowchart 名称
        /// </summary>
        public string flowchartName;

        /// <summary>
        /// Block ItemId
        /// </summary>
        public int blockId;

        /// <summary>
        /// Command ItemId
        /// </summary>
        public int commandId;

        /// <summary>
        /// 目标 Flowchart 名称
        /// </summary>
        public string targetFlowchart;

        /// <summary>
        /// 目标 Block 名称
        /// </summary>
        public string targetBlock;

        /// <summary>
        /// 是否执行完成
        /// </summary>
        public bool isExecute;

        /// <summary>
        /// 是否为前置补丁 (若为 True 则该补丁不会执行替换，而是插入到指定节点前方并在执行完毕后回到当前节点继续执行)
        /// </summary>
        public bool isPrefixPatch;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="flowchartName">Flowchart 名称</param>
        /// <param name="blockId">Block ItemId</param>
        /// <param name="commandId">Command ItemId</param>
        /// <param name="targetFlowchart">目标 Flowchart 名称</param>
        /// <param name="targetBlock">目标 Block 名称</param>
        /// <param name="isExecute">是否执行完成</param>
        /// <param name="isPrefixPatch">是否为前置补丁 (若为 True 则该补丁不会执行替换，而是插入到指定节点前方并在执行完毕后回到当前节点继续执行)</param>
        public PatchOperate(string flowchartName, int blockId, int commandId, string targetFlowchart,
            string targetBlock, bool isExecute = false, bool isPrefixPatch = false)
        {
            this.flowchartName = flowchartName;
            this.blockId = blockId;
            this.commandId = commandId;
            this.targetFlowchart = targetFlowchart;
            this.targetBlock = targetBlock;
            this.isExecute = isExecute;
            this.isPrefixPatch = isPrefixPatch;
        }
    }
}