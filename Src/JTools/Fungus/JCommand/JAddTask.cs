using System;
using Fungus;

namespace TierneyJohn.MiChangSheng.JTools.Fungus.JCommand
{
    /// <summary>
    /// JTools 封装 AddTask 指令
    /// </summary>
    [Serializable]
    public class JAddTask : AddTask
    {
        #region 构造方法

        /// <summary>
        /// 添加任务指令
        /// </summary>
        /// <returns>JAddTask 对象</returns>
        public JAddTask Create(int taskId, bool popTip = true)
        {
            TaskID = taskId;
            showInfo = popTip;
            return this;
        }

        #endregion
    }
}