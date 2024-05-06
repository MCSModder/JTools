namespace TierneyJohn.MiChangSheng.JTools.Factory;

public class ItemSeidFactory
{
    public static JSONObject GetSeid40Instance(int itemId, string flowchart, string block)
    {
        var data = JSONObject.Create();
        data.AddField("id", itemId);
        data.AddField("flowchart", flowchart);
        data.AddField("block", block);
        return data;
    }
}