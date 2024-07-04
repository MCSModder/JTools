using System;
using System.Collections.Generic;
using JSONClass;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools.Model.Entity;

/// <summary>NPC 实例绑定数据实体类</summary>
[Serializable]
public class NpcBindEntity
{
    #region 字段属性

    /// <summary>NPC 实例绑定编号</summary>
    public virtual int Id { get; set; }

    /// <summary>NPC 实例绑定名称</summary>
    public virtual string Name { get; set; }

    /// <summary>NPC 实例绑定称号</summary>
    public virtual string Title { get; set; }

    /// <summary>NPC 实例绑定形象</summary>
    public virtual int Image { get; set; }

    /// <summary>NPC 实例绑定拍卖会形象</summary>
    public virtual int AuctionsImage { get; set; }

    /// <summary>NPC 实例绑定立绘组</summary>
    public virtual List<int> Avatars { get; set; }

    /// <summary>起始时间</summary>
    public virtual string StartTime { get; set; }

    /// <summary>终止时间</summary>
    public virtual string EndTime { get; set; }

    #endregion

    #region 构造方法

    public void Create(WuJiangBangDing data)
    {
        Id = data.id;
        Name = data.Name;
        Title = data.Title;
        Image = data.Image;
        AuctionsImage = data.PaiMaiHang;
        Avatars = data.avatar;
        StartTime = data.TimeStart;
        EndTime = data.TimeEnd;
    }

    #endregion

    #region 公开方法

    public JSONObject ToJsonObject()
    {
        var data = JSONObject.Create();
        data.AddField("id", Id);
        data.AddField("Name", Name);
        data.AddField("Title", Title);
        data.AddField("Image", Image);
        data.AddField("PaiMaiHang", AuctionsImage);
        data.AddField("avatar", Avatars.ToJsonObject());
        data.AddField("TimeStart", StartTime);
        data.AddField("TimeEnd", EndTime);
        return data;
    }

    #endregion
}