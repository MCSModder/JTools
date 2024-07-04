using System;
using System.Collections.Generic;
using JSONClass;
using TierneyJohn.MiChangSheng.JTools.Model.Enum.Task;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools.Model.Entity;

/// <summary>任务数据实体类</summary>
[Serializable]
public class TaskEntity
{
    #region 字段属性

    /// <summary>任务编号</summary>
    public virtual int Id { get; set; }

    /// <summary>任务名称</summary>
    public virtual string TaskName { get; set; }

    /// <summary>任务来源</summary>
    public virtual string Title { get; set; }

    /// <summary>任务类型</summary>
    public virtual TaskType Type { get; set; }

    /// <summary>任务描述</summary>
    public virtual string Desc { get; set; }

    /// <summary>任务开始时间</summary>
    public virtual string StartTime { get; set; }

    /// <summary>任务结束时间</summary>
    public virtual string EndTime { get; set; }

    /// <summary>任务详情</summary>
    public virtual List<TaskInfoEntity> TaskInfos { get; set; } = [];

    /// <summary>任务完成标记</summary>
    public virtual bool IsFinish { get; set; }

    /// <summary>过时变量</summary>
    public virtual int Variable { get; set; } = 999;

    /// <summary>任务循环 (年)</summary>
    public virtual int Circulation { get; set; }

    /// <summary>任务持续时间 (月)</summary>
    public virtual int ContinueTime { get; set; }

    /// <summary>地图标记点</summary>
    public virtual int MapIndex { get; set; }

    /// <summary>任务完成变量</summary>
    public virtual List<int> EventValue { get; set; } = [];

    /// <summary>变量比较符号</summary>
    public virtual string Flag { get; set; } = "";

    #endregion

    #region 构造方法

    public void Create(TaskJsonData data)
    {
        Id = data.id;
        TaskName = data.Name;
        Type = (TaskType)data.Type;
        Variable = data.variable;
        Circulation = data.circulation;
        MapIndex = data.mapIndex;
        ContinueTime = data.continueTime;
        IsFinish = data.isFinsh == 1;
        Title = data.Title;
        Desc = data.Desc;
        StartTime = data.StarTime;
        EndTime = data.EndTime;
        Flag = data.fuhao;
        EventValue = data.EventValue;
    }

    #endregion

    #region 公开方法

    public JSONObject ToJsonObject()
    {
        var data = JSONObject.Create();
        data.SetField("id", Id);
        data.SetField("Name", TaskName);
        data.SetField("Type", (int)Type);
        data.SetField("variable", Variable);
        data.SetField("Title", Title);
        data.SetField("Desc", Desc);
        data.SetField("StarTime", StartTime);
        data.SetField("EndTime", EndTime);
        data.SetField("circulation", Circulation);
        data.SetField("mapIndex", MapIndex);
        data.SetField("continueTime", ContinueTime);
        data.SetField("isFinsh", IsFinish ? 1 : 0);
        data.SetField("EventValue", EventValue.ToJsonObject());
        data.SetField("fuhao", Flag);
        return data;
    }

    #endregion
}