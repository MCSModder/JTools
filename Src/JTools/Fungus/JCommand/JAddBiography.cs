using System;
using System.Collections.Generic;
using Fungus;

namespace TierneyJohn.MiChangSheng.JTools.Fungus.JCommand;

/// <summary>
/// JTools 封装生平记录指令
/// </summary>
[Serializable]
public class JAddBiography : Command
{
    #region 字段/属性 声明

    private string _id;

    private Dictionary<string, string> _args;

    #endregion

    #region 构造方法

    /// <summary>
    /// 添加生平记录指令
    /// </summary>
    /// <param name="id">生平记录名称</param>
    /// <param name="args">生平记录文本替换列表</param>
    /// <returns>JAddBiography 对象</returns>
    public JAddBiography Create(string id, Dictionary<string, string> args = null)
    {
        _id = id;
        _args = args;
        return this;
    }

    #endregion

    #region 公开方法

    public override void OnEnter()
    {
        PlayerEx.RecordShengPing(_id, _args);
        Continue();
    }

    #endregion
}