using System;
using Fungus;
using TierneyJohn.MiChangSheng.JTools.Fungus;
using TierneyJohn.MiChangSheng.JTools.Fungus.JCommand;
using UnityEngine;

namespace TierneyJohn.MiChangSheng.JTools.Tool
{
    /// <summary>
    /// Fungus 数据处理工具
    /// </summary>
    public static class FungusTools
    {
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
        public static JBlock If(this JBlock block, JBlock targetBlock, JIf.EvaluateDelegate evaluate)
        {
            block.CreateCommand<JIf>().Create(targetBlock, evaluate);
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
        /// 剧情分支指令封装
        /// </summary>
        /// <param name="block">JBlock 对象</param>
        /// <param name="targetBlock1">待跳转 Flowchart 对象1</param>
        /// <param name="targetBlock2">待跳转 Flowchart 对象2</param>
        /// <param name="evaluate">判断条件</param>
        public static JBlock Or(this JBlock block, JBlock targetBlock1, JBlock targetBlock2,
            JOr.EvaluateDelegate evaluate)
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
        public static JBlock PlayMusic(this JBlock block, AudioClip music, float actionTime = 0f, bool playLoop = true)
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
        public static JBlock Say(this JBlock block, JSay.Avatar avatar, string text1, string text2,
            JSay.EvaluateDelegate evaluate)
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
        public static JBlock Say(this JBlock block, int id, string text1, string text2, JSay.EvaluateDelegate evaluate)
        {
            block.CreateCommand<JSay>().Create(id, text1, text2, evaluate);
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
        /// 剧情黑屏等待指令封装
        /// </summary>
        /// <param name="block">JBlock 对象</param>
        public static JBlock Wait(this JBlock block)
        {
            block.CreateCommand<JWait>().Create();
            return block;
        }
    }
}