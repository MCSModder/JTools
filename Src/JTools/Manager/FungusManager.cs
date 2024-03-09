using System.Collections.Generic;
using System.Linq;
using Fungus;
using TierneyJohn.MiChangSheng.JTools.Fungus;
using TierneyJohn.MiChangSheng.JTools.Util;
using UnityEngine;

namespace TierneyJohn.MiChangSheng.JTools.Manager
{
    /// <summary>
    /// Fungus 自定义剧情管理器
    /// </summary>
    public class FungusManager : MonoBehaviour
    {
        #region 字段/属性

        public static FungusManager Inst;

        private readonly Dictionary<string, JFlowchart> _flowcharts = new();
        private readonly List<PatchOperate> _patchOperates = [];

        private string _cacheInnerFightFlowchartName;
        private string _cacheInnerFightBlockName;
        private string _cacheAfterFightFlowchartName;
        private string _cacheAfterFightBlockName;

        #endregion

        #region Unity事件函数

        private void Awake()
        {
            Inst = this;
        }

        #endregion

        #region Fungus 数据注册方法

        /// <summary>
        /// 注册并获取一个 Flowchart 对象 (其中 Flowchart 名称不能重复,若名称重复则会获取原本存在的 Flowchart 对象)
        /// </summary>
        /// <param name="flowchartName">Flowchart 名称</param>
        /// <param name="parent">Flowchart 挂载父对象</param>
        /// <returns>JFlowchart 对象</returns>
        public JFlowchart RegisterFlowchart(string flowchartName, GameObject parent = null)
        {
            CheckFlowcharts();

            if (_flowcharts.TryGetValue(flowchartName, out var registerFlowchart))
            {
                "当前 Flowchart 已存在,无法创建新的 Flowchart 对象,正在返回当前存在的 Flowchart 对象".Error();
                return registerFlowchart;
            }

            var flowchart = JFlowchart.Create(flowchartName, parent == null ? gameObject : parent);
            _flowcharts.Add(flowchartName, flowchart);
            return flowchart;
        }

        /// <summary>
        /// 注册并添加一个 Flowchart 对象 (其中 Flowchart 名称不能重复,若名称重复则会获取原本存在的 Flowchart 对象)
        /// </summary>
        /// <param name="flowchartName">Flowchart 名称</param>
        /// <param name="flowchart">JFlowchart 对象</param>
        /// <returns>JFlowchart 对象</returns>
        public JFlowchart RegisterFlowchart(string flowchartName, JFlowchart flowchart)
        {
            CheckFlowcharts();

            if (_flowcharts.TryGetValue(flowchartName, out var registerFlowchart))
            {
                "当前 Flowchart 已存在,无法创建新的 Flowchart 对象,正在返回当前存在的 Flowchart 对象".Error();
                return registerFlowchart;
            }

            _flowcharts.Add(flowchartName, flowchart);
            return flowchart;
        }

        /// <summary>
        /// 注册并获取一个 Block 对象 (会将 Block 数据注册到指定 Flowchart 之中，如若该 Flowchart 未创建，则会初始化一个新的 Flowchart 对象)
        /// </summary>
        /// <param name="flowchartName">Flowchart 名称</param>
        /// <param name="blockName">JBlock 对象名称</param>
        /// <returns>JBlock 对象</returns>
        public JBlock RegisterBlock(string flowchartName, string blockName)
        {
            TryGetFlowchart(flowchartName, out var flowchart);
            return flowchart.CreateBlock(blockName);
        }

