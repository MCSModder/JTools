using System;
using Fungus;
using JiaoYi;
using UnityEngine.Events;

namespace TierneyJohn.MiChangSheng.JTools.Fungus.JCommand;

/// <summary>
/// JTools 封装 OpenJiaoYi 指令
/// </summary>
[Serializable]
public class JOpenShop : OpenJiaoYi
{
    #region 字段/属性 声明

    private int _avatarId;

    private UnityAction _action;

    #endregion

    #region 构造方法

    /// <summary>
    /// 打开角色商店指令
    /// </summary>
    /// <param name="avatarId">角色编号</param>
    /// <param name="action">关闭商店事件</param>
    /// <returns>JOpenShop 对象</returns>
    public JOpenShop Create(int avatarId, UnityAction action = null)
    {
        _avatarId = avatarId;
        _action = action;
        return this;
    }

    #endregion

    #region 公开方法

    public override void OnEnter()
    {
        if (_action == null)
        {
            _action = Continue;
        }
        else
        {
            _action += Continue;
        }

        ResManager.inst.LoadPrefab("JiaoYiUI").Inst(NewUICanvas.Inst.transform);
        JiaoYiUIMag.Inst.Init(_avatarId, _action);
    }

    #endregion
}