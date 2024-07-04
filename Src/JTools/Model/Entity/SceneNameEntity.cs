using System;
using JSONClass;
using TierneyJohn.MiChangSheng.JTools.Model.Enum.Map;

namespace TierneyJohn.MiChangSheng.JTools.Model.Entity;

/// <summary>场景名称数据实体类</summary>
[Serializable]
public class SceneNameEntity
{
    #region 字段属性

    /// <summary>场景编号</summary>
    public virtual string Id { get; set; }

    /// <summary>场景名称</summary>
    public virtual string Name { get; set; }

    /// <summary>场景类型</summary>
    public virtual SceneType SceneType { get; set; } = SceneType.大地图;

    /// <summary>场景售卖价格类型</summary>
    public virtual SceneSellType SellType { get; set; } = SceneSellType.宁州;

    /// <summary>高亮节点编号</summary>
    public virtual int HighLightId { get; set; }

    /// <summary>外部场景名称</summary>
    public virtual string OutSideSceneName { get; set; } = "";

    /// <summary>对应海域坐标</summary>
    public virtual int OutSideScenePosition { get; set; }

    #endregion

    #region 构造方法

    public void Create(SceneNameJsonData data)
    {
        Id = data.id;
        Name = data.EventName;
        SceneType = (SceneType)data.MapType;
        SellType = (SceneSellType)data.MoneyType;
        HighLightId = data.HighlightID;
        OutSideSceneName = data.OutsideSceneName;
        OutSideScenePosition = data.OutsideScenePos;
    }

    #endregion

    #region 公开方法

    public JSONObject ToJsonObject()
    {
        var data = JSONObject.Create();
        data.SetField("id", Id);
        data.SetField("EventName", Name);
        data.SetField("MapType", (int)SceneType);
        data.SetField("MoneyType", (int)SellType);
        data.SetField("MapName", Name);
        data.SetField("HighlightID", HighLightId);
        data.SetField("OutsideSceneName", OutSideSceneName);
        data.SetField("OutsideScenePos", OutSideScenePosition);
        return data;
    }

    #endregion
}