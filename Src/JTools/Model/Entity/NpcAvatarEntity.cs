using System;
using System.Collections.Generic;
using System.Linq;
using TierneyJohn.MiChangSheng.JTools.Model.Enum;
using TierneyJohn.MiChangSheng.JTools.Model.Enum.Avatar;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools.Model.Entity;

/// <summary>角色数据实体类</summary>
[Serializable]
public class NpcAvatarEntity
{
    #region 字段属性

    /// <summary>角色编号 (唯一) 无需考虑原版的固定 Id 以及实例 Id</summary>
    public virtual int Id { get; set; }

    /// <summary>角色姓氏 允许为空，此时只读取角色名称</summary>
    public virtual string Surname { get; set; }

    /// <summary>当姓氏存在时，只保存名 当姓氏不存在时，此字段保存完整名称</summary>
    public virtual string Name
    {
        get => string.IsNullOrEmpty(Surname) ? _name : $"{Surname}{_name}";
        set => _name = value;
    }

    private string _name;

    /// <summary>角色称号</summary>
    public virtual string Title { get; set; }

    /// <summary>角色脸型</summary>
    public virtual int Face { get; set; }

    /// <summary>角色战斗立绘</summary>
    public virtual int FightFace { get; set; }

    /// <summary>角色类型</summary>
    public virtual AvatarType AvatarType { get; set; } = AvatarType.人;

    /// <summary>角色性别</summary>
    public virtual AvatarSexType Sex { get; set; } = AvatarSexType.男;

    /// <summary>角色年龄</summary>
    public virtual int Age { get; set; }

    /// <summary>角色剩余寿命</summary>
    public virtual int LifeSpan { get; set; }

    /// <summary>角色资质</summary>
    public virtual int Aptitude { get; set; } = 1;

    /// <summary>角色悟性</summary>
    public virtual int Perception { get; set; } = 1;

    /// <summary>角色灵巧</summary>
    public virtual int Agile { get; set; } = 1;

    /// <summary>角色当前血量</summary>
    public virtual int Hp { get; set; } = 1;

    /// <summary>角色神识</summary>
    public virtual int Spirit { get; set; } = 1;

    /// <summary>角色等级境界</summary>
    public virtual AvatarLevelType Level { get; set; } = AvatarLevelType.炼气初期;

    /// <summary>角色杀气</summary>
    public virtual int Murderous { get; set; }

    /// <summary>角色门派</summary>
    public virtual SectType Sect { get; set; } = SectType.散修;

    /// <summary>角色灵根</summary>
    public virtual Dictionary<ReikiType, int> Reiki { get; set; } = new();

    /// <summary>角色装备神通</summary>
    public virtual List<int> UsedSkills { get; set; } = [];

    /// <summary>角色装备功法</summary>
    public virtual List<int> UsedStaticSkills { get; set; } = [];

    /// <summary>角色装备元婴功法</summary>
    public virtual int UsedYuanYingStaticSkill { get; set; }

    /// <summary>角色装备化神领域</summary>
    public virtual int UsedHuaShenLingYu { get; set; }

    /// <summary>角色装备武器</summary>
    public virtual int EquipWeapon { get; set; }

    /// <summary>角色装备防具</summary>
    public virtual int EquipArmor { get; set; }

    /// <summary>角色装备饰品</summary>
    public virtual int EquipOrnament { get; set; }

    /// <summary>经济状况</summary>
    public virtual AvatarMoneyType MoneyType { get; set; }

    /// <summary>背包是否刷新</summary>
    public virtual bool IsRefresh { get; set; }

    /// <summary>击杀是否掉落背包</summary>
    public virtual bool IsDrop { get; set; }

    /// <summary>是否参加拍卖</summary>
    public virtual bool ToAuctions { get; set; }

    /// <summary>参加拍卖类型组</summary>
    public virtual List<int> AuctionsType { get; set; }

    /// <summary>NPC 悟道类型</summary>
    public virtual int WuDaoType { get; set; }

    /// <summary>NPC 喜好类型</summary>
    public virtual int XingQuType { get; set; }

    /// <summary>是否固定售卖价格</summary>
    public virtual bool GuDingJiaGe { get; set; }

    /// <summary>固定价格出售比率</summary>
    public virtual int SellPercent { get; set; }

    #endregion

    #region 常规公开方法

    public JSONObject ToJsonObject()
    {
        var data = JSONObject.Create();
        data.AddField("id", Id);
        data.AddField("Title", Title);
        data.AddField("FirstName", Surname);
        data.AddField("Name", Name);
        data.AddField("face", Face);
        data.AddField("fightFace", FightFace);
        data.AddField("SexType", (int)Sex);
        data.AddField("AvatarType", (int)AvatarType);
        data.AddField("Level", (int)Level);
        data.AddField("HP", Hp);
        data.AddField("dunSu", Agile);
        data.AddField("ziZhi", Aptitude);
        data.AddField("wuXin", Perception);
        data.AddField("shengShi", Spirit);
        data.AddField("shaQi", Murderous);
        data.AddField("shouYuan", LifeSpan);
        data.AddField("age", Age);
        data.AddField("menPai", (int)Sect > 6 ? 0 : (int)Sect);
        data.AddField("equipWeapon", EquipWeapon);
        data.AddField("equipClothing", EquipArmor);
        data.AddField("equipRing", EquipOrnament);
        data.AddField("LingGen", Reiki.Values.ToList().ToJsonObject());
        data.AddField("skills", UsedSkills.ToJsonObject());
        data.AddField("staticSkills", UsedStaticSkills.ToJsonObject());
        data.AddField("yuanying", UsedYuanYingStaticSkill);
        data.AddField("HuaShenLingYu", UsedHuaShenLingYu);
        data.AddField("MoneyType", MoneyType.GenEnumIndex<AvatarMoneyType>() + 1);
        data.AddField("IsRefresh", IsRefresh ? 1 : 0);
        data.AddField("dropType", IsDrop ? 1 : 0);
        data.AddField("canjiaPaiMai", ToAuctions ? 1 : 0);
        data.AddField("paimaifenzu", ToAuctions ? AuctionsType.ToJsonObject() : JSONObject.arr);
        data.AddField("wudaoType", WuDaoType);
        data.AddField("XinQuType", XingQuType);
        data.AddField("gudingjiage", GuDingJiaGe ? 1 : 0);
        data.AddField("sellPercent", GuDingJiaGe ? SellPercent : 0);
        return data;
    }

    #endregion
}