using System;
using JSONClass;

namespace TierneyJohn.MiChangSheng.JTools.Model.Entity;

/// <summary>生平数据实体类</summary>
[Serializable]
public class BiographyEntity
{
    #region 字段属性

    /// <summary>生平编号</summary>
    public virtual string Id { get; set; }

    /// <summary>生平信息</summary>
    public virtual string Info { get; set; }

    /// <summary>生平优先级</summary>
    public virtual int Priority { get; set; }

    /// <summary>是否唯一</summary>
    public virtual bool Once { get; set; }

    #endregion

    #region 构造方法

    public void Create(ShengPing data)
    {
        Id = data.id;
        Info = data.descr;
        Priority = data.priority;
        Once = data.IsChongfu == 1;
    }

    #endregion

    #region 公开方法

    public JSONObject ToJsonObject()
    {
        var data = JSONObject.Create();
        data.SetField("id", Id);
        data.SetField("descr", Info);
        data.SetField("IsChongfu", Once ? 1 : 0);
        data.SetField("priority", Priority);
        return data;
    }

    #endregion
}