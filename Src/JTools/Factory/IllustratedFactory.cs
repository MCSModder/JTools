namespace TierneyJohn.MiChangSheng.JTools.Factory
{
    /// <summary>
    /// 词缀数据工厂类
    /// </summary>
    public class IllustratedFactory
    {
        /// <summary>
        /// 获取指定参数的 Affix 实例
        /// </summary>
        /// <param name="id">Affix 编号</param>
        /// <param name="name">Affix 名称</param>
        /// <param name="info">Affix 描述</param>
        /// <param name="type">Affix 类型</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetAffixInstance(int id, string name, string info, int type)
        {
            var data = JSONObject.Create();
            data.AddField("id", id);
            data.AddField("name1", "词缀");
            data.AddField("typenum", 101);
            data.AddField("type", type);
            data.AddField("name2", name);
            data.AddField("descr", info);
            return data;
        }

        /// <summary>
        /// 获取指定参数的 Gameplay 实例
        /// </summary>
        /// <param name="id">Gameplay 编号</param>
        /// <param name="name">Gameplay 名称</param>
        /// <param name="subNum">Gameplay 子项排序</param>
        /// <param name="info">Gameplay 描述</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetGameplayInstance(int id, string name, int subNum, string info)
        {
            var data = JSONObject.Create();
            data.AddField("id", id);
            data.AddField("name", "玩法说明");
            data.AddField("typenum", 506);
            data.AddField("subname", name);
            data.AddField("subtypenum", subNum);
            data.AddField("descr", info);
            return data;
        }
    }
}