using System.Linq;
using Fungus;
using UnityEngine;
using FungusManager = TierneyJohn.MiChangSheng.JTools.Manager.FungusManager;

namespace TierneyJohn.MiChangSheng.JTools.Util
{
    /// <summary>
    /// Fungus 相关工具类
    /// </summary>
    public static class FungusUtil
    {
        /// <summary>
        /// 获取特定 Flowchart 对象
        /// </summary>
        /// <param name="flowchartName">Flowchart 对象名称</param>
        /// <returns>Flowchart 对象数据 (或 null)</returns>
        public static Flowchart GetFlowchartByName(this string flowchartName)
        {
            var flowchart = FungusManager.Inst.GetFlowchart(flowchartName);

            if (flowchart != null)
            {
                return flowchart;
            }

            // 遍历当前已加载 Flowchart
            var go = GameObject.Find($"{flowchartName}") ?? GameObject.Find($"{flowchartName}(Clone)");

            // 当前已加载有同名 Flowchart 直接复用
            if (go != null) return go.GetComponentInChildren<Flowchart>();

            // 当前未找到同名 Flowchart 从资源文件重新加载
            go = Resources.Load<GameObject>($"talkPrefab/TalkPrefab/{flowchartName}");

            // 未能找到对应的 Flowchart 数据，直接判空
            if (go == null) return null;

            // 已成功加载 Flowchart 数据，重新实例化该数据
            var gameObject = go.transform.Find("Flowchart").gameObject;
            var result = Object.Instantiate(gameObject).GetComponentInChildren<Flowchart>();
            result.name = flowchartName;
            result.gameObject.SetActive(true);
            return result;
        }

        /// <summary>
        /// 获取特定 Flowchart 对象内的 Block 对象
        /// </summary>
        /// <param name="flowchart">Flowchart 对象</param>
        /// <param name="blockName">Block 对象名称</param>
        /// <returns>Block 对象数据 (或 null)</returns>
        public static Block GetBlockByFlowchart(this Flowchart flowchart, string blockName)
        {
            return flowchart.GetComponents<Block>().FirstOrDefault(item =>
                item.BlockName.Equals(blockName) || (int.TryParse(blockName, out var value) && item.ItemId == value));
        }
    }
}