using System;
using Fungus;

namespace TierneyJohn.MiChangSheng.JTools.Fungus.JCommand
{
    /// <summary>
    /// JTools 封装 AddTime 指令
    /// </summary>
    [Serializable]
    public class JAddTime : AddTime
    {
        #region 构造方法

        /// <summary>
        /// 时间流逝
        /// </summary>
        /// <param name="year">增加年份</param>
        /// <param name="month">增加月份</param>
        /// <param name="day">增加天数</param>
        /// <param name="billingFlag">是否不结算 Npc 数据</param>
        /// <returns>JAddTime 对象</returns>
        public JAddTime Create(int year, int month, int day, bool billingFlag = false)
        {
            Year = year;
            Month = month;
            Day = day;
            IsNoJieSuan = billingFlag;
            return this;
        }

        #endregion
    }
}