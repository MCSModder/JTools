namespace TierneyJohn.MiChangSheng.JTools.Model.Map;

/// <summary>地图路径数据</summary>
public class MapPath(MapNode targetNode, int weight)
{
    /// <summary>路径节点</summary>
    public MapNode TargetNode { get; set; } = targetNode;

    /// <summary>路径权重</summary>
    public int Weight { get; set; } = weight;
}