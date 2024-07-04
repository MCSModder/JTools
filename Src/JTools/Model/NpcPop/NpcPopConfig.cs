using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TierneyJohn.MiChangSheng.JTools.Model.NpcPop;

/// <summary>
/// Npc 交互按钮配置
/// </summary>
[JsonObject]
[Serializable]
public class NpcPopConfig
{
    #region 字段/属性

    [JsonProperty("Id")]
    public int id;

    [JsonProperty("Config")]
    public List<NpcPopConfigItem> config;

    #endregion
}