using System;
using Fungus;

namespace TierneyJohn.MiChangSheng.JTools.Fungus.JCommand
{
    /// <summary>
    /// JTools 封装 SetTips 指令
    /// </summary>
    [Serializable]
    public class JPopTip : SetTips
    {
        #region 字段/属性/方法声明

        private string _message;
        private string _sound;
        private PopTipIconType _type;

        #endregion

        #region 构造方法

        /// <summary>
        /// 消息提示指令
        /// </summary>
        /// <param name="message">消息内容</param>
        /// <param name="sound">播放声音名称</param>
        /// <param name="type">消息类型</param>
        /// <returns>JPopTip 对象</returns>
        public JPopTip Create(string message, PopTipIconType type = PopTipIconType.叹号, string sound = "")
        {
            _message = message;
            _sound = sound;
            _type = type;
            return this;
        }

        #endregion

        #region 公开方法

        public override void OnEnter()
        {
            if ("".Equals(_sound))
            {
                UIPopTip.Inst.Pop(_message, _type);
            }
            else
            {
                UIPopTip.Inst.Pop(_message, _sound, _type);
            }

            Continue();
        }

        #endregion
    }
}