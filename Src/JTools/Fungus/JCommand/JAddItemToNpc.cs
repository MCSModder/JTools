using System;
using Fungus;

namespace TierneyJohn.MiChangSheng.JTools.Fungus.JCommand
{
    /// <summary>
    /// JTools 封装 JAddItemToNpc 指令
    /// </summary>
    [Serializable]
    public class JAddItemToNpc : Command
    {
        #region 字段/属性/方法声明

        private int _npcId;
        private int _addItemId;
        private int _addItemNum;

        #endregion

        #region 构造方法

        /// <summary>
        /// 给指定 Npc 添加指定物品指令
        /// </summary>
        /// <param name="npcId">Npc 编号</param>
        /// <param name="addItemId">物品编号</param>
        /// <param name="addItemNum">物品数量 (若为正数则为添加物品,负数则为移除物品)</param>
        /// <returns>JAddItem 对象</returns>
        public JAddItemToNpc Create(int npcId, int addItemId, int addItemNum = 1)
        {
            _npcId = npcId;
            _addItemId = addItemId;
            _addItemNum = addItemNum;
            return this;
        }

        #endregion

        #region 公开方法

        public override void OnEnter()
        {
            var npcId = NPCEx.NPCIDToNew(_npcId);
            NpcJieSuanManager.inst.AddItemToNpcBackpack(npcId, _addItemId, _addItemNum);
            Continue();
        }

        #endregion
    }
}