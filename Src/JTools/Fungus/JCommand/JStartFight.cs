using System;
using System.Collections.Generic;
using Fungus;

namespace TierneyJohn.MiChangSheng.JTools.Fungus.JCommand;

/// <summary>
/// JTools 封装 StartFight 指令
/// </summary>
[Serializable]
public class JStartFight : StartFight
{
    #region 构造方法

    /// <summary>
    /// 开始战斗指令
    /// </summary>
    /// <param name="monsterId">战斗对象编号</param>
    /// <param name="fightType">战斗类型</param>
    /// <param name="canRun">是否可以逃跑</param>
    /// <param name="backgroundId">背景图编号</param>
    /// <param name="music">播放音乐名称</param>
    /// <param name="isSea">是否为海上NPC(战斗后会移除)</param>
    /// <param name="playerBuffs">战斗时主角额外buff</param>
    /// <param name="monsterBuffs">战斗时对象额外buff</param>
    /// <returns>JStartFight 对象</returns>
    public JStartFight Create(
        int monsterId,
        FightEnumType fightType,
        bool canRun = true,
        int backgroundId = 0,
        string music = "战斗1",
        bool isSea = false,
        List<StarttFightAddBuff> playerBuffs = null,
        List<StarttFightAddBuff> monsterBuffs = null)
    {
        MonstarID = monsterId;
        CanFpRun = canRun ? 1 : 0;
        MonstarSetType = MonstarType.Normal;
        FightType = fightType;
        BackgroundID = backgroundId;
        FightMusic = music;
        SeaRemoveNPCFlag = isSea;
        HeroAddBuffList = playerBuffs ?? [];
        MonstarAddBuffList = monsterBuffs ?? [];
        return this;
    }

    #endregion
}