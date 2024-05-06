using Fungus;
using TierneyJohn.MiChangSheng.JTools.Tool;

namespace TierneyJohn.MiChangSheng.JTools.Fungus.JCommand;

/// <summary>
/// JTools 封装游戏场景加载指令
/// </summary>
public class JLoadGame : Command
{
    #region 字段/属性 声明

    /// <summary>
    /// 待加载场景名称
    /// </summary>
    private string _sceneName;

    #endregion

    #region 构造方法

    /// <summary>
    /// 游戏场景加载指令
    /// </summary>
    /// <param name="sceneName">游戏场景名称</param>
    /// <returns>JLoadGameScene 对象</returns>
    public JLoadGame Create(string sceneName)
    {
        _sceneName = sceneName;
        return this;
    }

    #endregion

    #region 公开方法

    public override void OnEnter()
    {
        _sceneName.LoadGame();
        Continue();
    }

    #endregion
}