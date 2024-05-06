using System;
using System.Collections;
using Fungus;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TierneyJohn.MiChangSheng.JTools.Fungus.JCommand;

/// <summary>
/// JTools 封装 Or 指令
/// </summary>
[Serializable]
public class JOr : Command
{
    #region 字段/属性/方法声明

    private Func<bool> _evaluate;
    private Block _targetBlock1;
    private Block _targetBlock2;

    #endregion

    #region 构造方法

    /// <summary>
    /// 根据条件跳转目标 Block 指令
    /// 若满足条件则跳转到指定 Block 中，若不满足条件则继续执行后续内容
    /// </summary>
    /// <param name="targetBlock1">目标 Block1</param>
    /// <param name="targetBlock2">目标 Block2</param>
    /// <param name="evaluate">判定条件函数 (需要返回一个 bool 值)</param>
    /// <returns>JOr 对象</returns>
    public JOr Create(JBlock targetBlock1, JBlock targetBlock2, Func<bool> evaluate)
    {
        _evaluate = evaluate;
        _targetBlock1 = targetBlock1;
        _targetBlock2 = targetBlock2;
        return this;
    }

    #endregion

    #region 公开方法

    public override void OnEnter()
    {
        if (ParentBlock == null) return;

        if (CommandIndex >= ParentBlock.commandList.Count - 1)
        {
            StopParentBlock();
        }

        var targetBlock = _evaluate.Invoke() ? _targetBlock1 : _targetBlock2;
        EventSystem.current.SetSelectedGameObject(null);
        StopAllCoroutines();
        var sayDialog = SayDialog.GetSayDialog();
        if (sayDialog != null) sayDialog.FadeWhenDone = true;
        if (targetBlock == null) return;

        var flowchart = targetBlock.GetFlowchart();
        flowchart.StartCoroutine(CallBlock(targetBlock));
    }

    public override bool OpenBlock() => true;

    #endregion

    #region 私有方法

    private IEnumerator CallBlock(Block block)
    {
        yield return new WaitForEndOfFrame();
        StopParentBlock();
        block.StartExecution();
    }

    #endregion
}