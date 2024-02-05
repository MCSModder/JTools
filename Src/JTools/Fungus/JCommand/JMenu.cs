using System;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools.Fungus.JCommand
{
    /// <summary>
    /// JTools 封装 Menu 指令
    /// </summary>
    [Serializable]
    public class JMenu : global::Fungus.Menu
    {
        #region 字段/属性

        private string _targetBlockName;

        #endregion

        #region 构造方法

        /// <summary>
        /// 显示剧情对话选项并绑定对应的剧情选项跳转 Block
        /// </summary>
        /// <param name="menuText">选项文本</param>
        /// <param name="menuTargetBlock">目标 Block 对象</param>
        /// <param name="menuInteractable">是否禁用该选项 (会显示但是无法选中)</param>
        /// <param name="menuHideIfVisited">是否为一次性选项 (若先前选择过该选项则会自动移除)</param>
        /// <returns>JMenu 对象</returns>
        public JMenu Create(string menuText, JBlock menuTargetBlock, bool menuInteractable = true,
            bool menuHideIfVisited = false)
        {
            text = menuText;
            interactable.Value = menuInteractable;
            hideIfVisited = menuHideIfVisited;
            targetBlock = menuTargetBlock;
            return this;
        }

        /// <summary>
        /// 显示剧情对话选项并绑定对应的剧情选项跳转 Block
        /// </summary>
        /// <param name="menuText">选项文本</param>
        /// <param name="menuTargetBlockName">目标 Block 对象名称</param>
        /// <param name="menuInteractable">是否禁用该选项 (会显示但是无法选中)</param>
        /// <param name="menuHideIfVisited">是否为一次性选项 (若先前选择过该选项则会自动移除)</param>
        /// <returns>JMenu 对象</returns>
        public JMenu Create(string menuText, string menuTargetBlockName, bool menuInteractable = true,
            bool menuHideIfVisited = false)
        {
            text = menuText;
            interactable.Value = menuInteractable;
            hideIfVisited = menuHideIfVisited;
            _targetBlockName = menuTargetBlockName;
            return this;
        }

        #endregion

        #region 公开方法

        public override void OnEnter()
        {
            if (targetBlock == null)
            {
                targetBlock = GetFlowchart().GetBlockByFlowchart(_targetBlockName);
            }

            base.OnEnter();
        }

        #endregion
    }
}