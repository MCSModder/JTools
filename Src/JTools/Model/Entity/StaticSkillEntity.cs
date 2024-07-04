using System;
using System.Collections.Generic;
using JSONClass;
using TierneyJohn.MiChangSheng.JTools.Model.Enum.Item;
using TierneyJohn.MiChangSheng.JTools.Model.Enum.Skill;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools.Model.Entity;

/// <summary>功法数据实体类</summary>
[Serializable]
public class StaticSkillEntity
{
    #region 字段属性

    /// <summary>功法编号</summary>
    public virtual int Id { get; set; }

    /// <summary>功法唯一编号</summary>
    public virtual int SkillId { get; set; }

    /// <summary>功法等级</summary>
    public virtual int Level { get; set; }

    /// <summary>功法名称</summary>
    public virtual string Name { get; set; }

    /// <summary>功法图标编号</summary>
    public virtual int SkillIconId { get; set; }

    /// <summary>功法词缀</summary>
    public virtual List<int> Affix { get; set; }

    /// <summary>功法特性</summary>
    public virtual List<int> Seid { get; set; }

    /// <summary>功法请教类型</summary>
    public virtual SkillAskType AskType { get; set; }

    /// <summary>功法类型</summary>
    public virtual StaticSkillType SkillType { get; set; }

    /// <summary>功法等阶</summary>
    public virtual LevelType LevelType { get; set; }

    /// <summary>功法品阶</summary>
    public virtual GradeLevelType GradeLevelType { get; set; }

    /// <summary>功法领悟时长</summary>
    public virtual int LearnTime { get; set; }

    /// <summary>功法修炼速度</summary>
    public virtual SkillSpeedType SkillSpeed { get; set; }

    /// <summary>功法图鉴类型</summary>
    public virtual IllustratedType IllustratedType { get; set; } = IllustratedType.功法;

    /// <summary>斗法是否可用</summary>
    public virtual bool CanDF { get; set; } = true;

    /// <summary>功法信息</summary>
    public virtual string Info { get; set; }

    /// <summary>功法描述</summary>
    public virtual string Desc { get; set; }

    #endregion

    #region 构造方法

    public void Create(StaticSkillJsonData data)
    {
        Id = data.id;
        SkillId = data.Skill_ID;
        Level = data.Skill_Lv;
        Name = data.name;
        SkillIconId = data.icon;
        Affix = data.Affix;
        Seid = data.seid;
        AskType = (SkillAskType)data.qingjiaotype;
        SkillType = (StaticSkillType)data.AttackType;
        LevelType = (LevelType)data.Skill_LV;
        GradeLevelType = (GradeLevelType)data.typePinJie;
        LearnTime = data.Skill_castTime;
        SkillSpeed = SkillSpeedType.未知;
        IllustratedType = (IllustratedType)data.TuJianType;
        CanDF = data.DF == 1;
        Info = data.descr;
        Desc = data.TuJiandescr;
    }

    #endregion

    #region 公开方法

    public JSONObject ToJsonObject()
    {
        var data = JSONObject.Create();
        data.AddField("id", Id);
        data.AddField("Skill_ID", SkillId);
        data.AddField("Skill_Lv", Level);
        data.AddField("name", Name);
        data.AddField("icon", SkillIconId);
        data.AddField("Affix", Affix.ToJsonObject());
        data.AddField("seid", Seid.ToJsonObject());
        data.AddField("qingjiaotype", (int)AskType);
        data.AddField("AttackType", (int)SkillType);
        data.AddField("Skill_LV", (int)LevelType);
        data.AddField("typePinJie", (int)GradeLevelType);
        data.AddField("Skill_castTime", LearnTime == 0 ? GetLearnTime() : LearnTime);
        data.AddField("Skill_Speed", GetSkillSpeed());
        data.AddField("TuJianType", (int)IllustratedType);
        data.AddField("DF", CanDF ? 1 : 0);
        data.AddField("descr", Info);
        data.AddField("TuJiandescr", Desc);
        return data;
    }

    public int GetLearnTime()
    {
        if (Level == 1) return 1;

        var time = 1;

        switch (LevelType)
        {
            case LevelType.一品 when GradeLevelType == GradeLevelType.下品:
                time = 2;
                return time << Level - 1;

            case LevelType.一品 when GradeLevelType == GradeLevelType.中品:
                time = 3;
                return time << Level - 1;

            case LevelType.一品 when GradeLevelType == GradeLevelType.上品:
                time = 4;
                return time << Level - 1;

            case LevelType.二品:
                time = 12;
                break;

            case LevelType.三品:
                time = 48;
                break;
        }

        return GradeLevelType switch
        {
            GradeLevelType.下品 => time << Level - 1,
            GradeLevelType.中品 => (int)(time * 1.25) << Level - 1,
            GradeLevelType.上品 => (int)(time * 1.25 * 1.25) << Level - 1,
            _ => 1
        };
    }

    public int GetSkillSpeed()
    {
        if (SkillSpeed == SkillSpeedType.遁术) return 0;

        if (SkillSpeed == SkillSpeedType.未知)
        {
            if (StaticSkillJsonData.DataDict.TryGetValue(Id, out var value)) return value.Skill_Speed;

            return 100 * Level;
        }

        double speed = LevelType switch
        {
            LevelType.一品 => 100,
            LevelType.二品 => 300,
            LevelType.三品 => 900,
            _ => 100
        };

        switch (GradeLevelType)
        {
            case GradeLevelType.下品:
                speed *= 0.8;
                break;

            case GradeLevelType.上品:
                speed *= 1.2;
                break;
        }

        speed = speed * Level / 10 * (int)SkillSpeed;

        return (int)speed;
    }

    #endregion
}