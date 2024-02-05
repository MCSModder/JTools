using System.Collections.Generic;

namespace TierneyJohn.MiChangSheng.JTools.Util
{
    /// <summary>
    /// jsonData 数据载入工具类
    /// </summary>
    public static class JsonDataUtil
    {
        /// <summary>
        /// JsonData 数据插入工具类
        /// </summary>
        /// <param name="jsonObject">原始数据集</param>
        /// <param name="data">待插入新增数据</param>
        /// <param name="title">数据类型</param>
        public static void AddJsonData(this JSONObject jsonObject, Dictionary<string, JSONObject> data, string title)
        {
            foreach (var item in data)
            {
                if (jsonObject.HasField(item.Key))
                {
                    title.ChangeJsonDataWarn(item.Key);
                    jsonObject.SetField(item.Key, item.Value);
                }
                else
                {
                    title.AddJsonDataInfo(item.Key);
                    jsonObject.AddField(item.Key, item.Value);
                }
            }
        }

        /// <summary>
        /// JsonData Buff数据插入工具类
        /// </summary>
        /// <param name="instance">jsonData 实例</param>
        /// <param name="data">待插入新增数据</param>
        /// <param name="title">数据类型</param>
        public static void AddBuffJsonData(this jsonData instance, Dictionary<string, JSONObject> data, string title)
        {
            foreach (var item in data)
            {
                if (instance.BuffJsonData.HasField(item.Key) || instance._BuffJsonData.HasField(item.Key))
                {
                    title.ChangeJsonDataWarn(item.Key);
                    instance.BuffJsonData[item.Key] = item.Value;
                    instance._BuffJsonData.SetField(item.Key, item.Value);
                    instance.Buff[int.Parse(item.Key)] = new KBEngine.Buff(int.Parse(item.Key));
                }
                else
                {
                    title.AddJsonDataInfo(item.Key);
                    instance.BuffJsonData.Add(item.Key, item.Value);
                    instance._BuffJsonData.AddField(item.Key, item.Value);
                    instance.Buff.Add(int.Parse(item.Key), new KBEngine.Buff(int.Parse(item.Key)));
                }
            }
        }

        /// <summary>
        /// JsonData 物品数据插入工具类
        /// </summary>
        /// <param name="instance">jsonData 实例</param>
        /// <param name="data">待插入新增数据</param>
        /// <param name="title">数据类型</param>
        public static void AddItemJsonData(this jsonData instance, Dictionary<string, JSONObject> data, string title)
        {
            foreach (var item in data)
            {
                if (instance.ItemJsonData.HasField(item.Key) || instance._ItemJsonData.HasField(item.Key))
                {
                    title.ChangeJsonDataWarn(item.Key);
                    instance.ItemJsonData[item.Key] = item.Value;
                    instance._ItemJsonData.SetField(item.Key, item.Value);
                }
                else
                {
                    title.AddJsonDataInfo(item.Key);
                    instance.ItemJsonData.Add(item.Key, item.Value);
                    instance._ItemJsonData.AddField(item.Key, item.Value);
                }
            }
        }

        /// <summary>
        /// JsonData 神通数据插入工具类
        /// </summary>
        /// <param name="instance">jsonData 实例</param>
        /// <param name="data">待插入新增数据</param>
        /// <param name="title">数据类型</param>
        public static void AddSkillJsonData(this jsonData instance, Dictionary<string, JSONObject> data, string title)
        {
            foreach (var item in data)
            {
                if (instance.skillJsonData.HasField(item.Key) || instance._skillJsonData.HasField(item.Key))
                {
                    title.ChangeJsonDataWarn(item.Key);
                    instance.skillJsonData[item.Key] = item.Value;
                    instance._skillJsonData.SetField(item.Key, item.Value);
                }
                else
                {
                    title.AddJsonDataInfo(item.Key);
                    instance.skillJsonData.Add(item.Key, item.Value);
                    instance._skillJsonData.AddField(item.Key, item.Value);
                }
            }
        }

        /// <summary>
        /// JsonData 数据插入工具类
        /// </summary>
        /// <param name="instance">原始数据集</param>
        /// <param name="data">待插入新增数据</param>
        /// <param name="title">数据类型</param>
        public static void AddAnySeidJsonData(
            this JSONObject[] instance,
            Dictionary<int, Dictionary<string, JSONObject>> data,
            string title
        )
        {
            title.AddJsonDataInfo();
            foreach (var item in data)
            {
                if (instance[item.Key] == null)
                {
                    item.Key.ToString().AddJsonDataError("Seid is null.");
                }

                foreach (var seidItem in item.Value)
                {
                    if (instance[item.Key].HasField(seidItem.Key))
                    {
                        item.Key.ToString().ChangeJsonDataWarn("Seid is Exist.");
                        instance[item.Key].SetField(seidItem.Key, seidItem.Value);
                    }
                    else
                    {
                        instance[item.Key].AddField(seidItem.Key, seidItem.Value);
                    }
                }
            }
        }
    }
}