using System;
using Fungus;
using Tab;

namespace TierneyJohn.MiChangSheng.JTools.Fungus.JCommand
{
    /// <summary>
    /// JTools 封装 CloseTab 指令
    /// </summary>
    [Serializable]
    public class JCloseTab : Command
    {
        #region 构造方法

        /// <summary>
        /// 关闭 Tab 界面指令
        /// </summary>
        /// <returns>JCloseTab 对象</returns>
        public JCloseTab Create()
        {
            return this;
        }

        #endregion

        #region 公开方法

        public override void OnEnter()
        {
            if (SingletonMono<TabUIMag>.Instance != null)
            {
                SingletonMono<TabUIMag>.Instance.TryEscClose();
            }

            Continue();
        }

        #endregion
    }
}