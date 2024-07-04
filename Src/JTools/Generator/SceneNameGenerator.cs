using TierneyJohn.MiChangSheng.JTools.Model.Entity;
using TierneyJohn.MiChangSheng.JTools.Model.Enum.Map;

namespace TierneyJohn.MiChangSheng.JTools.Generator;

/// <summary>场景名称数据生成器</summary>
public static class SceneNameGenerator
{
    public static SceneNameEntity Generator(
        string id,
        string name,
        SceneType sceneType = SceneType.大地图,
        SceneSellType sellType = SceneSellType.宁州,
        int highLightId = 0,
        string outSideSceneName = "",
        int outSideScenePosition = 0
    )
    {
        return new SceneNameEntity
        {
            Id = id,
            Name = name,
            SceneType = sceneType,
            SellType = sellType,
            HighLightId = highLightId,
            OutSideSceneName = outSideSceneName,
            OutSideScenePosition = outSideScenePosition
        };
    }
}