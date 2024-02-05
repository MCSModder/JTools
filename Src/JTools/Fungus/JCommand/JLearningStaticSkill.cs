using System;
using Fungus;

namespace TierneyJohn.MiChangSheng.JTools.Fungus.JCommand
{
    /// <summary>
    /// JTools 封装 LearningStaticSkill 指令
    /// </summary>
    [Serializable]
    public class JLearningStaticSkill : LearningStaticSkill
    {
        #region 构筑方法

        /// <summary>
        /// 学习功法
        /// </summary>
        /// <param name="skillId">功法编号</param>
        /// <returns>JLearningStaticSkill 对象</returns>
        public JLearningStaticSkill Create(int skillId)
        {
            skillID = skillId;
            return this;
        }

        #endregion
    }
}