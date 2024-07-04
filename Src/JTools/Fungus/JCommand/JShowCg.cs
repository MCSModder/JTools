using System;
using Fungus;
using TierneyJohn.MiChangSheng.JTools.Manager;
using UnityEngine;

namespace TierneyJohn.MiChangSheng.JTools.Fungus.JCommand
{
    /// <summary>
    /// JTools 封装 ShowCG 指令
    /// </summary>
    [Serializable]
    public class JShowCg : Command
    {
        #region 字段/属性/方法声明

        private string _path;
        private Sprite _sprite;

        #endregion

        #region 构造方法

        /// <summary>
        /// 显示静态 CG 指令
        /// </summary>
        /// <param name="cg">cg 图片名称</param>
        /// <returns>JShowCg 对象</returns>
        public JShowCg Create(string cg)
        {
            _path = $"CG/{cg}";
            return this;
        }

        /// <summary>
        /// 显示 CG 指令
        /// </summary>
        /// <param name="sprite">sprite 资源对象</param>
        /// <returns>JShowCg 对象</returns>
        public JShowCg Create(Sprite sprite)
        {
            _sprite = sprite;
            return this;
        }

        #endregion

        #region 公开方法

        public override void OnEnter()
        {
            if (_sprite != null)
            {
                CgManager.Inst.ShowCg(_sprite);
            }
            else
            {
                CgManager.Inst.ShowCg(_path);
            }

            Continue();
        }

        #endregion
    }
}