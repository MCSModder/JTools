namespace TierneyJohn.MiChangSheng.JTools.Factory;

/// <summary>
/// 场景数据工厂类
/// </summary>
public class SceneNameFactory
{
    /// <summary>
    /// 获取指定参数的 SceneNameJson 数据
    /// </summary>
    /// <param name="id">地图加载名</param>
    /// <param name="name">地图名称</param>
    /// <param name="mapType">地图类型</param>
    /// <param name="moneyType">地图商店类型</param>
    /// <param name="outSceneName">外部场景名称</param>
    /// <returns>JSONObject 实例</returns>
    public static JSONObject GetInstance(
        string id,
        string name,
        int mapType = 1,
        int moneyType = 1,
        string outSceneName = ""
    )
    {
        var data = JSONObject.Create();
        data.SetField("id", id);
        data.SetField("EventName", name);
        data.SetField("MapType", mapType);
        data.SetField("MoneyType", moneyType);
        data.SetField("MapName", name);
        data.SetField("HighlightID", 0);
        data.SetField("OutsideSceneName", outSceneName);
        data.SetField("OutsideScenePos", 0);
        return data;
    }
}