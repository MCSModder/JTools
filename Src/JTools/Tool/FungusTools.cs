using System;
using System.Collections.Generic;
using Fungus;
using TierneyJohn.MiChangSheng.JTools.Fungus;
using TierneyJohn.MiChangSheng.JTools.Fungus.JCommand;
using UnityEngine;
using UnityEngine.Events;

namespace TierneyJohn.MiChangSheng.JTools.Tool;

/// <summary>
/// Fungus 数据处理工具
/// </summary>
public static class FungusTools
{
    /// <summary>
    /// 添加生平记录指令
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="id">生平记录名称</param>
    /// <param name="args">生平记录文本替换列表</param>
    public static JBlock AddBiography(this JBlock block, string id, Dictionary<string, string> args = null)
    {
        block.CreateCommand<JAddBiography>().Create(id, args);
        return block;
    }

    /// <summary>
    /// 增加角色经验值指令
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="exp">经验值增加量</param>
    public static JBlock AddExp(this JBlock block, int exp)
    {
        block.CreateCommand<JAddExp>().Create(exp);
        return block;
    }

    /// <summary>
    /// 增加角色经验值指令
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="percentage">经验值增加倍率</param>
    public static JBlock AddExp(this JBlock block, double percentage)
    {
        block.CreateCommand<JAddExp>().Create(percentage);
        return block;
    }

    /// <summary>
    /// 增加角色血量指令
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="hp">血量增加量</param>
    public static JBlock AddHp(this JBlock block, int hp)
    {
        block.CreateCommand<JAddHp>().Create(hp);
        return block;
    }

    /// <summary>
    /// 增加角色血量指令
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="percentage">血量增加倍率</param>
    public static JBlock AddHp(this JBlock block, double percentage)
    {
        block.CreateCommand<JAddHp>().Create(percentage);
        return block;
    }

    /// <summary>
    /// 添加血量上限指令
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="hpMax">血量上限变化量</param>
    public static JBlock AddHpMax(this JBlock block, int hpMax)
    {
        block.CreateCommand<JAddHpMax>().Create(hpMax);
        return block;
    }

    /// <summary>
    /// 添加或移除指定物品指令
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="addItemId">物品编号</param>
    /// <param name="addItemNum">物品数量 (若为正数则为添加物品,负数则为移除物品)</param>
    /// <param name="addItemText">添加物品信息提示</param>
    public static JBlock AddItem(this JBlock block, int addItemId, int addItemNum, bool addItemText = true)
    {
        block.CreateCommand<JAddItem>().Create(addItemId, addItemNum, addItemText);
        return block;
    }

    /// <summary>
    /// 添加或移除指定物品指令
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="npcId">Npc 编号</param>
    /// <param name="addItemId">物品编号</param>
    /// <param name="addItemNum">物品数量 (若为正数则为添加物品,负数则为移除物品)</param>
    public static JBlock AddItemToNpc(this JBlock block, int npcId, int addItemId, int addItemNum = 1)
    {
        block.CreateCommand<JAddItemToNpc>().Create(npcId, addItemId, addItemNum);
        return block;
    }

    /// <summary>
    /// 添加感悟
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="lingGuangId">感悟id</param>
    public static JBlock AddLingGuang(this JBlock block, int lingGuangId)
    {
        block.CreateCommand<JAddLingGuang>().Create(lingGuangId);
        return block;
    }

    /// <summary>
    /// 添加灵石
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="money">灵石数量</param>
    /// <param name="message">自定义提示文本</param>
    public static JBlock AddMoney(this JBlock block, int money, string message = "")
    {
        block.CreateCommand<JAddMoney>().Create(money, message);
        return block;
    }

    /// <summary>
    /// 添加心境指令
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="mood">心境值变化量</param>
    public static JBlock AddMood(this JBlock block, int mood)
    {
        block.CreateCommand<JAddMood>().Create(mood);
        return block;
    }

    /// <summary>
    /// 添加 NPC 好感度指令
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="npcId">目标 NPC 编号</param>
    /// <param name="number">好感度数值</param>
    /// <param name="showTip">是否显示提示</param>
    public static JBlock AddNpcFavor(this JBlock block, int npcId, int number, bool showTip = true)
    {
        block.CreateCommand<JAddNpcFavor>().Create(npcId, number, showTip);
        return block;
    }

    /// <summary>
    /// 添加新任务
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="taskId">任务编号</param>
    /// <param name="popTip">是否显示提示</param>
    public static JBlock AddTask(this JBlock block, int taskId, bool popTip = true)
    {
        block.CreateCommand<JAddTask>().Create(taskId, popTip);
        return block;
    }

