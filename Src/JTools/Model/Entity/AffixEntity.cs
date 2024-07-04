using System;
using JSONClass;
using TierneyJohn.MiChangSheng.JTools.Model.Enum.Affix;

namespace TierneyJohn.MiChangSheng.JTools.Model.Entity;

/// <summary>词缀数据实体类</summary>
[Serializable]
public class AffixEntity
{
    #region 字段属性

    /// <summary>词缀编号</summary>
    public virtual int Id { get; set; }

    /// <summary>词缀名称</summary>
    public virtual string Name { get; set; }

    /// <summary>词缀类型</summary>
    public virtual AffixType AffixType { get; set; }

    /// <summary>词缀描述</summary>
    public virtual string Desc { get; set; }

    /// <summary>词缀所属 (默认为词缀)</summary>
    public virtual string Title { get; set; } = "词缀";

    /// <summary>词缀所属编号 (默认 101)</summary>
    public virtual int TitleId { get; set; } = 101;

    #endregion

    #region 构造方法

    public void Create(TuJianChunWenBen data)
    {
        Id = data.id;
        Name = data.name2;
        AffixType = (AffixType)data.type;
        Desc = data.descr;
        Title = data.name1;
        TitleId = data.typenum;
    }

    #endregion

    #region 公开方法

    public JSONObject ToJsonObject()
    {
        var data = JSONObject.Create();
        data.AddField("id", Id);
        data.AddField("name2", Name);
        data.AddField("type", (int)AffixType);
        data.AddField("descr", Desc);
        data.AddField("name1", Title);
        data.AddField("typenum", TitleId);
        return data;
    }

    #endregion
}