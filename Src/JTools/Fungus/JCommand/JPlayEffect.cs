using System;
using Fungus;
using UnityEngine;
using YSGame;

namespace TierneyJohn.MiChangSheng.JTools.Fungus.JCommand
{
    /// <summary>
    /// JTools 封装 PlaySound 指令
    /// </summary>
    [Serializable]
    public class JPlayEffect : PlaySound
    {
        #region 字段/属性声明

        private string _effectName;
        private float _pitch;

        #endregion

        #region 构造方法

        /// <summary>
        /// 播放音效指令
        /// </summary>
        /// <param name="effect">AudioClip 类型音效数据</param>
        /// <returns>JPlayEffect 对象</returns>
        public JPlayEffect Create(AudioClip effect)
        {
            soundClip = effect;
            return this;
        }

        /// <summary>
        /// 播放音效指令
        /// </summary>
        /// <param name="effectName">音效名称 (会通过 MusicMag 的 PlayEffectMusic 方法进行播放)</param>
        /// <param name="pitch">播放时长 (默认 1s)</param>
        /// <returns>JPlayEffect 对象</returns>
        public JPlayEffect Create(string effectName, float pitch = 1f)
        {
            _effectName = effectName;
            _pitch = pitch;
            return this;
        }

        #endregion

        #region 公开方法

        public override void OnEnter()
        {
            if (soundClip == null)
            {
                MusicMag.instance.PlayEffectMusic(_effectName, _pitch);
                Continue();
                return;
            }

            base.OnEnter();
        }

        #endregion
    }
}