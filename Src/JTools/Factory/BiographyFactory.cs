namespace TierneyJohn.MiChangSheng.JTools.Factory;

/// <summary>
/// 生平数据工厂类
/// </summary>
public class BiographyFactory
{
    /// <summary>
    /// 获取指定参数的 ShengPingJson 数据
    /// </summary>
    /// <param name="id">生平记录名</param>
    /// <param name="info">生平记录信息</param>
    /// <param name="once">是否可重复显示</param>
    /// <param name="priority">优先级</param>
    /// <returns></returns>
    public static JSONObject GetInstance(string id, string info, int once = 0, int priority = 1)
    {
        var data = JSONObject.Create();
        data.SetField("id", id);
        data.SetField("descr", info);
        data.SetField("IsChongfu", once);
        data.SetField("priority", priority);
        return data;
    }
}