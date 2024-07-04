using System;
using Fungus;
using TierneyJohn.MiChangSheng.JTools.Manager;

namespace TierneyJohn.MiChangSheng.JTools.Fungus.JCommand;

/// <summary>
/// JTools 封装 HideSpineCg 指令
/// </summary>
[Serializable]
public class JHideSpineCg : Command
{
    #region 构造方法

    /// <summary>
    /// 隐藏动态 CG 显示
    /// </summary>
    /// <returns>JHideSpineCg 对象</returns>
    public JHideSpineCg Create() { return this; }

    #endregion

    #region 公开方法

    public override void OnEnter()
    {
        CgManager.Inst.HideSpineCg();
        Continue();
    }

    #endregion
}