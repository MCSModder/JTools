using System;
using Fungus;

namespace TierneyJohn.MiChangSheng.JTools.Fungus.JCommand
{
    /// <summary>
    /// JTools 封装 LearningSkill 指令
    /// </summary>
    [Serializable]
    public class JLearningSkill : LearningSkill
    {
        #region 构筑方法

        /// <summary>
        /// 学习神通
        /// </summary>
        /// <param name="skillId">神通编号</param>
        /// <returns>JLearningSkill 对象</returns>
        public JLearningSkill Create(int skillId)
        {
            skillID = skillId;
            return this;
        }

        #endregion
    }
}