        /// <summary>
        /// 注册并获取一个 Command 对象 (会将 Command 数据注册到指定 Flowchart 内的指定 Block 之中，如若该 Flowchart 未创建，则会初始化一个新的 Flowchart 对象)
        /// </summary>
        /// <param name="flowchartName">Flowchart 名称</param>
        /// <param name="blockName">JBlock 对象名称</param>
        /// <param name="command">Command 对象</param>
        /// <returns>Command 对象</returns>
        public Command RegisterCommand(string flowchartName, string blockName, Command command)
        {
            TryGetFlowchart(flowchartName, out var flowchart);
            var block = flowchart.FindBlock(blockName);

            if (block == null)
            {
                return flowchart.CreateBlock(blockName).CreateCommand(command);
            }

            var jBlock = block as JBlock;

            if (jBlock != null)
            {
                return jBlock.CreateCommand(command);
            }

            "当前 Block 是原生 Block,暂不支持修改".Error();
            return null;
        }

        /// <summary>
        /// 注册 FungusPatch 数据补丁
        /// </summary>
        /// <param name="flowchartName">待修改 Flowchart 名称</param>
        /// <param name="blockId">待修改 BlockId</param>
        /// <param name="commandId">待修改 CommandId</param>
        /// <param name="targetFlowchart">跳转 Flowchart 名称</param>
        /// <param name="targetBlock">跳转 Block 名称</param>
        /// <param name="isPrefixPatch">是否为前置补丁</param>
        /// <returns>PatchOperate 数据</returns>
        public PatchOperate RegisterPatchOperate(string flowchartName, int blockId, int commandId,
            string targetFlowchart, string targetBlock, bool isPrefixPatch = false)
        {
            foreach (var operate in _patchOperates.Where(operate =>
                         operate.flowchartName == flowchartName && operate.blockId == blockId &&
                         operate.commandId == commandId))
            {
                operate.FungusPatchConflict();
                operate.targetFlowchart = targetFlowchart;
                operate.targetBlock = targetBlock;
                operate.isPrefixPatch = isPrefixPatch;
                return operate;
            }

            var patchOperate = new PatchOperate(flowchartName, blockId, commandId, targetFlowchart, targetBlock, false,
                isPrefixPatch);
            _patchOperates.Add(patchOperate);
            return patchOperate;
        }

        /// <summary>
        /// 注册战斗时缓存剧情数据
        /// </summary>
        /// <param name="flowchartName">剧情 Flowchart 名称</param>
        /// <param name="blockName">剧情 Block 名称</param>
        public void RegisterInnerFightData(string flowchartName, string blockName)
        {
            _cacheInnerFightFlowchartName = flowchartName;
            _cacheInnerFightBlockName = blockName;
        }

        /// <summary>
        /// 注册战斗后缓存剧情数据
        /// </summary>
        /// <param name="flowchartName">剧情 Flowchart 名称</param>
        /// <param name="blockName">剧情 Block 名称</param>
        public void RegisterAfterFightData(string flowchartName, string blockName)
        {
            _cacheAfterFightFlowchartName = flowchartName;
            _cacheAfterFightBlockName = blockName;
        }

        #endregion

        #region Fungus 剧情数据获取方法

        /// <summary>
        /// 存在指定名称的 Flowchart 数据
        /// </summary>
        /// <param name="flowchartName">Flowchart 名称</param>
        /// <returns>验证结果</returns>
        public bool HasFlowchart(string flowchartName)
        {
            return _flowcharts.ContainsKey(flowchartName);
        }

        /// <summary>
        /// 获取所有 JFlowchart 剧情名称
        /// </summary>
        /// <returns>剧情名称集合</returns>
        public List<string> GetAllFlowchartName()
        {
            return _flowcharts.Keys.ToList();
        }

        /// <summary>
        /// 获取所有剧情补丁数据
        /// </summary>
        /// <returns>剧情补丁数据集</returns>
        public List<PatchOperate> GetAllOperates()
        {
            CheckOperates();
            return _patchOperates;
        }

        #endregion

        #region Fungus 剧情调用核心方法

        /// <summary>
        /// 执行指定剧情方法
        /// </summary>
        /// <param name="flowchartName">剧情 Flowchart 名称</param>
        /// <param name="blockName">剧情 Block 名称</param>
        public void Execute(string flowchartName, string blockName)
        {
            CheckFlowcharts();

            if (_flowcharts.TryGetValue(flowchartName, out var flowchart))
            {
                flowchart.ExecuteBlock(blockName);
                return;
            }

            "当前 Flowchart 不存在,无法执行对应剧情".Error();
        }

