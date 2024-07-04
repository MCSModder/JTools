using System;
using System.Collections.Generic;
using System.Linq;
using JSONClass;
using TierneyJohn.MiChangSheng.JTools.Model.Enum;
using TierneyJohn.MiChangSheng.JTools.Model.Enum.Item;
using TierneyJohn.MiChangSheng.JTools.Model.Enum.Skill;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools.Model.Entity;

/// <summary>神通数据实体类</summary>
[Serializable]
public class SkillEntity
{
    #region 字段属性

    /// <summary>神通编号</summary>
    public virtual int Id { get; set; }

    /// <summary>神通唯一编号</summary>
    public virtual int SkillId { get; set; }

    /// <summary>神通等级</summary>
    public virtual int Level { get; set; }

    /// <summary>神通名称</summary>
    public virtual string Name { get; set; }

    /// <summary>神通图标编号</summary>
    public virtual int SkillIconId { get; set; }

    /// <summary>神通特效</summary>
    public virtual string SkillEffect { get; set; }

    /// <summary>神通释放优先级</summary>
    public virtual int Priority { get; set; }

    /// <summary>神通词缀</summary>
    public virtual List<int> Affix { get; set; } = [];

    /// <summary>神通特性</summary>
    public virtual List<int> Seid { get; set; } = [];

    /// <summary>神通请教类型</summary>
    public virtual SkillAskType AskType { get; set; }

    /// <summary>神通攻击类型</summary>
    public virtual List<SkillAttackType> AttackTypes { get; set; } = [];

    /// <summary>神通攻击目标 (SkillAttack:对敌方,SkillSelf:对自己)</summary>
    public virtual string SkillScript { get; set; } = "SkillAttack";

    /// <summary>神通基础伤害</summary>
    public virtual int Attack { get; set; }

    /// <summary>同系灵气消耗</summary>
    public virtual List<int> SameCast { get; set; } = [];

    /// <summary>灵气消耗</summary>
    public virtual List<(ReikiType, int)> Cast { get; set; } = [];

    /// <summary>神通等阶</summary>
    public virtual LevelType LevelType { get; set; }

    /// <summary>神通品阶</summary>
    public virtual GradeLevelType GradeLevelType { get; set; }

    /// <summary>神通开启境界</summary>
    public virtual int SkillOpen { get; set; }

    /// <summary>神通领悟时长</summary>
    public virtual int LearnTime { get; set; }

    /// <summary>神通图鉴类型</summary>
    public virtual IllustratedType IllustratedType { get; set; } = IllustratedType.神通;

    /// <summary>斗法是否可用</summary>
    public virtual bool CanDF { get; set; } = true;

    /// <summary>神通信息</summary>
    public virtual string Info { get; set; }

    /// <summary>神通描述</summary>
    public virtual string Desc { get; set; }

    /// <summary>神通攻击距离</summary>
    public virtual int CanUseDistMax { get; set; } = 30;

    /// <summary>神通释放冷却</summary>
    public virtual int Cd { get; set; } = 10000;

    #endregion

    #region 构造方法

    public void Create(_skillJsonData data)
    {
        Id = data.id;
        SkillId = data.Skill_ID;
        Level = data.Skill_Lv;
        Priority = data.Skill_Type;
        AskType = (SkillAskType)data.qingjiaotype;
        Attack = data.HP;
        SkillIconId = data.icon;
        LevelType = (LevelType)data.Skill_LV;
        GradeLevelType = (GradeLevelType)data.typePinJie;
        CanDF = data.DF == 1;
        IllustratedType = (IllustratedType)data.TuJianType;
        SkillOpen = data.Skill_Open;
        LearnTime = data.Skill_castTime;
        CanUseDistMax = data.canUseDistMax;
        Cd = data.CD;
        SkillEffect = data.skillEffect;
        Name = data.name;
        Info = data.descr;
        Desc = data.TuJiandescr;
        SkillScript = data.script;
        Seid = data.seid;
        Affix = data.Affix;
        AttackTypes = data.AttackType.Select(item => (SkillAttackType)item).ToList();
        SameCast = data.skill_SameCastNum;
        Cast = data.skill_CastType.Zip(data.skill_Cast, (item1, item2) => ((ReikiType)item1, item2)).ToList();
    }

    #endregion

    #region 公开方法

    public JSONObject ToJsonObject()
    {
        var data = JSONObject.Create();
        data.AddField("id", Id);
        data.AddField("Skill_ID", SkillId);
        data.AddField("Skill_Lv", Level);
        data.AddField("skillEffect", SkillEffect);
        data.AddField("Skill_Type", Priority);
        data.AddField("name", Name);
        data.AddField("qingjiaotype", (int)AskType);
        data.AddField("seid", Seid.ToJsonObject());
        data.AddField("Affix", JSONObject.arr);
        data.AddField("Affix2", Affix.ToJsonObject());
        data.AddField("descr", Info);
        data.AddField("TuJiandescr", Desc);
        data.AddField("AttackType", AttackTypes.Select(item => (int)item).ToList().ToJsonObject());
        data.AddField("script", SkillScript);
        data.AddField("HP", Attack);
        data.AddField("speed", 0);
        data.AddField("icon", SkillIconId);
        data.AddField("Skill_DisplayType", 0);
        data.AddField("skill_SameCastNum", SameCast.ToJsonObject());
        data.AddField("skill_CastType", Cast.Select(item => (int)item.Item1).ToList().ToJsonObject());
        data.AddField("skill_Cast", Cast.Select(item => item.Item2).ToList().ToJsonObject());
        data.AddField("Skill_LV", (int)LevelType);
        data.AddField("typePinJie", (int)GradeLevelType);
        data.AddField("DF", CanDF ? 1 : 0);
        data.AddField("TuJianType", (int)IllustratedType);
        data.AddField("Skill_Open", SkillOpen);
        data.AddField("Skill_castTime", LearnTime);
        data.AddField("canUseDistMax", CanUseDistMax);
        data.AddField("CD", Cd);
        return data;
    }

    #endregion
}