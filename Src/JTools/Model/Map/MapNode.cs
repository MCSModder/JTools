using System;
using System.Collections.Generic;
using UnityEngine;

namespace TierneyJohn.MiChangSheng.JTools.Model.Map;

/// <summary>地图节点数据</summary>
[Serializable]
public class MapNode
{
    #region 节点数据

    /// <summary>节点名称</summary>
    public string Name { get; set; }

    /// <summary>是否为城市节点</summary>
    public bool IsCity { get; set; }

    /// <summary>是否隐藏节点</summary>
    public bool IsHide { get; set; }

    /// <summary>节点坐标</summary>
    [field: NonSerialized]
    public Vector3 Position { get; set; }

    /// <summary>节点路径信息</summary>
    public Dictionary<MapNode, int> AdjacentEdges { get; set; } = new();

    /// <summary>固定 NPC 列表</summary>
    public List<int> StaticAvatars { get; set; } = [];

    /// <summary>节点 NPC 列表</summary>
    public List<int> Avatars { get; set; } = [];

    /// <summary>节点激活事件</summary>
    [field: NonSerialized]
    public Action Action { get; set; }

    #endregion

    #region 常规方法

    /// <summary>添加节点路径信息</summary>
    /// <param name="node">相邻节点</param>
    /// <param name="weight">路径权重</param>
    public void AddAdjacentNodes(MapNode node, int weight = 4) { AdjacentEdges[node] = weight; }

    /// <summary>节点激活事件</summary>
    public void Activate() { Action?.Invoke(); }

    #endregion

    #region NPC 处理

    public void AddStaticAvatar(int avatar)
    {
        if (!StaticAvatars.Contains(avatar)) StaticAvatars.Add(avatar);
    }

    public void AddAvatar(int avatar)
    {
        if (!Avatars.Contains(avatar)) Avatars.Add(avatar);
    }

    #endregion
}