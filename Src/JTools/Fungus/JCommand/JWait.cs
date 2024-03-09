using System;
using Fungus;

namespace TierneyJohn.MiChangSheng.JTools.Fungus.JCommand
{
    /// <summary>
    /// JTools 封装黑屏等待指令
    /// </summary>
    [Serializable]
    public class JWait : Command
    {
        #region 构造方法

        /// <summary>
        /// 执行指定代码指令
        /// </summary>
        /// <returns>JWait 对象</returns>
        public JWait Create()
        {
            return this;
        }

        #endregion

        #region 公开方法

        public override void OnEnter()
        {
            if (ParentBlock == null)
            {
                return;
            }

            if (CommandIndex >= ParentBlock.commandList.Count - 1)
            {
                StopParentBlock();
            }

            if (PanelMamager.inst.UIBlackMaskGameObject == null)
            {
                Instantiate(ResManager.inst.LoadPrefab("BlackHide"));
            }

            PanelMamager.inst.UIBlackMaskGameObject.SetActive(false);
            PanelMamager.inst.UIBlackMaskGameObject.SetActive(true);
            Continue();
        }

        #endregion
    }
}