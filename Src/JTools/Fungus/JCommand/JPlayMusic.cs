using System;
using Fungus;
using UnityEngine;
using YSGame;

namespace TierneyJohn.MiChangSheng.JTools.Fungus.JCommand
{
    /// <summary>
    /// JTools 封装 PlayMusic 指令
    /// </summary>
    [Serializable]
    public class JPlayMusic : PlayMusic
    {
        #region 字段/属性声明

        private string _musicName;

        #endregion

        #region 构造方法

        /// <summary>
        /// 播放音乐指令
        /// </summary>
        /// <param name="music">AudioClip 类型音乐数据</param>
        /// <param name="actionTime">起始播放时间</param>
        /// <param name="playLoop">是否循环播放</param>
        /// <returns>JPlayMusic 对象</returns>
        public JPlayMusic Create(AudioClip music, float actionTime = 0f, bool playLoop = true)
        {
            musicClip = music;
            atTime = actionTime;
            loop = playLoop;
            return this;
        }

        /// <summary>
        /// 播放音乐指令
        /// </summary>
        /// <param name="musicName">Music 名称 (会通过 MusicMag 的 playMusic 方法进行播放)</param>
        /// <returns>JPlayMusic 对象</returns>
        public JPlayMusic Create(string musicName)
        {
            _musicName = musicName;
            return this;
        }

        #endregion

        #region 公开方法

        public override void OnEnter()
        {
            if (musicClip == null)
            {
                MusicMag.instance.playMusic(_musicName);
                Continue();
                return;
            }

            base.OnEnter();
        }

        #endregion
    }
}