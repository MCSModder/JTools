using System;
using Fungus;
using YSGame;

namespace TierneyJohn.MiChangSheng.JTools.Fungus.JCommand;

/// <summary>
/// JTools 封装 StopMusic 指令
/// </summary>
[Serializable]
public class JStopMusic : StopMusic
{
    /// <summary>
    /// 停止播放音乐指令
    /// </summary>
    /// <returns>JStopMusic 对象</returns>
    public JStopMusic Create()
    {
        return this;
    }

    public override void OnEnter()
    {
        MusicMag.instance.stopMusic();
        base.OnEnter();
    }
}