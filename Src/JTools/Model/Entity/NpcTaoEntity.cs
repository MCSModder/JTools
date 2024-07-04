using System;
using System.Collections.Generic;
using JSONClass;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools.Model.Entity;

/// <summary>
/// NPC 悟道类型数据实体类
/// </summary>
[Serializable]
public class NpcTaoEntity
{
    #region 字段属性

    /// <summary>
    /// 悟道类型编号
    /// </summary>
    public virtual int Id { get; set; }

    /// <summary>
    /// 悟道类型
    /// </summary>
    public virtual int Type { get; set; }

    /// <summary>
    /// 对应境界
    /// </summary>
    public virtual int Level { get; set; }

    /// <summary>
    /// 领悟悟道技能列表
    /// </summary>
    public virtual List<int> TaoSkills { get; set; }

    /// <summary>
    /// 悟道点使用情况
    /// </summary>
    public virtual List<int> TaoPoints { get; set; }

    #endregion

    #region 构造方法

    public void Create(NPCWuDaoJson data)
    {
        Id = data.id;
        Type = data.Type;
        Level = data.lv;
        TaoSkills = data.wudaoID;

        TaoPoints =
        [
            data.value1,
            data.value2,
            data.value3,
            data.value4,
            data.value5,
            data.value6,
            data.value7,
            data.value8,
            data.value9,
            data.value10,
            data.value11,
            data.value12
        ];
    }

    #endregion

    #region 公开方法

    public JSONObject ToJsonObject()
    {
        var data = JSONObject.Create();
        data.AddField("id", Id);
        data.AddField("Type", Type);
        data.AddField("lv", Level);
        data.AddField("wudaoID", TaoSkills.ToJsonObject());

        TaoPoints ??= [];

        for (var index = 1; index <= 12; index++)
        {
            data.AddField($"value{index}", index <= TaoPoints.Count ? TaoPoints[index - 1] : 0);
        }

        return data;
    }

    #endregion
}