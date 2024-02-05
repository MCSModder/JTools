using System;

namespace TierneyJohn.MiChangSheng.JTools.Model
{
    /// <summary>
    /// 大地图事件数据封装类
    /// </summary>
    [Serializable]
    public class MapEvent
    {
        #region 字段声明

        /// <summary>
        /// 事件编号 (来源参考: MapRandomJsonData: id)
        /// 唯一编号，可以但是不建议与原版事件id重复
        /// </summary>
        public int eventId;

        /// <summary>
        /// 事件类型 (数据模型参考: AllMapReset: id)
        /// 可扩展，自定义事件类型
        /// 如果是自定义事件，本质上此处仅影响事件图标，具体事件执行逻辑参考 MapEventData 类定义
        /// </summary>
        public int eventType;

        /// <summary>
        /// 事件执行节点 (数据来源: AllMapRandomNode)
        /// 暂时仅支持大地图节点
        /// 若不传参数，或者参数值为0 则随机选定地图节点
        /// </summary>
        public int nodeIndex;

        /// <summary>
        /// 事件是否只执行一次
        /// </summary>
        public bool once;

        /// <summary>
        /// 事件执行结果
        /// 只用于是否重复触发，与事件内部的逻辑无关
        /// </summary>
        public bool result;

        /// <summary>
        /// 事件执行判定委托定义
        /// </summary>
        public delegate bool EvaluateDelegate();

        /// <summary>
        /// 事件执行判定委托对象
        /// </summary>
        public EvaluateDelegate Evaluate;

        #endregion

        #region 构造函数

        public MapEvent(int eventId, int eventType, EvaluateDelegate evaluate, int nodeIndex = 0, bool once = true,
            bool result = false)
        {
            this.eventId = eventId;
            this.eventType = eventType;
            this.nodeIndex = nodeIndex;
            this.once = once;
            this.result = result;
            Evaluate = evaluate;
        }

        public MapEvent(int eventId, int eventType, int nodeIndex, bool once, bool result, EvaluateDelegate evaluate)
        {
            this.eventId = eventId;
            this.eventType = eventType;
            this.nodeIndex = nodeIndex;
            this.once = once;
            this.result = result;
            Evaluate = evaluate;
        }

        #endregion
    }
}