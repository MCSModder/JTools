using System;
using Fungus;
using JSONClass;

namespace TierneyJohn.MiChangSheng.JTools.Fungus.JCommand;

/// <summary>
/// JTools 封装 AddEXP 指令
/// </summary>
[Serializable]
public class JAddExp : AddEXP
{
    #region 字段/属性 声明

    private bool _isExtend;

    private double _percentage;

    #endregion

    #region 构造方法

    /// <summary>
    /// 增加角色经验值指令
    /// </summary>
    /// <param name="exp">经验值增加量</param>
    /// <returns>JAddExp 对象</returns>
    public JAddExp Create(int exp)
    {
        AddEXPNum = exp;
        return this;
    }

    /// <summary>
    /// 增加角色经验值指令
    /// </summary>
    /// <param name="percentage">经验值增加倍率</param>
    /// <returns>JAddExp 对象</returns>
    public JAddExp Create(double percentage)
    {
        _percentage = percentage;
        _isExtend = true;
        return this;
    }

    #endregion

    #region 公开方法

    public override void OnEnter()
    {
        if (_isExtend)
        {
            var maxExp = LevelUpDataJsonData.DataDict[PlayerEx.Player.level].MaxExp;
            AddEXPNum = (int)(maxExp * _percentage);
        }

        base.OnEnter();
    }

    #endregion
}