using System;
using System.Collections.Generic;
using System.Linq;

namespace TierneyJohn.MiChangSheng.JTools.Model.Map;

/// <summary>地图数据</summary>
[Serializable]
public class MapInfo
{
    #region 地图节点数据处理

    /// <summary>地图编号</summary>
    public string Id { get; set; }

    /// <summary>地图名称</summary>
    public string Name { get; set; }

    /// <summary>地图节点数据集</summary>
    public Dictionary<string, MapNode> MapNodes { get; set; } = [];

    /// <summary>添加地图节点数据</summary>
    /// <param name="node">地图节点数据</param>
    public void AddNode(MapNode node) { MapNodes[node.Name] = node; }

    /// <summary>获取地图节点数据</summary>
    /// <param name="name">地图节点名称</param>
    /// <returns>节点数据</returns>
    public MapNode GetMapNode(string name) { return MapNodes.TryGetValue(name, out var node) ? node : null; }

    /// <summary>添加地图节点路径数据</summary>
    /// <param name="origin">原始节点</param>
    /// <param name="target">目标节点</param>
    /// <param name="weight">路径权重</param>
    public void AddEdge(MapNode origin, MapNode target, int weight = 4)
    {
        if (origin == null || target == null) return;
        origin.AddAdjacentNodes(target, weight);
        target.AddAdjacentNodes(origin, weight);
    }

    /// <summary>添加地图节点路径数据</summary>
    /// <param name="origin">原始节点名称</param>
    /// <param name="target">目标节点名称</param>
    /// <param name="weight">路径权重</param>
    public void AddEdge(string origin, string target, int weight = 4)
    {
        if (MapNodes.ContainsKey(origin) && MapNodes.ContainsKey(target))
            AddEdge(MapNodes[origin], MapNodes[target], weight);
    }

    #endregion

    #region 地图 NPC 处理

    /// <summary>清空地图所有的 NPC</summary>
    public void ClearAllNpc()
    {
        foreach (var mapNode in MapNodes.Values)
        {
            mapNode.Avatars.Clear();
        }
    }

    /// <summary>随机添加 NPC 数据</summary>
    /// <param name="avatarId">NPC 编号</param>
    public void RandomAddNpc(int avatarId)
    {
        MapNodes.Values.Where(node => !node.IsCity && !node.IsHide)
            .ToList()
            .OrderBy(_ => Guid.NewGuid())
            .ToList()
            .First()
            .AddAvatar(avatarId);
    }

    #endregion
}