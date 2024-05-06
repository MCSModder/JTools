using System;

namespace TierneyJohn.MiChangSheng.JTools.Fungus.JCommand;

/// <summary>
/// JTools 封装 CmdAddFavor 指令
/// </summary>
[Serializable]
public class JAddNpcFavor : CmdAddFavor
{
    #region 字段/属性 声明

    private int _npcId;
    private int _number;
    private bool _showTip;

    #endregion

    #region 构造方法

    /// <summary>
    /// 添加 NPC 好感度指令
    /// </summary>
    /// <param name="npcId">目标 NPC 编号</param>
    /// <param name="number">好感度数值</param>
    /// <param name="showTip">是否显示提示</param>
    /// <returns>JAddNpcFavor 对象</returns>
    public JAddNpcFavor Create(int npcId, int number, bool showTip = true)
    {
        _npcId = npcId;
        _number = number;
        _showTip = showTip;
        return this;
    }

    #endregion

    #region 公开方法

    public override void OnEnter()
    {
        NPCEx.AddFavor(_npcId, _number, true, _showTip);
        Continue();
    }

    #endregion
}