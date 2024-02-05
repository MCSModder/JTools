using System;
using Fungus;
using UnityEngine;

namespace TierneyJohn.MiChangSheng.JTools.Fungus.JCommand
{
    /// <summary>
    /// JTools 封装感悟获取指令
    /// </summary>
    [Serializable]
    public class JAddLingGuang : Command
    {
        #region 字段/属性/方法声明

        private int _lingGuangId;

        #endregion

        #region 构造方法

        /// <summary>
        /// 添加感悟指令
        /// </summary>
        /// <param name="lingGuangId">感悟id</param>
        /// <returns>JAddLingGuang 对象</returns>
        public JAddLingGuang Create(int lingGuangId)
        {
            _lingGuangId = lingGuangId;
            return this;
        }

        #endregion

        #region 公开方法

        public override void OnEnter()
        {
            PlayerEx.Player.wuDaoMag.AddLingGuangByJsonID(_lingGuangId);
            UIPopTip.Inst.Pop("获得新的感悟", PopTipIconType.感悟);
            Continue();
        }

        public override Color GetButtonColor() => new Color32(184, 210, 235, byte.MaxValue);

        #endregion
    }
}