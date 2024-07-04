using System;
using JSONClass;

namespace TierneyJohn.MiChangSheng.JTools.Model.Entity;

/// <summary>任务信息数据实体类</summary>
[Serializable]
public class TaskInfoEntity
{
    #region 字段属性

    /// <summary>任务详情编号</summary>
    public virtual int Id { get; set; }

    /// <summary>任务编号</summary>
    public virtual int TaskId { get; set; }

    /// <summary>任务索引</summary>
    public virtual int TaskIndex { get; set; }

    /// <summary>任务描述</summary>
    public virtual string Desc { get; set; }

    /// <summary>是否为最终任务</summary>
    public virtual bool IsFinal { get; set; }

    /// <summary>大地图标记点</summary>
    public virtual int MapIndex { get; set; }

    #endregion

    #region 构造方法

    public void Create(TaskInfoJsonData data)
    {
        Id = data.id;
        TaskId = data.TaskID;
        TaskIndex = data.TaskIndex;
        Desc = data.Desc;
        MapIndex = data.mapIndex;
        IsFinal = data.IsFinal == 1;
    }

    #endregion

    #region 公开方法

    public JSONObject ToJsonObject()
    {
        var data = JSONObject.Create();
        data.SetField("id", Id);
        data.SetField("TaskID", TaskId);
        data.SetField("TaskIndex", TaskIndex);
        data.SetField("Desc", Desc);
        data.SetField("mapIndex", MapIndex);
        data.SetField("IsFinal", IsFinal ? 1 : 0);
        return data;
    }

    #endregion
}