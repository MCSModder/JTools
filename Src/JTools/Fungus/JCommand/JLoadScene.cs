using System;
using Fungus;
using TierneyJohn.MiChangSheng.JTools.Tool;

namespace TierneyJohn.MiChangSheng.JTools.Fungus.JCommand;

/// <summary>
/// JTools 封装场景加载指令
/// </summary>
[Serializable]
public class JLoadScene : Command
{
    #region 字段/属性 声明

    /// <summary>
    /// 待加载场景名称
    /// </summary>
    private string _sceneName;

    #endregion

    #region 构造方法

    /// <summary>
    /// 场景加载指令
    /// </summary>
    /// <param name="sceneName">场景名称</param>
    /// <returns>JLoadScene 对象</returns>
    public JLoadScene Create(string sceneName)
    {
        _sceneName = sceneName;
        return this;
    }

    #endregion

    #region 公开方法

    public override void OnEnter()
    {
        _sceneName.LoadScene();
        Continue();
    }

    #endregion
}