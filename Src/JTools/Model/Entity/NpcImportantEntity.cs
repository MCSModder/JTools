using System;
using System.Collections.Generic;
using JSONClass;
using TierneyJohn.MiChangSheng.JTools.Model.Enum.Avatar;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools.Model.Entity;

/// <summary>NPC 实例数据实体类</summary>
[Serializable]
public class NpcImportantEntity
{
    #region 字段属性

    /// <summary>角色实例编号 (唯一)</summary>
    public virtual int Id { get; set; }

    /// <summary>角色实例年龄</summary>
    public virtual int Age { get; set; }

    /// <summary>角色实例性别</summary>
    public virtual AvatarSexType Sex { get; set; } = AvatarSexType.男;

    /// <summary>角色实例等级境界</summary>
    public virtual AvatarLevelType Level { get; set; } = AvatarLevelType.炼气初期;

    /// <summary>角色实例流派</summary>
    public virtual int LiuPai { get; set; }

    /// <summary>角色实例资质</summary>
    public virtual int Aptitude { get; set; }

    /// <summary>角色实例悟性</summary>
    public virtual int Perception { get; set; }

    /// <summary>角色实例性格</summary>
    public virtual int XingGe { get; set; }

    /// <summary>角色实例称号</summary>
    public virtual int Title { get; set; }

    /// <summary>角色实例标签</summary>
    public virtual int Tag { get; set; }

    /// <summary>角色实例筑基时间</summary>
    public virtual string ZhuJiTime { get; set; }

    /// <summary>角色实例金丹时间</summary>
    public virtual string JinDanTime { get; set; }

    /// <summary>角色实例元婴时间</summary>
    public virtual string YuanYingTime { get; set; }

    /// <summary>角色实例化神时间</summary>
    public virtual string HuaShenTime { get; set; }

    /// <summary>角色实例是否为门派大师兄/大师姐</summary>
    public virtual bool IsDaShiXiong { get; set; }

    /// <summary>角色实例是否为门派长老</summary>
    public virtual bool IsZhangLao { get; set; }

    /// <summary>角色实例是否为门派掌门</summary>
    public virtual bool IsZhangMen { get; set; }

    /// <summary>角色实例事件判定</summary>
    public virtual List<int> EventValue { get; set; }

    /// <summary>角色实例事件判定符号</summary>
    public virtual string FuHao { get; set; }

    #endregion

    #region 构造方法

    public void Create(NPCImportantDate data)
    {
        Id = data.id;
        Age = data.nianling;
        Sex = (AvatarSexType)data.sex;
        Level = (AvatarLevelType)data.level;
        LiuPai = data.LiuPai;
        Aptitude = data.zizhi;
        Perception = data.wuxing;
        XingGe = data.XingGe;
        Title = data.ChengHao;
        Tag = data.NPCTag;
        ZhuJiTime = data.ZhuJiTime;
        JinDanTime = data.JinDanTime;
        YuanYingTime = data.YuanYingTime;
        HuaShenTime = data.HuaShengTime;
        IsDaShiXiong = data.DaShiXiong == 1;
        IsZhangLao = data.ZhangLao == 1;
        IsZhangMen = data.ZhangMeng == 1;
        EventValue = data.EventValue;
        FuHao = data.fuhao;
    }

    #endregion

    #region 公开方法

    public JSONObject ToJsonObject()
    {
        var data = JSONObject.Create();
        data.AddField("id", Id);
        data.AddField("nianling", Age);
        data.AddField("sex", (int)Sex);
        data.AddField("level", (int)Level);
        data.AddField("LiuPai", LiuPai);
        data.AddField("zizhi", Aptitude);
        data.AddField("wuxing", Perception);
        data.AddField("XingGe", XingGe);
        data.AddField("ChengHao", Title);
        data.AddField("NPCTag", Tag);
        data.AddField("ZhuJiTime", ZhuJiTime);
        data.AddField("JinDanTime", JinDanTime);
        data.AddField("YuanYingTime", YuanYingTime);
        data.AddField("HuaShengTime", HuaShenTime);
        data.AddField("DaShiXiong", IsDaShiXiong ? 1 : 0);
        data.AddField("ZhangLao", IsZhangLao ? 1 : 0);
        data.AddField("ZhangMeng", IsZhangMen ? 1 : 0);
        data.AddField("EventValue", EventValue.ToJsonObject());
        data.AddField("fuhao", FuHao);
        return data;
    }

    #endregion
}