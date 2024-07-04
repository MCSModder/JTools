using System;
using System.Collections.Generic;
using System.Linq;
using JSONClass;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools.Model.Entity;

/// <summary>
/// NPC 生成数据实体类
/// </summary>
[Serializable]
public class NpcSpawnEntity
{
    #region 字段属性

    /// <summary>
    /// NPC 生成数据编号
    /// </summary>
    public virtual int Id { get; set; }

    /// <summary>
    /// NPC 流派编号
    /// </summary>
    public virtual int LiuPai { get; set; }

    /// <summary>
    /// NPC 生成数据
    /// </summary>
    public virtual List<(int, int)> Spawn { get; set; }

    #endregion

    #region 构造方法

    public void Create(NPCChuShiHuaDate data)
    {
        Id = data.id;
        LiuPai = data.LiuPai;
        Spawn = data.Level.Zip(data.Num, (item1, item2) => (item1, item2)).ToList();
    }

    #endregion

    #region 公开方法

    public JSONObject ToJsonObject()
    {
        var data = JSONObject.Create();
        data.AddField("id", Id);
        data.AddField("LiuPai", LiuPai);
        data.AddField("Level", Spawn.Select(item => item.Item1).ToList().ToJsonObject());
        data.AddField("Num", Spawn.Select(item => item.Item2).ToList().ToJsonObject());
        return data;
    }

    #endregion
}