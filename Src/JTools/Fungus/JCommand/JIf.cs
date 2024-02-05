﻿using System;
using System.Collections;
using Fungus;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TierneyJohn.MiChangSheng.JTools.Fungus.JCommand
{
    /// <summary>
    /// JTools 封装 If 指令
    /// </summary>
    [Serializable]
    public class JIf : Command
    {
        #region 字段/属性/方法声明

        public delegate bool EvaluateDelegate();

        private EvaluateDelegate _evaluate;

        private Block _targetBlock;

        #endregion

        #region 构造方法

        /// <summary>
        /// 根据条件跳转目标 Block 指令
        /// 若满足条件则跳转到指定 Block 中，若不满足条件则继续执行后续内容
        /// </summary>
        /// <param name="targetBlock">目标 Block</param>
        /// <param name="evaluate">判定条件函数 (需要返回一个 bool 值)</param>
        /// <returns>JIf 对象</returns>
        public JIf Create(JBlock targetBlock, EvaluateDelegate evaluate)
        {
            _evaluate = evaluate;
            _targetBlock = targetBlock;
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

            if (_evaluate.Invoke())
            {
                EventSystem.current.SetSelectedGameObject(null);
                StopAllCoroutines();
                var sayDialog = SayDialog.GetSayDialog();
                if (sayDialog != null)
                {
                    sayDialog.FadeWhenDone = true;
                }

                if (_targetBlock == null) return;

                var flowchart = _targetBlock.GetFlowchart();
                flowchart.StartCoroutine(CallBlock(_targetBlock));
            }
            else
            {
                Continue();
            }
        }

        public override bool OpenBlock() => true;

        #endregion

        #region 私有方法

        private IEnumerator CallBlock(Block block)
        {
            yield return new WaitForEndOfFrame();
            block.StartExecution();
        }

        #endregion
    }
}