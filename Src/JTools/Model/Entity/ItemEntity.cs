using System;
using System.Collections.Generic;
using JSONClass;
using TierneyJohn.MiChangSheng.JTools.Model.Enum.Item;
using TierneyJohn.MiChangSheng.JTools.Model.Enum.Tao;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools.Model.Entity;

/// <summary>物品数据实体类</summary>
[Serializable]
public class ItemEntity
{
    #region 字段属性

    /// <summary>物品编号</summary>
    public virtual int Id { get; set; }

    /// <summary>物品名称</summary>
    public virtual string Name { get; set; }

    /// <summary>物品图标编号</summary>
    public virtual int ItemIconId { get; set; }

    /// <summary>最大堆叠数量</summary>
    public virtual int MaxCount { get; set; }

    /// <summary>物品标签</summary>
    public virtual List<int> Affix { get; set; }

    /// <summary>物品特性</summary>
    public virtual List<int> Seid { get; set; }

    /// <summary>物品类型</summary>
    public virtual Enum.Item.ItemType ItemType { get; set; }

    /// <summary>图鉴类型</summary>
    public virtual IllustratedType IllustratedType { get; set; } = IllustratedType.其他;

    /// <summary>商品投放类型</summary>
    public virtual ShopType ShopType { get; set; } = ShopType.不投放;

    /// <summary>物品等阶</summary>
    public virtual LevelType LevelType { get; set; }

    /// <summary>物品品阶</summary>
    public virtual GradeLevelType GradeLevelType { get; set; }

    /// <summary>物品价格</summary>
    public virtual int Price { get; set; }

    /// <summary>物品信息</summary>
    public virtual string Info { get; set; }

    /// <summary>物品描述</summary>
    public virtual string Desc { get; set; }

    /// <summary>是否为消耗品</summary>
    public virtual bool IsConsumables { get; set; }

    /// <summary>是否为非卖品</summary>
    public virtual bool UnSalable { get; set; }

    /// <summary>刷新时间</summary>
    public virtual int RefreshTime { get; set; }

    #region 书籍类数据

    /// <summary>领悟事件</summary>
    public virtual int LearnTime { get; set; }

    /// <summary>领悟前置</summary>
    public virtual List<(TaoType, TaoLevelType)> Prerequisites { get; set; } = [];

    #endregion

    #region 法宝类数据

    /// <summary>武器类型</summary>
    public virtual string WeaponType { get; set; } = "";

    /// <summary>法宝词缀</summary>
    public virtual List<int> EquipAffix { get; set; } = [];

    #endregion

    #region 材料类数据

    /// <summary>材料五维类型</summary>
    public virtual int Material { get; set; }

    /// <summary>材料属性</summary>
    public virtual int MaterialType { get; set; }

    #endregion

    #region 丹药类数据

    /// <summary>可使用次数</summary>
    public virtual int CanUsedCount { get; set; }

    /// <summary>毒性</summary>
    public virtual int Toxicity { get; set; }

    /// <summary>NPC 是否可以使用</summary>
    public virtual bool NpcCanUsed { get; set; }

    #endregion

    #region 草药类数据

    /// <summary>主要药性</summary>
    public virtual MedicinalPropertyType MainDrug { get; set; }

    /// <summary>辅药药性</summary>
    public virtual MedicinalPropertyType Adjuvant { get; set; }

    /// <summary>药引药性</summary>
    public virtual MedicinalPropertyType DrugPrimer { get; set; }

    #endregion

    #endregion

    #region 构造方法

    public void Create(_ItemJsonData data)
    {
        // 常规数据
        Id = data.id;
        Name = data.name;
        ItemIconId = data.ItemIcon;
        MaxCount = data.maxNum;
        Affix = data.ItemFlag;
        Seid = data.seid;
        ItemType = (Enum.Item.ItemType)data.type;
        IllustratedType = (IllustratedType)data.TuJianType;
        ShopType = (ShopType)data.ShopType;
        LevelType = (LevelType)data.quality;
        GradeLevelType = (GradeLevelType)data.typePinJie;
        Price = data.price;
        Info = data.desc;
        Desc = data.desc2;
        IsConsumables = data.vagueType == 1;
        UnSalable = data.CanSale == 1;
        RefreshTime = data.ShuaXin;

        // 书籍数据
        LearnTime = data.StuTime;

        if (data.wuDao != null && data.wuDao.Count != 0)
            for (var index = 0; index < data.wuDao.Count; index += 2)
            {
                Prerequisites.Add(
                    ((TaoType)data.wuDao[index],
                        (TaoLevelType)System.Enum.GetValues(typeof(TaoLevelType)).GetValue(data.wuDao[index + 1])));
            }

        // 法宝数据
        WeaponType = data.FaBaoType;
        EquipAffix = data.Affix;

        // 材料数据
        Material = data.WuWeiType;
        MaterialType = data.ShuXingType;

        // 丹药数据
        CanUsedCount = data.CanUse;
        Toxicity = data.DanDu;
        NpcCanUsed = data.NPCCanUse == 1;

        // 草药数据
        MainDrug = (MedicinalPropertyType)data.yaoZhi2;
        Adjuvant = (MedicinalPropertyType)data.yaoZhi3;
        DrugPrimer = (MedicinalPropertyType)data.yaoZhi1;
    }

    #endregion

    #region 公开方法

    public JSONObject ToJsonObject()
    {
        var data = JSONObject.Create();
        // 常规数据
        data.AddField("id", Id);
        data.AddField("name", Name);
        data.AddField("ItemIcon", ItemIconId);
        data.AddField("maxNum", MaxCount);
        data.AddField("ItemFlag", Affix.ToJsonObject());
        data.AddField("seid", Seid.ToJsonObject());
        data.AddField("type", (int)ItemType);
        data.AddField("TuJianType", (int)IllustratedType);
        data.AddField("ShopType", (int)ShopType);
        data.AddField("quality", (int)LevelType);
        data.AddField("typePinJie", (int)GradeLevelType);
        data.AddField("price", Price);
        data.AddField("desc", Info);
        data.AddField("desc2", Desc);
        data.AddField("vagueType", IsConsumables ? 1 : 0);
        data.AddField("CanSale", UnSalable ? 1 : 0);
        data.AddField("ShuaXin", RefreshTime);

        // 书籍数据
        data.AddField("StuTime", LearnTime);

        if (Prerequisites != null && Prerequisites.Count != 0)
        {
            var list = JSONObject.arr;

            foreach ((var taoType, var taoLevelType) in Prerequisites)
            {
                list.Add((int)taoType);
                list.Add(Array.IndexOf(System.Enum.GetValues(typeof(TaoLevelType)), taoLevelType));
            }

            data.AddField("wuDao", list);
        }
        else
        {
            data.AddField("wuDao", JSONObject.arr);
        }

        // 法宝数据
        data.AddField("FaBaoType", WeaponType);
        data.AddField("Affix", EquipAffix.ToJsonObject());

        // 材料数据
        data.AddField("WuWeiType", Material);
        data.AddField("ShuXingType", MaterialType);

        // 丹药数据
        data.AddField("CanUse", CanUsedCount);
        data.AddField("DanDu", Toxicity);
        data.AddField("NPCCanUse", NpcCanUsed ? 1 : 0);

        // 草药数据
        data.AddField("yaoZhi2", (int)MainDrug);
        data.AddField("yaoZhi3", (int)Adjuvant);
        data.AddField("yaoZhi1", (int)DrugPrimer);

        return data;
    }

    #endregion
}