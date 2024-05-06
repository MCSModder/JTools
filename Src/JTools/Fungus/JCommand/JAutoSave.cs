using System;
using Fungus;

namespace TierneyJohn.MiChangSheng.JTools.Fungus.JCommand;

/// <summary>
/// JTools 封装自动存档指令
/// </summary>
[Serializable]
public class JAutoSave : YSSaveGame
{
    #region 构造方法

    /// <summary>
    /// 游戏自动存档指令
    /// </summary>
    /// <returns>JAutoSave 对象</returns>
    public JAutoSave Create()
    {
        return this;
    }

    #endregion
}