using UnityEngine;

namespace TierneyJohn.MiChangSheng.JTools_Editor.UI
{
    public class ResPanelUI : MonoBehaviour
    {
        public static ResPanelUI Inst;

        #region Unity 事件函数

        private void Awake()
        {
            Inst = this;
        }

        #endregion
    }
}