    /// <summary>
    /// 时间流逝
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="year">增加年份</param>
    /// <param name="month">增加月份</param>
    /// <param name="day">增加天数</param>
    /// <param name="billingFlag">是否不结算 Npc 数据</param>
    public static JBlock AddTime(this JBlock block, int year, int month, int day, bool billingFlag = false)
    {
        block.CreateCommand<JAddTime>().Create(year, month, day, billingFlag);
        return block;
    }

    /// <summary>
    /// 战斗结束剧情调用指令
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="callBlockName">待执行 Block 名称</param>
    /// <param name="callFlowchartName">待执行 Flowchart 名称</param>
    public static JBlock AfterFight(this JBlock block, string callBlockName, string callFlowchartName = "")
    {
        block.CreateCommand<JAfterFight>().Create(callBlockName, callFlowchartName);
        return block;
    }

    /// <summary>
    /// 战斗结束剧情调用指令
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="callBlock">待执行 Block 数据</param>
    /// <param name="callFlowchart">待执行 Flowchart 数据</param>
    public static JBlock AfterFight(this JBlock block, Block callBlock, Flowchart callFlowchart = null)
    {
        block.CreateCommand<JAfterFight>().Create(callBlock, callFlowchart);
        return block;
    }

    /// <summary>
    /// 游戏自动存档指令
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    public static JBlock AutoSave(this JBlock block)
    {
        block.CreateCommand<JAutoSave>().Create();
        return block;
    }

    /// <summary>
    /// 剧情跳转指令封装
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="targetBlock">待跳转 Block 对象</param>
    public static JBlock Call(this JBlock block, JBlock targetBlock)
    {
        block.CreateCommand<JCall>().Create(targetBlock);
        return block;
    }

    /// <summary>
    /// 剧情跳转指令封装
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="targetFlowchartName">待跳转 Flowchart 对象名称</param>
    /// <param name="targetBlockName">待跳转 Block 对象名称</param>
    /// <param name="commandItemId">待跳转 Command ItemId</param>
    /// <param name="mode">跳转模式</param>
    public static JBlock Call(this JBlock block, string targetFlowchartName, string targetBlockName,
        int commandItemId = -1, CallMode mode = CallMode.Stop)
    {
        block.CreateCommand<JCall>().Create(targetBlockName, targetFlowchartName, commandItemId, mode);
        return block;
    }

    /// <summary>
    /// 关闭 Tab 界面指令封装
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    public static JBlock CloseTab(this JBlock block)
    {
        block.CreateCommand<JCloseTab>().Create();
        return block;
    }

    /// <summary>
    /// 淡入淡出指令
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="hide">淡入或淡出操作</param>
    /// <param name="texture2D">加载图片</param>
    /// <param name="isWait">是否等待动画执行完</param>
    public static JBlock FadeScreen(this JBlock block, bool hide, Texture2D texture2D = null, bool isWait = true)
    {
        block.CreateCommand<JFadeScreen>().Create(hide, texture2D, isWait);
        return block;
    }

    /// <summary>
    /// 淡入淡出指令 UI 处理增强
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="go">待调整 GameObject 对象</param>
    /// <param name="active">激活状态</param>
    public static JBlock FadeScreenUI(this JBlock block, GameObject go, bool active)
    {
        block.CreateCommand<JFadeScreen>().Create(true);
        block.CreateCommand<JRun>().Create(() => { go.SetActive(active); });
        block.CreateCommand<JFadeScreen>().Create(false);
        return block;
    }

    /// <summary>
    /// 淡入淡出指令 UI 处理增强
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="tf">待调整 Transform 对象</param>
    /// <param name="active">激活状态</param>
    public static JBlock FadeScreenUI(this JBlock block, Transform tf, bool active)
    {
        block.CreateCommand<JFadeScreen>().Create(true);
        block.CreateCommand<JRun>().Create(() => { tf.gameObject.SetActive(active); });
        block.CreateCommand<JFadeScreen>().Create(false);
        return block;
    }

    /// <summary>
    /// 隐藏 CG 显示
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    public static JBlock HideCg(this JBlock block)
    {
        block.CreateCommand<JHideCg>().Create();
        return block;
    }

    /// <summary>
    /// 剧情判断指令封装
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="targetBlock">待跳转 Flowchart 对象</param>
    /// <param name="evaluate">判断条件</param>
    public static JBlock If(this JBlock block, JBlock targetBlock, Func<bool> evaluate)
    {
        block.CreateCommand<JIf>().Create(targetBlock, evaluate);
        return block;
    }

    /// <summary>
    /// 战斗时剧情调用指令
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="callBlockName">待执行 Block 名称</param>
    /// <param name="callFlowchartName">待执行 Flowchart 名称</param>
    public static JBlock InnerFight(this JBlock block, string callBlockName, string callFlowchartName = "")
    {
        block.CreateCommand<JInnerFight>().Create(callBlockName, callFlowchartName);
        return block;
    }

