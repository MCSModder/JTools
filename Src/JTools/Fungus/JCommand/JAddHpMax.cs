using System;
using Fungus;

namespace TierneyJohn.MiChangSheng.JTools.Fungus.JCommand;

/// <summary>
/// JTools 封装 AddHPMax 指令
/// </summary>
[Serializable]
public class JAddHpMax : AddHPMax
{
    #region 构造方法

    /// <summary>
    /// 添加血量上限指令
    /// </summary>
    /// <param name="hpMax">血量上限变化量</param>
    /// <returns>JAddHpMax 对象</returns>
    public JAddHpMax Create(int hpMax)
    {
        AddHPMaxNum = hpMax;
        return this;
    }

    #endregion
}