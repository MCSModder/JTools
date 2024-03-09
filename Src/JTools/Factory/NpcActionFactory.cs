namespace TierneyJohn.MiChangSheng.JTools.Factory;

/// <summary>
/// NPCAction 数据工厂类
/// </summary>
public class NpcActionFactory
{
    /// <summary>
    /// 获取指定参数的 NPCAction 实例方法
    /// </summary>
    /// <param name="id">事件编号</param>
    /// <param name="weight">事件权重</param>
    /// <param name="panDing">事件判定</param>
    /// <param name="allMap">宁州大地图位置</param>
    /// <param name="fuBen">副本位置</param>
    /// <param name="isTask">是否关联任务</param>
    /// <param name="scene">出现场景</param>
    /// <param name="talk">触发对话</param>
    /// <returns>JSONObject 实例</returns>
    public static JSONObject GetInstance(
        int id,
        int weight = 3,
        int panDing = 0,
        int allMap = 0,
        int fuBen = 0,
        int isTask = 0,
        string scene = "Null",
        string talk = "无"
    )
    {
        var data = JSONObject.Create();
        data.SetField("id", id);
        data.SetField("QuanZhong", weight);
        data.SetField("PanDing", panDing);
        data.SetField("AllMap", allMap);
        data.SetField("FuBen", fuBen);
        data.SetField("IsTask", isTask);
        data.SetField("ThreeSence", scene);
        data.SetField("GuanLianTalk", talk);
        return data;
    }
}