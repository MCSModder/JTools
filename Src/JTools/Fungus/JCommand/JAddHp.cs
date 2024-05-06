using System;
using Fungus;

namespace TierneyJohn.MiChangSheng.JTools.Fungus.JCommand;

/// <summary>
/// JTools 封装 AddHP 指令
/// </summary>
[Serializable]
public class JAddHp : AddHP
{
    #region 字段/属性 声明

    private bool _isExtend;

    private double _percentage;

    #endregion

    #region 构造方法

    /// <summary>
    /// 增加角色血量指令
    /// </summary>
    /// <param name="hp">血量增加量</param>
    /// <returns>JAddHp 对象</returns>
    public JAddHp Create(int hp)
    {
        AddHpNum = hp;
        return this;
    }

    /// <summary>
    /// 增加角色血量指令
    /// </summary>
    /// <param name="percentage">血量增加倍率</param>
    /// <returns>JAddHp 对象</returns>
    public JAddHp Create(double percentage)
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
            var hp = PlayerEx.Player.HP_Max * _percentage;
            AddHpNum = (int)hp;
        }

        base.OnEnter();
    }

    #endregion
}