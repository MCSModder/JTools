using System.Collections.Generic;
using TierneyJohn.MiChangSheng.JTools.Model.Map;

namespace TierneyJohn.MiChangSheng.JTools.Generator;

/// <summary>地图数据生成器</summary>
public static class MapInfoGenerator
{
    public static MapInfo Generator(string id, string name) { return new MapInfo { Id = id, Name = name }; }

    public static void NodeGenerator(
        MapInfo mapInfo,
        string name,
        bool isCity = false,
        bool isHide = false,
        List<int> avatars = null
    )
    {
        avatars ??= [];

        mapInfo.MapNodes.Add(
            name,
            new MapNode { Name = name, IsCity = isCity, IsHide = isHide, StaticAvatars = avatars });
    }
}