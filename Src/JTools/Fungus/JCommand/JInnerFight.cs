using System;
using Fungus;
using FungusManager = TierneyJohn.MiChangSheng.JTools.Manager.FungusManager;

namespace TierneyJohn.MiChangSheng.JTools.Fungus.JCommand;

/// <summary>
/// JTools 封装战斗内剧情调用指令
/// </summary>
[Serializable]
public class JInnerFight : Command
{
    #region 字段/属性

    protected string TargetFlowchart;
    protected string TargetBlock;

    #endregion

    #region 构造方法

    /// <summary>
    /// 战斗内剧情调用指令
    /// </summary>
    /// <param name="callBlockName">待执行 Block 名称</param>
    /// <param name="callFlowchartName">待执行 Flowchart 名称</param>
    /// <returns>JInnerFight 对象</returns>
    public JInnerFight Create(string callBlockName, string callFlowchartName = "")
    {
        TargetBlock = callBlockName;
        TargetFlowchart = string.IsNullOrEmpty(callFlowchartName) ? GetFlowchart().name : callFlowchartName;
        return this;
    }

    /// <summary>
    /// 战斗内剧情调用指令
    /// </summary>
    /// <param name="callBlock">待执行 Block 数据</param>
    /// <param name="callFlowchart">待执行 Flowchart 数据</param>
    /// <returns>JInnerFight 对象</returns>
    public JInnerFight Create(Block callBlock, Flowchart callFlowchart = null)
    {
        TargetBlock = callBlock.blockName;
        TargetFlowchart = callFlowchart ? callFlowchart.name : GetFlowchart().name;
        return this;
    }

    #endregion

    #region 公开方法

    public override void OnEnter()
    {
        FungusManager.Inst.RegisterInnerFightData(TargetFlowchart, TargetBlock);
        Continue();
    }

    #endregion
}