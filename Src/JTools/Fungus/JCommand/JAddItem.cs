using System;
using Fungus;

namespace TierneyJohn.MiChangSheng.JTools.Fungus.JCommand
{
    /// <summary>
    /// JTools 封装 AddItem 指令
    /// </summary>
    [Serializable]
    public class JAddItem : AddItem
    {
        #region 构造方法

        /// <summary>
        /// 添加或移除指定物品指令
        /// </summary>
        /// <param name="item">物品编号</param>
        /// <param name="itemNum">物品数量 (若为正数则为添加物品,负数则为移除物品)</param>
        /// <param name="popTip">添加物品信息提示</param>
        /// <returns>JAddItem 对象</returns>
        public JAddItem Create(int item, int itemNum, bool popTip = true)
        {
            ItemID = item;
            ItemNum = itemNum;
            showText = popTip;
            return this;
        }

        #endregion

        #region 公开方法

        public override void OnEnter()
        {
            if (ItemNum > 0)
            {
                PlayerEx.Player.addItem(ItemID, ItemNum, Tools.CreateItemSeid(ItemID), showText);
            }
            else
            {
                PlayerEx.Player.removeItem(ItemID, Math.Abs(ItemNum));
            }

            Continue();
        }

        #endregion
    }
}