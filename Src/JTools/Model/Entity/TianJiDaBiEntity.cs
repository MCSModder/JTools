using System;
using JSONClass;

namespace TierneyJohn.MiChangSheng.JTools.Model.Entity;

/// <summary>天机大比数据实体类</summary>
[Serializable]
public class TianJiDaBiEntity
{
    #region 字段属性

    /// <summary>数据编号</summary>
    public virtual int Id { get; set; }

    /// <summary>优先级</summary>
    public virtual int YouXian { get; set; }

    /// <summary>流派编号</summary>
    public virtual int LiuPai { get; set; }

    #endregion

    #region 构造方法

    public void Create(TianJiDaBi data)
    {
        Id = data.id;
        YouXian = data.YouXian;
        LiuPai = data.LiuPai;
    }

    #endregion

    #region 公开方法

    public JSONObject ToJsonObject()
    {
        var data = JSONObject.Create();
        data.SetField("id", Id);
        data.SetField("YouXian", YouXian);
        data.SetField("LiuPai", LiuPai);
        return data;
    }

    #endregion
}