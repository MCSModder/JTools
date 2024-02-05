using Fungus;
using JSONClass;
using KBEngine;

namespace TierneyJohn.MiChangSheng.JTools.Util
{
    /// <summary>
    /// Task 任务工具类
    /// </summary>
    public static class TaskUtil
    {
        private static TaskMag TaskMag => Tools.instance.getPlayer().taskMag;

        /// <summary>
        /// 获取任务数据
        /// </summary>
        /// <param name="taskId">Task 编号</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetTaskData(this int taskId) => GetTaskData(taskId.ToString());

        /// <summary>
        /// 获取任务数据
        /// </summary>
        /// <param name="taskId">Task 编号</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetTaskData(this string taskId) => TaskMag._TaskData["Task"][taskId];

        /// <summary>
        /// 是否存在指定任务
        /// </summary>
        /// <param name="taskId">Task 编号</param>
        /// <returns>验证结果</returns>
        public static bool HasTask(this int taskId) => TaskMag.isHasTask(taskId);

        /// <summary>
        /// 查询当前任务阶段编号
        /// </summary>
        /// <param name="taskId">Task 编号</param>
        /// <returns>当前阶段编号</returns>
        public static int GetTaskIndex(this int taskId) => TaskMag.GetTaskNowIndex(taskId);

        /// <summary>
        /// 查询当前任务最终阶段编号
        /// </summary>
        /// <param name="taskId">Task 编号</param>
        /// <returns>最终阶段编号</returns>
        public static int GetFinalIndex(this int taskId) => TaskMag.getFinallyIndex(taskId);

        /// <summary>
        /// 添加新的任务
        /// </summary>
        /// <param name="taskId">Task 编号</param>
        /// <returns>添加结果</returns>
        public static bool AddTask(this int taskId)
        {
            TaskMag.addTask(taskId);
            return HasTask(taskId);
        }

        /// <summary>
        /// 添加新的任务 (若已存在改任务编号，则添加失败)
        /// </summary>
        /// <param name="taskId">Task 编号</param>
        /// <returns>添加结果</returns>
        public static bool TryAddTask(this int taskId)
        {
            if (!TaskJsonData.DataDict.ContainsKey(taskId))
            {
                $"自定义任务添加失败，未查询到该任务数据: {taskId}".Warn();
                return false;
            }

            if (HasTask(taskId))
            {
                $"自定义任务添加失败，已拥有该任务: {taskId}".Warn();
                return false;
            }

            return AddTask(taskId);
        }

        /// <summary>
        /// 将任务进行到下一阶段
        /// </summary>
        /// <param name="taskId">Task 编号</param>
        /// <returns>执行结果</returns>
        public static bool NextTask(this int taskId)
        {
            if (!HasTask(taskId))
            {
                $"任务阶段跳转失败，未拥有该任务: {taskId}".Warn();
                return false;
            }

            var taskIndex = taskId.GetTaskIndex();
            var taskFinalIndex = taskId.GetFinalIndex();

            if (taskIndex == taskFinalIndex)
            {
                // 当前任务未最终阶段
                SetTaskCompleted(taskId);
                $"当前任务阶段为最终阶段，任务已完成: {taskId}".Log();
            }
            else
            {
                // 当前任务并非最终阶段
                SetTaskIndex(taskId, taskIndex + 1);
                $"当前任务阶段已成功跳转: {taskId}".Log();
            }

            return true;
        }

        /// <summary>
        /// 将指定任务设置成对应阶段
        /// </summary>
        /// <param name="taskId">Task 编号</param>
        /// <param name="taskIndex">Task 阶段编号</param>
        public static void SetTaskIndex(this int taskId, int taskIndex)
        {
            var taskData = GetTaskData(taskId);

            if (!taskData.GetFieldList("AllIndex").Contains(taskIndex))
            {
                taskData["AllIndex"].Add(taskIndex);
            }

            taskData.SetField("NowIndex", taskIndex);
            taskData.SetField("isComplete", false);
            taskData.SetField("disableTask", false);
        }

        /// <summary>
        /// 将指定任务设置成完成阶段
        /// </summary>
        /// <param name="taskId">Task 编号</param>
        public static void SetTaskCompleted(this int taskId)
        {
            SetTaskIndexFinish.Do(taskId, GetFinalIndex(taskId));
            SetTaskCompelet.Do(taskId);
        }
    }
}