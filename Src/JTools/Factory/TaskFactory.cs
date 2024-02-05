using System.Collections.Generic;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools.Factory
{
    /// <summary>
    /// 任务数据工厂类
    /// </summary>
    public class TaskFactory
    {
        /// <summary>
        /// 获取指定参数的 TaskJson 数据
        /// </summary>
        /// <param name="taskId">传闻编号</param>
        /// <param name="taskName">传闻名称</param>
        /// <param name="type">传闻类别 (0:传闻,1:任务)</param>
        /// <param name="variable">过时变量</param>
        /// <param name="title">传闻来源</param>
        /// <param name="desc">传闻描述</param>
        /// <param name="startTime">开始时间(yyyy-MM-dd)</param>
        /// <param name="endTime">结束时间(yyyy-MM-dd)</param>
        /// <param name="circulation">循环(年)</param>
        /// <param name="mapIndex">地图标记点(1-100为宁州，100以上为海域， 作为海域时，配的数字为海上高亮 ID+100)</param>
        /// <param name="continueTime">任务持续时间(月)</param>
        /// <param name="isFinish">是否完成(0:未完成,1:已完成)</param>
        /// <param name="eventValue">完成变量(若获得任务时满足此变量判定，则任务直接置为结束)</param>
        /// <param name="fuHao">变量关系(大于 小于 等于)</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetInstance(
            int taskId,
            string taskName,
            int type,
            int variable,
            string title,
            string desc,
            string startTime,
            string endTime,
            int circulation,
            int mapIndex,
            int continueTime,
            int isFinish,
            List<int> eventValue,
            string fuHao
        )
        {
            var data = JSONObject.Create();
            data.SetField("id", taskId);
            data.SetField("Name", taskName);
            data.SetField("Type", type);
            data.SetField("variable", variable);
            data.SetField("Title", title);
            data.SetField("Desc", desc);
            data.SetField("StarTime", startTime);
            data.SetField("EndTime", endTime);
            data.SetField("circulation", circulation);
            data.SetField("mapIndex", mapIndex);
            data.SetField("continueTime", continueTime);
            data.SetField("isFinsh", isFinish);
            data.SetField("EventValue", eventValue.ToJsonObject());
            data.SetField("fuhao", fuHao);
            return data;
        }

        /// <summary>
        /// 获取指定参数的 TaskJson 数据
        /// </summary>
        /// <param name="taskId">任务编号</param>
        /// <param name="taskName">任务名称</param>
        /// <param name="title">任务来源</param>
        /// <param name="desc">任务描述</param>
        /// <param name="mapIndex">地图标记点(1-100为宁州，100以上为海域， 作为海域时，配的数字为海上高亮 ID+100)</param>
        /// <param name="startTime">开始时间(yyyy-MM-dd)</param>
        /// <param name="endTime">结束时间(yyyy-MM-dd)</param>
        /// <param name="continueTime">任务持续时间(月)</param>
        /// <param name="circulation">循环(年)</param>
        /// <returns></returns>
        public static JSONObject GetTaskInstance(
            int taskId,
            string taskName,
            string title,
            string desc,
            int mapIndex = 0,
            string startTime = "",
            string endTime = "5000-12-30",
            int continueTime = 0,
            int circulation = 0
        )
        {
            // 默认传闻类型为 任务
            const int type = 1;
            // 默认过时变量 999
            const int variable = 999;
            // 默认任务状态 未完成
            const int isFinish = 0;
            // 默认变量为空
            var eventValue = new List<int>();
            // 默认变量关系为空
            const string fuHao = "";
            return GetInstance(taskId, taskName, type, variable, title, desc, startTime, endTime, circulation, mapIndex,
                continueTime, isFinish, eventValue, fuHao);
        }

        /// <summary>
        /// 获取指定参数的 TaskInfoJson 数据
        /// </summary>
        /// <param name="id">子任务编号</param>
        /// <param name="taskId">任务编号</param>
        /// <param name="taskIndex">任务进度</param>
        /// <param name="desc">子任务描述</param>
        /// <param name="mapIndex">地图标记点</param>
        /// <param name="isFinal">是否为最终完成项 (0:不是,1:是)</param>
        /// <returns></returns>
        public static JSONObject GetTaskInfoInstance(
            int id,
            int taskId,
            int taskIndex,
            string desc,
            int isFinal = 0,
            int mapIndex = 0
        )
        {
            var data = JSONObject.Create();
            data.SetField("id", id);
            data.SetField("TaskID", taskId);
            data.SetField("TaskIndex", taskIndex);
            data.SetField("Desc", desc);
            data.SetField("mapIndex", mapIndex);
            data.SetField("IsFinal", isFinal);
            return data;
        }
    }
}