        /// <summary>
        /// 执行战斗时缓存剧情方法
        /// </summary>
        public void ExecuteInnerFightCache()
        {
            if (string.IsNullOrEmpty(_cacheInnerFightFlowchartName)) return;
            if (string.IsNullOrEmpty(_cacheInnerFightBlockName)) return;

            Execute(_cacheInnerFightFlowchartName, _cacheInnerFightBlockName);
            _cacheInnerFightFlowchartName = null;
            _cacheInnerFightBlockName = null;
        }

        /// <summary>
        /// 执行战斗后缓存剧情方法
        /// </summary>
        public void ExecuteAfterFightCache()
        {
            Execute(_cacheAfterFightFlowchartName, _cacheAfterFightBlockName);
        }

        #endregion

        #region 常规公开方法

        /// <summary>
        /// 重载 Flowchart 数据方法
        /// </summary>
        /// <param name="flowchartName">剧情 Flowchart 名称</param>
        /// <param name="flowchart">JFlowchart 对象</param>
        public void TryReloadFlowchart(string flowchartName, JFlowchart flowchart)
        {
            RemoveFlowchart(flowchartName);
            RegisterFlowchart(flowchartName, flowchart);
        }

        /// <summary>
        /// 获取指定 Flowchart 数据方法
        /// </summary>
        /// <param name="flowchartName">剧情 Flowchart 名称</param>
        /// <param name="flowchart">JFlowchart 对象</param>
        public void TryGetFlowchart(string flowchartName, out JFlowchart flowchart)
        {
            flowchart = GetFlowchart(flowchartName);

            if (flowchart == null)
            {
                flowchart = RegisterFlowchart(flowchartName);
            }
        }

        /// <summary>
        /// 获取指定 Flowchart 数据方法
        /// </summary>
        /// <param name="flowchartName">剧情 Flowchart 名称</param>
        /// <returns></returns>
        public JFlowchart GetFlowchart(string flowchartName)
        {
            CheckFlowcharts();
            _flowcharts.TryGetValue(flowchartName, out var flowchart);
            return flowchart;
        }

        /// <summary>
        /// 移除指定 Flowchart 数据方法
        /// </summary>
        /// <param name="flowchartName">剧情 Flowchart 名称</param>
        public void RemoveFlowchart(string flowchartName)
        {
            if (!_flowcharts.ContainsKey(flowchartName))
            {
                return;
            }

            _flowcharts.TryGetValue(flowchartName, out var flowchart);
            if (flowchart != null)
            {
                flowchart.transform.DestoryAllChild();
                Destroy(flowchart.gameObject);
            }

            _flowcharts.Remove(flowchartName);
        }

        /// <summary>
        /// 清空当前缓存剧情方法
        /// </summary>
        public void Clear()
        {
            foreach (var flowchart in _flowcharts.Values)
            {
                flowchart.transform.DestoryAllChild();
                Destroy(flowchart.gameObject);
            }

            _flowcharts.Clear();
            _patchOperates.Clear();
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 验证当前剧情补丁数据集
        /// </summary>
        private void CheckOperates()
        {
            var operatesToRemoves = _patchOperates.Where(operate => operate.isExecute).ToList();

            foreach (var operate in operatesToRemoves)
            {
                _patchOperates.Remove(operate);
            }
        }

        /// <summary>
        /// 验证当前缓存的 Flowchart 数据集
        /// </summary>
        private void CheckFlowcharts()
        {
            var keysToRemove = _flowcharts.Where(item => item.Value == null)
                .Select(item => item.Key).ToList();

            foreach (var key in keysToRemove)
            {
                _flowcharts.Remove(key);
            }
        }

        #endregion
    }
}