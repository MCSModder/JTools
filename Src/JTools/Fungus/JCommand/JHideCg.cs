using System;
using Fungus;
using TierneyJohn.MiChangSheng.JTools.Manager;

namespace TierneyJohn.MiChangSheng.JTools.Fungus.JCommand
{
    /// <summary>
    /// JTools 封装 HideCg 指令
    /// </summary>
    [Serializable]
    public class JHideCg : Command
    {
        #region 构造方法

        /// <summary>
        /// 隐藏静态 CG 显示
        /// </summary>
        /// <returns>JHideCg 对象</returns>
        public JHideCg Create() { return this; }

        #endregion

        #region 公开方法

        public override void OnEnter()
        {
            CgManager.Inst.HideCg();
            Continue();
        }

        #endregion
    }
}