using System;

namespace TierneyJohn.MiChangSheng.JTools.Model.TimeFlag;

/// <summary>
/// 时间标记数据
/// </summary>
[Serializable]
public class TimeFlag
{
    #region 字段声明

    public string id;

    public bool isFinal;

    public DateTime DateTime;

    public Action Action;

    #endregion

    #region 构造函数

    public TimeFlag(string id, DateTime dateTime, Action action, bool isFinal = true)
    {
        this.id = id;
        this.isFinal = isFinal;
        DateTime = dateTime;
        Action = action;
    }

    public TimeFlag(string id, Action action, bool isFinal = true)
    {
        this.id = id;
        this.isFinal = isFinal;
        DateTime = DateTime.Parse(id);
        Action = action;
    }

    public TimeFlag(DateTime dateTime, Action action, bool isFinal = true)
    {
        id = $"{dateTime.Year}-{dateTime.Month}-{dateTime.Day}";
        this.isFinal = isFinal;
        DateTime = dateTime;
        Action = action;
    }

    #endregion
}