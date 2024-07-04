using System;
using System.Collections.Generic;
using System.Linq;
using TierneyJohn.MiChangSheng.JTools.Model.MapEvent;
using TierneyJohn.MiChangSheng.JTools.Util;
using UnityEngine;

namespace TierneyJohn.MiChangSheng.JTools.Manager;

/// <summary>
/// 自定义大地图事件管理器
/// </summary>
public class MapEventManager : MonoBehaviour
{
    #region 字段/属性定义

    public static MapEventManager Inst;

    private JSONObject AllMapRandomNode => PlayerEx.Player.AllMapRandomNode;

    private readonly Dictionary<int, MapEvent> _mapEvent = new();
    private readonly Dictionary<int, MapEventData> _mapEventData = new();

    #endregion

    #region JSONObject 字段常量名定义

    private const string EventId = "EventId";
    private const string Type = "Type";
    private const string Reset = "Reset";
    private const string ResetTime = "restTime";

    #endregion

    #region Unity事件函数

    private void Awake() { Inst = this; }

    #endregion

    #region 核心方法

    /// <summary>
    /// 刷新当前存储的所有大地图事件
    /// </summary>
    public void RefreshMapEventData()
    {
        // 验证事件激活条件
        foreach (var mapEvent in
            _mapEvent.Values.Where(mapEvent => !mapEvent.refreshFlag && mapEvent.Evaluate.Invoke()))
        {
            if (mapEvent.once)
            {
                mapEvent.refreshFlag = true;
                if (CheckMapEvent(mapEvent)) continue;
            }

            ActiveMapEvent(mapEvent);
        }

        // 验证事件过期条件
        foreach (var mapEvent in _mapEvent.Values)
        {
            if (string.IsNullOrEmpty(mapEvent.resetTime)) continue;

            if (PlayerEx.Player.worldTimeMag.getNowTime() < DateTime.Parse(mapEvent.resetTime)) continue;

            var nodes = AllMapRandomNode.list.FindAll(
                item => item.GetFieldInt(Type) == mapEvent.eventType && item.GetFieldInt(EventId) == mapEvent.eventId);

            foreach (var node in nodes)
            {
                node.SetField(EventId, "0");
                node.SetField(Type, 2);
                node.SetField(Reset, false);
                node.SetField(ResetTime, "0001-1-1");
            }

            mapEvent.result = true;
        }
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
            eventJsonData = AllMapRandomNode.GetField(nodeIndex.ToString());
        }
        else
        {
            eventJsonData = AllMapRandomNode.list
                    .FindAll(item => item.GetFieldInt(Type) == 2)
                    .OrderBy(_ => Guid.NewGuid())
                    .FirstOrDefault() ??
                JSONObject.Create();
        }

        eventJsonData.SetField(EventId, eventId);
        eventJsonData.SetField(Type, eventType);
        eventJsonData.SetField(Reset, false);
        eventJsonData.SetField(ResetTime, "0001-1-1");
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
    /// <param name="mapEvent">MapEvent 事件对象</param>
    public void ActiveMapEvent(MapEvent mapEvent)
    {
        ActiveMapEvent(mapEvent.nodeIndex, mapEvent.eventId, mapEvent.eventType);
    }

    /// <summary>
    /// 验证当前大地图节点事件是否存在
    /// </summary>
    /// <param name="eventId">事件编号</param>
    /// <param name="eventType">事件类型</param>
    /// <returns>验证结果</returns>
    public bool CheckMapEvent(int eventId, int eventType)
    {
        return AllMapRandomNode.list
            .FindAll(item => item.GetFieldInt(Type) == eventType && item.GetFieldInt(EventId) == eventId)
            .Any();
    }

    /// <summary>
    /// 验证当前大地图节点事件是否存在
    /// </summary>
    /// <param name="mapEvent">MapEvent 事件对象</param>
    /// <returns>验证结果</returns>
    public bool CheckMapEvent(MapEvent mapEvent) { return CheckMapEvent(mapEvent.eventId, mapEvent.eventType); }

    #endregion

    #region 常规公开方法

    /// <summary>
    /// 添加大地图事件
    /// </summary>
    /// <param name="mapEvent">MapEvent 事件对象</param>
    public void AddMapEvent(MapEvent mapEvent)
    {
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
    public bool HasMapEventData(int eventId) { return _mapEventData.ContainsKey(eventId); }

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
}