using System;
using Fungus;
using UnityEngine;

namespace TierneyJohn.MiChangSheng.JTools.Fungus
{
    /// <summary>
    /// JTools 封装 Flowchart 对象
    /// </summary>
    [Serializable]
    public class JFlowchart : Flowchart
    {
        #region 构造方法

        /// <summary>
        /// 创建并初始化一个 JFlowchart 对象
        /// </summary>
        /// <param name="jFlowChartName">Flowchart 名称</param>
        /// <param name="parent">Flowchart 挂载父对象</param>
        /// <returns>JFlowchart 对象</returns>
        public static JFlowchart Create(string jFlowChartName, GameObject parent = null)
        {
            if (parent == null)
            {
                parent = new GameObject();
            }

            var flowchart = new GameObject(jFlowChartName);
            flowchart.transform.SetParent(parent.transform);
            return flowchart.AddComponent<JFlowchart>();
        }

        /// <summary>
        /// 创建并初始化一个 JFlowchart 对象
        /// </summary>
        /// <param name="jBlockName">Flowchart 名称</param>
        /// <param name="callback">回调函数 (当 Flowchart 对象创建完成后自动执行)</param>
        /// <returns>JFlowchart 对象</returns>
        public JBlock CreateBlock(string jBlockName, Action<JBlock> callback = null)
        {
            var block = FindBlock(jBlockName) as JBlock;
            if (block != null)
            {
                return block;
            }

            var jBlock = gameObject.AddComponent<JBlock>();
            jBlock.Create(jBlockName);
            AddSelectedBlock(jBlock);
            callback?.Invoke(jBlock);
            return jBlock;
        }

        #endregion
    }
}