using System;
using Fungus;

namespace TierneyJohn.MiChangSheng.JTools.Fungus.JCommand;

/// <summary>
/// JTools 封装恢复血量指令
/// </summary>
[Serializable]
public class JRestoreHp : Command
{
    #region 构造方法

    /// <summary>
    /// 恢复血量指令
    /// </summary>
    /// <returns>JRestoreHp 对象</returns>
    public JRestoreHp Create()
    {
        return this;
    }

    #endregion

    #region 公开方法

    public override void OnEnter()
    {
        PlayerEx.Player.AllMapAddHP(PlayerEx.Player.HP_Max);
        Continue();
    }

    #endregion
}