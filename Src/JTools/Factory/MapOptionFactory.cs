using System.Collections.Generic;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools.Factory
{
    /// <summary>
    /// 大地图事件数据工厂类
    /// </summary>
    public class MapOptionFactory
    {
        /// <summary>
        /// 获取指定参数的 MapRandomJson 数据
        /// </summary>
        /// <param name="id">随机事件编号</param>
        /// <param name="eventName">事件名称</param>
        /// <param name="eventType">事件类型（0: 随机事件,1: 随机战斗,2: 无事发生,3: 支路采集,4: 支路遗迹,5: 支路无事发生,6: 主要事件,7: 日常任务）</param>
        /// <param name="eventList">事件场景(0: 对话,1: 事件,2: 战斗,3: 采集)</param>
        /// <param name="eventData">事件附加值</param>
        /// <param name="startTime">起始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="eventValue">变量组(x,y)</param>
        /// <param name="fuHao">变量关系(大于、等于、小于)</param>
        /// <param name="eventLv">触发角色等级</param>
        /// <param name="once">是否只触发一次</param>
        /// <param name="percent">权重(推荐: 5， 30， 50)</param>
        /// <param name="eventCastTime">消耗时间</param>
        /// <param name="masterId">战斗对象</param>
        /// <param name="icon">图标</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetMapRandomInstance(
            int id,
            string eventName,
            int eventType,
            int eventList,
            int eventData,
            string startTime,
            string endTime,
            List<int> eventLv,
            List<int> eventValue = null,
            string fuHao = "",
            int once = 1,
            int percent = 50,
            int eventCastTime = 1,
            int masterId = 0,
            string icon = ""
        )
        {
            var data = JSONObject.Create();
            data.SetField("id", id);
            data.SetField("EventName", eventName);
            data.SetField("EventType", eventType);
            data.SetField("EventList", eventList);
            data.SetField("EventData", eventData);
            data.SetField("once", once);
            data.SetField("StartTime", startTime);
            data.SetField("EndTime", endTime);
            data.SetField("EventLv", eventLv.ToJsonObject());
            data.SetField("EventValue", eventValue.ToJsonObject());
            data.SetField("fuhao", fuHao);
            data.SetField("percent", percent);
            data.SetField("EventCastTime", eventCastTime);
            data.SetField("MosterID", masterId);
            data.SetField("Icon", icon);
            return data;
        }

        /// <summary>
        /// 获取指定参数的 AllMapShiJianOptionJson 数据
        /// </summary>
        /// <param name="id">事件编号</param>
        /// <param name="eventName">事件名称</param>
        /// <param name="desc">事件描述</param>
        /// <param name="option1">子事件编号</param>
        /// <param name="option2">子事件编号</param>
        /// <param name="option3">子事件编号</param>
        /// <param name="optionDesc1">子事件描述</param>
        /// <param name="optionDesc2">子事件描述</param>
        /// <param name="optionDesc3">子事件描述</param>
        /// <param name="optionID">触发编号</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetMapOptionInstance(
            int id,
            string eventName,
            string desc,
            int option1,
            string optionDesc1,
            int option2 = 0,
            string optionDesc2 = "",
            int option3 = 0,
            string optionDesc3 = "",
            int optionID = 0
        )
        {
            var data = JSONObject.Create();
            data.SetField("id", id);
            data.SetField("EventName", eventName);
            data.SetField("desc", desc);
            data.SetField("optionID", optionID);
            data.SetField("option1", option1);
            data.SetField("optionDesc1", optionDesc1);
            data.SetField("option2", option2);
            data.SetField("optionDesc2", optionDesc2);
            data.SetField("option3", option3);
            data.SetField("optionDesc3", optionDesc3);
            return data;
        }

        /// <summary>
        /// 获取指定参数的 AllMapShiJianOptionJson 数据
        /// </summary>
        /// <param name="id">事件编号</param>
        /// <param name="eventName">事件名称</param>
        /// <param name="desc">事件描述</param>
        /// <param name="optionA">选项A数据</param>
        /// <param name="optionB">选项B数据</param>
        /// <param name="optionC">选项C数据</param>
        /// <param name="optionID">触发编号</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetMapOptionInstance(
            int id,
            string eventName,
            string desc,
            (int, string) optionA,
            (int, string) optionB,
            (int, string) optionC,
            int optionID = 0
        )
        {
            var data = JSONObject.Create();
            data.SetField("id", id);
            data.SetField("EventName", eventName);
            data.SetField("desc", desc);
            data.SetField("optionID", optionID);
            data.SetField("option1", optionA.Item1);
            data.SetField("optionDesc1", optionA.Item2);
            data.SetField("option2", optionB.Item1);
            data.SetField("optionDesc2", optionB.Item2);
            data.SetField("option3", optionC.Item1);
            data.SetField("optionDesc3", optionC.Item2);
            return data;
        }

        /// <summary>
        /// 获取指定参数的 AllMapShiJianOptionJson 数据
        /// </summary>
        /// <param name="id">事件编号</param>
        /// <param name="eventName">事件名称</param>
        /// <param name="desc">事件描述</param>
        /// <param name="options">选项数据</param>
        /// <param name="optionID">触发编号</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetMapOptionInstance(
            int id,
            string eventName,
            string desc,
            List<(int, string)> options,
            int optionID = 0
        )
        {
            var data = JSONObject.Create();
            data.SetField("id", id);
            data.SetField("EventName", eventName);
            data.SetField("desc", desc);
            data.SetField("optionID", optionID);

            if (options.Count >= 1)
            {
                data.SetField("option1", options[0].Item1);
                data.SetField("optionDesc1", options[0].Item2);
            }
            else
            {
                data.SetField("option1", 0);
                data.SetField("optionDesc1", "");
            }

            if (options.Count >= 2)
            {
                data.SetField("option2", options[1].Item1);
                data.SetField("optionDesc2", options[1].Item2);
            }
            else
            {
                data.SetField("option2", 0);
                data.SetField("optionDesc2", "");
            }

            if (options.Count >= 3)
            {
                data.SetField("option3", options[2].Item1);
                data.SetField("optionDesc3", options[2].Item2);
            }
            else
            {
                data.SetField("option3", 0);
                data.SetField("optionDesc3", "");
            }

            return data;
        }

        /// <summary>
        /// 获取指定参数的 AllMapOptionJson 数据
        /// </summary>
        /// <param name="id">子事件编号</param>
        /// <param name="eventName">子事件名称</param>
        /// <param name="desc">子事件描述</param>
        /// <param name="time">子事件时间变化</param>
        /// <param name="money">子事件金钱变化</param>
        /// <param name="exp">子事件经验变化</param>
        /// <param name="xinJing">子事件心境变化</param>
        /// <param name="hp">子事件血量变化</param>
        /// <param name="itemId">子事件物品变化</param>
        /// <param name="itemNum">子事件物品数量变化</param>
        /// <param name="lingGuang">子事件灵光添加</param>
        /// <param name="fuBenId">子事件副本编号</param>
        /// <param name="mapOptionId">跳转事件编号</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetMapOptionInfoInstance(
            int id,
            string eventName,
            string desc,
            int time = 0,
            int money = 0,
            int exp = 0,
            int xinJing = 0,
            int hp = 0,
            List<int> itemId = null,
            List<int> itemNum = null,
            int lingGuang = 0,
            int fuBenId = 0,
            int mapOptionId = 0
        )
        {
            var data = JSONObject.Create();
            data.SetField("id", id);
            data.SetField("EventName", eventName);
            data.SetField("desc", desc);
            data.SetField("value1", time);
            data.SetField("value2", money);
            data.SetField("value3", exp);
            data.SetField("value4", xinJing);
            data.SetField("value5", hp);
            data.SetField("value6", itemId.ToJsonObject());
            data.SetField("value7", itemNum.ToJsonObject());
            data.SetField("value8", fuBenId);
            data.SetField("value9", mapOptionId);
            data.SetField("value10", lingGuang);
            return data;
        }
    }
}