    /// <summary>
    /// 战斗时剧情调用指令
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="callBlock">待执行 Block 数据</param>
    /// <param name="callFlowchart">待执行 Flowchart 数据</param>
    public static JBlock InnerFight(this JBlock block, Block callBlock, Flowchart callFlowchart = null)
    {
        block.CreateCommand<JInnerFight>().Create(callBlock, callFlowchart);
        return block;
    }

    /// <summary>
    /// 学习神通
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="skillId">神通编号</param>
    public static JBlock LearnSkill(this JBlock block, int skillId)
    {
        block.CreateCommand<JLearningSkill>().Create(skillId);
        return block;
    }

    /// <summary>
    /// 学习功法
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="skillId">功法编号</param>
    public static JBlock LearnStaticSkill(this JBlock block, int skillId)
    {
        block.CreateCommand<JLearningStaticSkill>().Create(skillId);
        return block;
    }

    /// <summary>
    /// 场景加载指令
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="sceneName">场景名称</param>
    public static JBlock LoadScene(this JBlock block, string sceneName)
    {
        block.CreateCommand<JLoadScene>().Create(sceneName);
        return block;
    }

    /// <summary>
    /// 游戏场景加载指令
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="sceneName">游戏场景名称</param>
    public static JBlock LoadGame(this JBlock block, string sceneName)
    {
        block.CreateCommand<JLoadGame>().Create(sceneName);
        return block;
    }

    /// <summary>
    /// 显示剧情对话选项并绑定对应的剧情选项跳转 Block
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="menuText">选项文本</param>
    /// <param name="targetBlock">目标 Block 对象</param>
    /// <param name="menuHideIfVisited">是否为一次性选项</param>
    public static JBlock Menu(this JBlock block, string menuText, JBlock targetBlock, bool menuHideIfVisited = false)
    {
        block.CreateCommand<JMenu>().Create(menuText, targetBlock, menuHideIfVisited: menuHideIfVisited);
        return block;
    }

    /// <summary>
    /// 角色对话选项指令封装
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="args">选项组</param>
    public static JBlock Menu(this JBlock block, params (string, JBlock)[] args)
    {
        foreach (var (item1, item2) in args)
        {
            block.CreateCommand<JMenu>().Create(item1, item2);
        }

        return block;
    }

    /// <summary>
    /// 角色对话选项指令封装
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="args">选项组</param>
    public static JBlock Menu(this JBlock block, params (string, string)[] args)
    {
        foreach (var (item1, item2) in args)
        {
            block.CreateCommand<JMenu>().Create(item1, item2);
        }

        return block;
    }

    /// <summary>
    /// 将指定任务进行到下一阶段
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="taskId">任务编号</param>
    /// <param name="popTip">是否显示提示</param>
    public static JBlock NextTask(this JBlock block, int taskId, bool popTip = true)
    {
        block.CreateCommand<JNextTask>().Create(taskId, popTip);
        return block;
    }

    /// <summary>
    /// 打开角色商店指令
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="avatarId">角色编号</param>
    /// <param name="action">关闭商店事件</param>
    public static JBlock OpenShop(this JBlock block, int avatarId, UnityAction action = null)
    {
        block.CreateCommand<JOpenShop>().Create(avatarId, action);
        return block;
    }

    /// <summary>
    /// 剧情分支指令封装
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="targetBlock1">待跳转 Flowchart 对象1</param>
    /// <param name="targetBlock2">待跳转 Flowchart 对象2</param>
    /// <param name="evaluate">判断条件</param>
    public static JBlock Or(this JBlock block, JBlock targetBlock1, JBlock targetBlock2, Func<bool> evaluate)
    {
        block.CreateCommand<JOr>().Create(targetBlock1, targetBlock2, evaluate);
        return block;
    }

    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="effect">音效对象</param>
    public static JBlock PlayEffect(this JBlock block, AudioClip effect)
    {
        block.CreateCommand<JPlayEffect>().Create(effect);
        return block;
    }

    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="effectName">音效名称</param>
    /// <param name="pitch">播放时长</param>
    public static JBlock PlayEffect(this JBlock block, string effectName, float pitch = 1f)
    {
        block.CreateCommand<JPlayEffect>().Create(effectName, pitch);
        return block;
    }

    /// <summary>
    /// 播放背景音乐
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="music">音乐对象</param>
    /// <param name="actionTime">起始播放时间</param>
    /// <param name="playLoop">是否循环播放</param>
    public static JBlock PlayMusic(this JBlock block, AudioClip music, float actionTime = 0f, bool playLoop = false)
    {
        block.CreateCommand<JPlayMusic>().Create(music, actionTime, playLoop);
        return block;
    }

