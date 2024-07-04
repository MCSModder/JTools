using System;
using System.Collections.Generic;
using System.Linq;
using JSONClass;
using TierneyJohn.MiChangSheng.JTools.Model.Enum;
using TierneyJohn.MiChangSheng.JTools.Model.Enum.Avatar;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools.Model.Entity;

/// <summary>
/// NPC 流派数据实体类
/// </summary>
[Serializable]
public class NpcLiuPaiEntity
{
    #region 字段属性

    /// <summary>
    /// 数据编号
    /// </summary>
    public virtual int Id { get; set; }

    /// <summary>
    /// 流派 NPC 类型
    /// </summary>
    public virtual int Type { get; set; }

    /// <summary>
    /// 流派编号
    /// </summary>
    public virtual int LiuPai { get; set; }

    /// <summary>
    /// 所属势力
    /// </summary>
    public virtual SectType Sect { get; set; }

    /// <summary>
    /// 对应种族
    /// </summary>
    public virtual AvatarType AvatarType { get; set; }

    /// <summary>
    /// 所属 NPC 境界
    /// </summary>
    public virtual int Level { get; set; }

    /// <summary>
    /// 绑定神通列表
    /// </summary>
    public virtual List<int> Skills { get; set; }

    /// <summary>
    /// 绑定功法列表
    /// </summary>
    public virtual List<int> StaticSkills { get; set; }

    /// <summary>
    /// 绑定灵根列表
    /// </summary>
    public virtual Dictionary<ReikiType, int> Reiki { get; set; }

    /// <summary>
    /// 悟道类型
    /// </summary>
    public virtual int WuDaoType { get; set; }

    /// <summary>
    /// NPC 标签
    /// </summary>
    public virtual List<int> Tags { get; set; }

    /// <summary>
    /// 元婴功法
    /// </summary>
    public virtual int YuanYingSkill { get; set; }

    /// <summary>
    /// 化神领域
    /// </summary>
    public virtual int HuaShenLingYu { get; set; }

    /// <summary>
    /// 是否参加拍卖
    /// </summary>
    public virtual bool ToAuctions { get; set; }

    /// <summary>
    /// 参加拍卖类型组
    /// </summary>
    public virtual List<int> AuctionsType { get; set; }

    /// <summary>
    /// 兴趣类型
    /// </summary>
    public virtual int XingQuType { get; set; }

    /// <summary>
    /// 偏好武器类型
    /// </summary>
    public virtual List<int> EquipWeapon { get; set; }

    /// <summary>
    /// 偏好防具类型
    /// </summary>
    public virtual List<int> EquipArmor { get; set; }

    /// <summary>
    /// 偏好饰品类型
    /// </summary>
    public virtual List<int> EquipOrnament { get; set; }

    /// <summary>
    /// 金丹类型
    /// </summary>
    public virtual List<int> JinDanType { get; set; }

    /// <summary>
    /// 统一姓氏
    /// </summary>
    public virtual string FirstName { get; set; }

    /// <summary>
    /// 实力区间
    /// 两个值
    /// </summary>
    public virtual List<int> ShiLi { get; set; }

    /// <summary>
    /// 攻击类型
    /// </summary>
    public virtual int AttackType { get; set; }

    /// <summary>
    /// 防御类型
    /// </summary>
    public virtual int DefenseType { get; set; }

    #endregion

    #region 构造方法

    public void Create(NPCLeiXingDate data)
    {
        Id = data.id;
        Type = data.Type;
        LiuPai = data.LiuPai;
        Sect = (SectType)data.MengPai;
        AvatarType = (AvatarType)data.AvatarType;
        Level = data.Level;
        Skills = data.skills;
        StaticSkills = data.staticSkills;

        Reiki = new Dictionary<ReikiType, int>
        {
            { ReikiType.金, data.LingGen[0] },
            { ReikiType.木, data.LingGen[1] },
            { ReikiType.水, data.LingGen[2] },
            { ReikiType.火, data.LingGen[3] },
            { ReikiType.土, data.LingGen[4] }
        };

        WuDaoType = data.wudaoType;
        Tags = data.NPCTag;
        YuanYingSkill = data.yuanying;
        HuaShenLingYu = data.HuaShenLingYu;
        ToAuctions = data.canjiaPaiMai == 1;
        AuctionsType = data.paimaifenzu;
        XingQuType = data.XinQuType;
        EquipWeapon = data.equipWeapon;
        EquipArmor = data.equipClothing;
        EquipOrnament = data.equipRing;
        JinDanType = data.JinDanType;
        FirstName = data.FirstName;
        ShiLi = data.ShiLi;
        AttackType = data.AttackType;
        DefenseType = data.DefenseType;
    }

    #endregion

    #region 公开方法

    public JSONObject ToJsonObject()
    {
        var data = JSONObject.Create();
        data.AddField("id", Id);
        data.AddField("Type", Type);
        data.AddField("LiuPai", LiuPai);
        data.AddField("MengPai", (int)Sect);
        data.AddField("Level", Level);
        data.AddField("skills", Skills.ToJsonObject());
        data.AddField("staticSkills", StaticSkills.ToJsonObject());
        data.AddField("yuanying", YuanYingSkill);
        data.AddField("HuaShenLingYu", HuaShenLingYu);
        data.AddField("LingGen", Reiki.Values.ToList().ToJsonObject());
        data.AddField("wudaoType", WuDaoType);
        data.AddField("NPCTag", Tags.ToJsonObject());
        data.AddField("canjiaPaiMai", ToAuctions ? 0 : 1);
        data.AddField("paimaifenzu", AuctionsType.ToJsonObject());
        data.AddField("AvatarType", (int)AvatarType);
        data.AddField("XinQuType", XingQuType);
        data.AddField("equipWeapon", EquipWeapon.ToJsonObject());
        data.AddField("equipClothing", EquipArmor.ToJsonObject());
        data.AddField("equipRing", EquipOrnament.ToJsonObject());
        data.AddField("JinDanType", JinDanType.ToJsonObject());
        data.AddField("FirstName", FirstName);
        data.AddField("ShiLi", ShiLi.ToJsonObject());
        data.AddField("AttackType", AttackType);
        data.AddField("DefenseType", DefenseType);
        return data;
    }

    #endregion
}