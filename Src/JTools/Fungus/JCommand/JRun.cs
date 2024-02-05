using System;
using Fungus;

namespace TierneyJohn.MiChangSheng.JTools.Fungus.JCommand
{
    /// <summary>
    /// JTools 封装 Run 指令
    /// </summary>
    [Serializable]
    public class JRun : Command
    {
        #region 字段/属性/方法声明

        protected Action Action;

        #endregion

        #region 构造方法

        /// <summary>
        /// 执行指定代码指令
        /// </summary>
        /// <param name="action">执行代码</param>
        /// <returns>JRun 对象</returns>
        public JRun Create(Action action)
        {
            Action = action;
            return this;
        }

        #endregion

        #region 公开方法

        public override void OnEnter()
        {
            if (ParentBlock == null)
            {
                return;
            }

            if (CommandIndex >= ParentBlock.commandList.Count - 1)
            {
                StopParentBlock();
            }

            Action.Invoke();
            Continue();
        }

        #endregion
    }
}