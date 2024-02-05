using System;
using System.Collections.Generic;
using System.Linq;
using TierneyJohn.MiChangSheng.JTools.Model;
using TierneyJohn.MiChangSheng.JTools.Util;
using UnityEngine;

namespace TierneyJohn.MiChangSheng.JTools.Manager
{
    /// <summary>
    /// 自定义大地图事件管理器
    /// </summary>
    public class MapEventManager : MonoBehaviour
    {
        #region 字段/属性定义

        public static MapEventManager Inst;

        private JSONObject AllMapRandomNode => PlayerEx.Player.AllMapRandomNode;

        private readonly Dictionary<int, MapEvent> _mapEvent = new Dictionary<int, MapEvent>();
        private readonly Dictionary<int, MapEventData> _mapEventData = new Dictionary<int, MapEventData>();

        #endregion

        #region JSONObject 字段常量名定义

        private const string EventId = "EventId";
        private const string Type = "Type";
        private const string Reset = "Reset";
        private const string ResetTime = "restTime";

        #endregion

        #region Unity事件函数

        private void Awake()
        {
            Inst = this;
        }

        #endregion

        #region 核心方法

        /// <summary>
        /// 刷新当前存储的所有大地图事件
        /// </summary>
        public void RefreshMapEventData()
        {
            foreach (var mapEventData in _mapEvent.Values)
            {
                if (mapEventData.Evaluate.Invoke())
                {
                    if (mapEventData.once)
                    {
                        mapEventData.result = true;
                    }

                    ActiveMapEvent(mapEventData);
                }
            }

            CheckMapEvent();
        }

        /// <summary>
        /// 激活大地图节点事件配置
        /// </summary>
        /// <param name="nodeIndex">待激活节点</param>
        /// <param name="eventId">事件编号(数据模型参考: MapRandomJsonData: id)</param>
        /// <param name="eventType">事件类型(数据模型参考: AllMapReset: EventType)</param>
        public void ActiveMapEvent(int nodeIndex, int eventId, int eventType)
        {
            JSONObject eventJsonData;

            if (AllMapRandomNode.HasField(nodeIndex.ToString()))
            {
                eventJsonData = PlayerEx.Player.AllMapRandomNode.GetField(nodeIndex.ToString());
            }
            else
            {
                eventJsonData = AllMapRandomNode.list
                    .FindAll(item => item.GetFieldInt(Type) == 2)
                    .OrderBy(f => Guid.NewGuid())
                    .FirstOrDefault() ?? JSONObject.Create();
            }

            eventJsonData.SetField(EventId, eventId);
            eventJsonData.SetField(Type, eventType);
            eventJsonData.SetField(Reset, "false");
            eventJsonData.SetField(ResetTime, "0001-01-01");
        }

        /// <summary>
        /// 激活大地图节点事件配置
        /// </summary>
        /// <param name="nodeIndex">待激活节点</param>
        /// <param name="eventData">事件数据(数据模型参考: MapRandomJsonData)</param>
        public void ActiveMapEvent(int nodeIndex, JSONObject eventData)
        {
            ActiveMapEvent(nodeIndex, eventData.GetFieldInt(EventId), eventData.GetFieldInt(Type));
        }

        /// <summary>
        /// 激活大地图节点事件配置
        /// </summary>
        /// <param name="mapEvent">MapEventData 数据对象</param>
        public void ActiveMapEvent(MapEvent mapEvent)
        {
            ActiveMapEvent(mapEvent.nodeIndex, mapEvent.eventId, mapEvent.eventType);
        }

        #endregion

        #region 常规公开方法

        /// <summary>
        /// 添加大地图事件
        /// </summary>
        /// <param name="mapEvent">MapEvent 事件对象</param>
        public void AddMapEvent(MapEvent mapEvent)
        {
            CheckMapEvent();

            var eventId = mapEvent.eventId;

            if (_mapEvent.ContainsKey(eventId))
            {
                $"MapManager: 事件[{eventId}] 已存在,执行替换操作".Warn();
            }

            _mapEvent[eventId] = mapEvent;
        }

        /// <summary>
        /// 添加大地图事件数据
        /// </summary>
        /// <param name="mapEventData">MapEventData 数据对象</param>
        public void AddMapEventData(MapEventData mapEventData)
        {
            var eventId = mapEventData.eventId;

            if (_mapEventData.ContainsKey(eventId))
            {
                $"MapManager: 事件数据[{eventId}] 已存在,执行替换操作".Warn();
            }

            _mapEventData[eventId] = mapEventData;
        }

        /// <summary>
        /// 判定是否含有指定大地图事件数据
        /// </summary>
        /// <param name="eventId">事件数据编号</param>
        /// <returns>判定结果</returns>
        public bool HasMapEventData(int eventId)
        {
            return _mapEventData.ContainsKey(eventId);
        }

        /// <summary>
        /// 获取指定自定义大地图事件数据
        /// </summary>
        /// <param name="eventId">事件数据编号</param>
        /// <returns>MapEventData 数据对象</returns>
        public MapEventData GetMapEventData(int eventId)
        {
            _mapEventData.TryGetValue(eventId, out var eventData);
            return eventData;
        }

        #endregion

        #region 私有方法

        private void CheckMapEvent()
        {
            var keysToRemove = _mapEvent.Where(item => item.Value == null || item.Value.result)
                .Select(item => item.Key).ToList();

            foreach (var key in keysToRemove)
            {
                _mapEvent.Remove(key);
            }
        }

        #endregion
    }
}