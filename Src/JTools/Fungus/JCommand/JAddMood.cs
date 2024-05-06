using System;
using Fungus;

namespace TierneyJohn.MiChangSheng.JTools.Fungus.JCommand;

/// <summary>
/// JTools 封装 AddXinJin 指令
/// </summary>
[Serializable]
public class JAddMood : AddXinJin
{
    #region 构造方法

    /// <summary>
    /// 添加心境指令
    /// </summary>
    /// <param name="mood">心境值变化量</param>
    /// <returns>JAddMood 对象</returns>
    public JAddMood Create(int mood)
    {
        AddXinjinNum = mood;
        return this;
    }

    #endregion
}