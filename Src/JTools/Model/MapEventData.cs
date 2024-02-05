using System;
using System.Collections.Generic;

namespace TierneyJohn.MiChangSheng.JTools.Model
{
    /// <summary>
    /// 大地图事件数据信息封装类
    /// </summary>
    [Serializable]
    public class MapEventData
    {
        #region 字段声明

        /// <summary>
        /// 事件编号 (来源参考: AllMapShiJianOptionJsonData: id)
        /// 唯一编号，可以但是不建议与原版事件id重复
        /// </summary>
        public int eventId;

        /// <summary>
        /// 事件类型  (来源参考: MapRandomJsonData: EventList)
        /// 此处的事件类型可以区别于原版，执行自定义逻辑
        /// 当前暂未实现其他逻辑，仅用于地图随机事件框
        /// </summary>
        public int eventType;

        /// <summary>
        /// 事件名称 (来源参考: AllMapShiJianOptionJsonData: EventName)
        /// </summary>
        public string title;

        /// <summary>
        /// 事件描述 (来源参考: AllMapShiJianOptionJsonData: desc)
        /// </summary>
        public string content;

        /// <summary>
        /// 是否为最终节点
        /// </summary>
        public bool isFinal;

        /// <summary>
        /// 事件选项列表
        /// 参考大地图随机事件选项，不建议超过 3 个
        /// int：对应调用事件 eventId
        /// string： 对应选项名称
        /// </summary>
        public List<(int, string)> Options;

        /// <summary>
        /// 事件执行逻辑
        /// </summary>
        public Action Action;

        #endregion

        #region 构造函数

        public MapEventData(int eventId, int eventType, string title, string content, List<(int, string)> options,
            Action action, bool isFinal = false)
        {
            this.eventId = eventId;
            this.eventType = eventType;
            this.title = title;
            this.content = content;
            Options = options;
            Action = action;
            this.isFinal = isFinal;
        }

        #endregion
    }
}