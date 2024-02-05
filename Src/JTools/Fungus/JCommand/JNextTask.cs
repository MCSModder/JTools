using System;
using Fungus;
using JSONClass;

namespace TierneyJohn.MiChangSheng.JTools.Fungus.JCommand
{
    /// <summary>
    /// JTools 封装 NextTask 指令
    /// </summary>
    [Serializable]
    public class JNextTask : Command
    {
        #region 字段/属性/方法声明

        private int _taskId;
        private bool _popTip;

        #endregion

        #region 构造方法

        /// <summary>
        /// 将指定任务调整至下一节点
        /// </summary>
        /// <returns>JNextTask 对象</returns>
        public JNextTask Create(int taskId, bool popTip = true)
        {
            _taskId = taskId;
            _popTip = popTip;
            return this;
        }

        #endregion

        #region 公开方法

        public override void OnEnter()
        {
            var taskMag = PlayerEx.Player.taskMag;
            var taskName = TaskJsonData.DataDict[_taskId].Name;
            var taskIndex = taskMag.GetTaskNowIndex(_taskId);
            var taskFinalIndex = taskMag.getFinallyIndex(_taskId);

            if (taskIndex == taskFinalIndex)
            {
                SetTaskIndexFinish.Do(_taskId, taskFinalIndex);
                SetTaskCompelet.Do(_taskId);
                if (_popTip)
                {
                    UIPopTip.Inst.Pop($"<color=#FF0000> {taskName} </color> 已达成", "Task_complete", PopTipIconType.任务完成);
                }
            }
            else
            {
                taskMag.setTaskIndex(_taskId, taskIndex + 1);
                if (_popTip)
                {
                    UIPopTip.Inst.Pop($"<color=#FF0000> {taskName} </color> 进度已更新", PopTipIconType.任务进度);
                }
            }

            Continue();
        }

        #endregion
    }
}