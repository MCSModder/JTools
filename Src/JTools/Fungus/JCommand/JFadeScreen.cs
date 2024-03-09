using Fungus;
using UnityEngine;

namespace TierneyJohn.MiChangSheng.JTools.Fungus.JCommand;

/// <summary>
/// JTools 封装淡入淡出指令
/// </summary>
public class JFadeScreen : FadeScreen
{
    #region 构造方法

    /// <summary>
    /// 淡入淡出指令
    /// </summary>
    /// <param name="hide">淡入或淡出操作</param>
    /// <param name="texture">加载图片</param>
    /// <param name="isWait">是否等待动画执行完</param>
    /// <returns>JFadeScreen 对象</returns>
    public JFadeScreen Create(bool hide, Texture2D texture = null, bool isWait = true)
    {
        targetAlpha = hide ? 1 : 0;
        if (texture != null) fadeTexture = texture;
        waitUntilFinished = isWait;
        return this;
    }

    #endregion
}