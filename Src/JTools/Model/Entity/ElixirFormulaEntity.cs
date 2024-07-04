using System;
using JSONClass;

namespace TierneyJohn.MiChangSheng.JTools.Model.Entity;

/// <summary>丹方数据实体类</summary>
[Serializable]
public class ElixirFormulaEntity
{
    #region 字段属性

    /// <summary>丹方编号</summary>
    public virtual int Id { get; set; }

    /// <summary>丹药编号</summary>
    public virtual int ElixirId { get; set; }

    /// <summary>丹方名称</summary>
    public virtual string Name { get; set; }

    /// <summary>炼制时长</summary>
    public virtual int Time { get; set; }

    /// <summary>主药A</summary>
    public virtual (int, int) MainDrugA { get; set; }

    /// <summary>主药B</summary>
    public virtual (int, int) MainDrugB { get; set; }

    /// <summary>辅药A</summary>
    public virtual (int, int) AdjuvantA { get; set; }

    /// <summary>辅药B</summary>
    public virtual (int, int) AdjuvantB { get; set; }

    /// <summary>药引</summary>
    public virtual (int, int) DrugPrimer { get; set; }

    #endregion

    #region 构造方法

    public void Create(LianDanDanFangBiao data)
    {
        Id = data.id;
        ElixirId = data.ItemID;
        Name = data.name;
        Time = data.castTime;
        DrugPrimer = (data.value1, data.num1);
        MainDrugA = (data.value2, data.num2);
        MainDrugB = (data.value3, data.num3);
        AdjuvantA = (data.value4, data.num4);
        AdjuvantB = (data.value5, data.num5);
    }

    #endregion

    #region 公开方法

    public JSONObject ToJsonObject()
    {
        var data = JSONObject.Create();
        data.AddField("id", Id);
        data.AddField("ItemID", ElixirId);
        data.AddField("name", Name);
        data.AddField("value1", DrugPrimer.Item1);
        data.AddField("num1", DrugPrimer.Item2);
        data.AddField("value2", MainDrugA.Item1);
        data.AddField("num2", MainDrugA.Item2);
        data.AddField("value3", MainDrugB.Item1);
        data.AddField("num3", MainDrugB.Item2);
        data.AddField("value4", AdjuvantA.Item1);
        data.AddField("num4", AdjuvantA.Item2);
        data.AddField("value5", AdjuvantB.Item1);
        data.AddField("num5", AdjuvantB.Item2);
        data.AddField("castTime", Time);
        return data;
    }

    #endregion
}