    /// <summary>
    /// 播放背景音乐
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="musicName">音乐名称</param>
    public static JBlock PlayMusic(this JBlock block, string musicName)
    {
        block.CreateCommand<JPlayMusic>().Create(musicName);
        return block;
    }

    /// <summary>
    /// 提示信息
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="message">消息内容</param>
    /// <param name="type">消息类型</param>
    /// <param name="sound">播放声音名称</param>
    public static JBlock PopTip(this JBlock block, string message, PopTipIconType type = PopTipIconType.叹号,
        string sound = "")
    {
        block.CreateCommand<JPopTip>().Create(message, type, sound);
        return block;
    }

    /// <summary>
    /// 恢复血量指令
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    public static JBlock RestoreHp(this JBlock block)
    {
        block.CreateCommand<JRestoreHp>().Create();
        return block;
    }

    /// <summary>
    /// 剧情函数执行指令封装
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="action">执行函数</param>
    public static JBlock Run(this JBlock block, Action action)
    {
        block.CreateCommand<JRun>().Create(action);
        return block;
    }

    /// <summary>
    /// 角色对话指令封装
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="avatar">对话角色</param>
    /// <param name="text">对话文本</param>
    public static JBlock Say(this JBlock block, JSay.Avatar avatar, string text)
    {
        block.CreateCommand<JSay>().Create(avatar, text);
        return block;
    }

    /// <summary>
    /// 角色对话指令封装
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="id">对话角色编号</param>
    /// <param name="text">对话文本</param>
    public static JBlock Say(this JBlock block, int id, string text)
    {
        block.CreateCommand<JSay>().Create(id, text);
        return block;
    }

    /// <summary>
    /// 角色对话指令封装
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="avatar">对话角色</param>
    /// <param name="text1">对话文本1</param>
    /// <param name="text2">对话文本2</param>
    /// <param name="evaluate">判定条件</param>
    public static JBlock Say(this JBlock block, JSay.Avatar avatar, string text1, string text2, Func<bool> evaluate)
    {
        block.CreateCommand<JSay>().Create(avatar, text1, text2, evaluate);
        return block;
    }

    /// <summary>
    /// 角色对话指令封装
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="id">对话角色编号</param>
    /// <param name="text1">对话文本1</param>
    /// <param name="text2">对话文本2</param>
    /// <param name="evaluate">判定条件</param>
    public static JBlock Say(this JBlock block, int id, string text1, string text2, Func<bool> evaluate)
    {
        block.CreateCommand<JSay>().Create(id, text1, text2, evaluate);
        return block;
    }

    /// <summary>
    /// 摇晃摄影机指令
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    public static JBlock ShakeCamera(this JBlock block)
    {
        block.CreateCommand<JShakeCamera>().Create();
        return block;
    }

    /// <summary>
    /// 显示 CG 指令
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="cgName">cg 图片名称</param>
    public static JBlock ShowCg(this JBlock block, string cgName)
    {
        block.CreateCommand<JShowCg>().Create(cgName);
        return block;
    }

    /// <summary>
    /// 显示 CG 指令
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="sprite">sprite 资源对象</param>
    public static JBlock ShowCg(this JBlock block, Sprite sprite)
    {
        block.CreateCommand<JShowCg>().Create(sprite);
        return block;
    }

    /// <summary>
    /// 开始战斗指令
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    /// <param name="monsterId">战斗对象编号</param>
    /// <param name="fightType">战斗类型</param>
    /// <param name="canRun">是否可以逃跑</param>
    /// <param name="backgroundId">背景图编号</param>
    /// <param name="music">播放音乐名称</param>
    /// <param name="isSea">是否为海上NPC(战斗后会移除)</param>
    /// <param name="playerBuffs">战斗时主角额外buff</param>
    /// <param name="monsterBuffs">战斗时对象额外buff</param>
    public static JBlock StartFight(this JBlock block, int monsterId, StartFight.FightEnumType fightType,
        bool canRun = true, int backgroundId = 0, string music = "战斗1", bool isSea = false,
        List<StarttFightAddBuff> playerBuffs = null, List<StarttFightAddBuff> monsterBuffs = null)
    {
        block.CreateCommand<JStartFight>().Create(monsterId, fightType, canRun, backgroundId, music, isSea,
            playerBuffs, monsterBuffs);
        return block;
    }

    /// <summary>
    /// 停止播放音乐指令
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    public static JBlock StopMusic(this JBlock block)
    {
        block.CreateCommand<JStopMusic>().Create();
        return block;
    }

    /// <summary>
    /// 剧情黑屏等待指令封装
    /// </summary>
    /// <param name="block">JBlock 对象</param>
    public static JBlock Wait(this JBlock block)
    {
        block.CreateCommand<JWait>().Create();
        return block;
    }
}