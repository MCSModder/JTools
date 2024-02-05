using System;
using Fungus;

namespace TierneyJohn.MiChangSheng.JTools.Fungus.JCommand
{
    /// <summary>
    /// JTools 封装 Say 指令
    /// </summary>
    [Serializable]
    public class JSay : Say
    {
        #region 字段/属性

        public delegate bool EvaluateDelegate();

        private EvaluateDelegate _evaluate;

        private string _text1;
        private string _text2;

        private const string DialogPatch = "DialogImage";

        #endregion

        #region 构造方法

        /// <summary>
        /// 剧情对话指令
        /// </summary>
        /// <param name="id">对话角色编号</param>
        /// <param name="text">对话文本</param>
        /// <param name="type">对话类型</param>
        /// <returns>JSay 对象</returns>
        public JSay Create(int id, string text, StartFight.MonstarType type = StartFight.MonstarType.Normal)
        {
            SetAvatar(id, type);
            storyText = text;
            return this;
        }

        /// <summary>
        /// 剧情对话指令
        /// </summary>
        /// <param name="avatar">对话角色</param>
        /// <param name="text">对话文本</param>
        /// <param name="type">对话类型</param>
        /// <returns>JSay 对象</returns>
        public JSay Create(Avatar avatar, string text, StartFight.MonstarType type = StartFight.MonstarType.Normal)
        {
            SetAvatar((int)avatar, type);
            storyText = text;
            return this;
        }

        /// <summary>
        /// 高级剧情对话指令
        /// 对话前会先执行条件验证，若结果为 True 则执行对话文本1 否则执行对话文本2
        /// </summary>
        /// <param name="id">对话角色编号</param>
        /// <param name="text">对话文本1</param>
        /// <param name="text2">对话文本2</param>
        /// <param name="evaluate">判断条件</param>
        /// <param name="type">对话类型</param>
        /// <returns>JSay 对象</returns>
        public JSay Create(int id, string text, string text2, EvaluateDelegate evaluate,
            StartFight.MonstarType type = StartFight.MonstarType.Normal)
        {
            SetAvatar(id, type);
            _text1 = text;
            _text2 = text2;
            _evaluate = evaluate;
            return this;
        }

        /// <summary>
        /// 高级剧情对话指令
        /// 对话前会先执行条件验证，若结果为 True 则执行对话文本1 否则执行对话文本2
        /// </summary>
        /// <param name="avatar">对话角色</param>
        /// <param name="text">对话文本1</param>
        /// <param name="text2">对话文本2</param>
        /// <param name="evaluate">判断条件</param>
        /// <param name="type">对话类型</param>
        /// <returns>JSay 对象</returns>
        public JSay Create(Avatar avatar, string text, string text2, EvaluateDelegate evaluate,
            StartFight.MonstarType type = StartFight.MonstarType.Normal)
        {
            SetAvatar((int)avatar, type);
            _text1 = text;
            _text2 = text2;
            _evaluate = evaluate;
            return this;
        }

        #endregion

        #region 重构方法

        public override void OnEnter()
        {
            if (_evaluate != null)
            {
                storyText = _evaluate.Invoke() ? _text1 : _text2;
            }

            portrait = ResManager.inst.LoadSprite($"{DialogPatch}/{AvatarIntID}");

            base.OnEnter();
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 设置当前对话角色
        /// </summary>
        /// <param name="id">角色编号</param>
        /// <param name="type">角色类型</param>
        private void SetAvatar(int id, StartFight.MonstarType type)
        {
            AvatarIntID = id;
            AvatarIDSetType = type;
            if (AvatarID != null) AvatarID.Value = id;
        }

        #endregion

        #region 固定角色编号对照声明

        public enum Avatar
        {
            旁白 = 0,
            主角 = 1,
            魏无极 = 2,
            混元子 = 7,
            通羽真人 = 9,
            灵武真人 = 101,
            明河剑仙 = 103,
            玄阴剑仙 = 104,
            龙阳上人 = 107,
            镇元剑仙 = 108,
            萧千绝 = 117,
            徐凡 = 137,
            青竹道人 = 201,
            紫菱仙子 = 202,
            长春真人 = 203,
            青蛇真人 = 204,
            毒道人 = 211,
            李青麟 = 217,
            温杰 = 239,
            枯木老祖 = 261,
            云玑天师 = 301,
            玄伶仙子 = 302,
            润熹仙子 = 303,
            凝霜仙子 = 304,
            奕云仙子 = 307,
            流月仙子 = 309,
            慕容颖 = 317,
            恒火真君 = 401,
            火云老祖 = 407,
            苍坤上人 = 408,
            正阳道长 = 409,
            炎萧 = 417,
            焦飞 = 421,
            钟燚 = 440,
            晟慧真君 = 501,
            冶庚上人 = 502,
            恒如真人 = 503,
            鸢本仙子 = 504,
            澹台仙 = 517,
            赤发鬼 = 601,
            青面鬼 = 602,
            杜老二 = 606,
            颜老怪 = 607,
            倪旭欣 = 609,
            黑心老人 = 610,
            天邪子 = 611,
            血薇仙子 = 612,
            一仙道人 = 613,
            林沐心 = 614,
            百里奇 = 615,
            公孙季 = 616,
        }

        #endregion
    }
}