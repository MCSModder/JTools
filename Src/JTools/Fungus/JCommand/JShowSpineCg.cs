using System;
using Fungus;
using TierneyJohn.MiChangSheng.JTools.Manager;

namespace TierneyJohn.MiChangSheng.JTools.Fungus.JCommand;

/// <summary>
/// JTools 封装 ShowSpineCg 指令
/// </summary>
[Serializable]
public class JShowSpineCg : Command
{
    #region 字段/属性/方法说明

    private string _spineName;

    private string _spineSkin;

    #endregion

    #region 构造方法

    /// <summary>
    /// 显示动态 CG 指令
    /// </summary>
    /// <param name="spineName">Spine 场景名称</param>
    /// <param name="spineSkin">Skin 名称</param>
    /// <returns>JShowSpineCg 对象</returns>
    public JShowSpineCg Create(string spineName, string spineSkin)
    {
        _spineName = spineName;
        _spineSkin = spineSkin;
        return this;
    }

    #endregion

    #region 公开方法

    public override void OnEnter()
    {
        CgManager.Inst.ShowSpineCg(_spineName, _spineSkin);
        Continue();
    }

    #endregion
}