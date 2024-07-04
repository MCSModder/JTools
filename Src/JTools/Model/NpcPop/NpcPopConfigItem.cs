using System;
using Newtonsoft.Json;

namespace TierneyJohn.MiChangSheng.JTools.Model.NpcPop;

/// <summary>
/// Npc 交谈界面子配置
/// </summary>
[JsonObject]
[Serializable]
public class NpcPopConfigItem
{
    [JsonProperty("ConfigId")]
    public int configId;

    [JsonProperty("Activated")]
    public bool activated;

    [JsonProperty("交谈")]
    public bool 交谈 = true;

    [JsonProperty("论道")]
    public bool 论道 = true;

    [JsonProperty("交易")]
    public bool 交易 = true;

    [JsonProperty("切磋")]
    public bool 切磋 = true;

    [JsonProperty("赠礼")]
    public bool 赠礼 = true;

    [JsonProperty("请教")]
    public bool 请教 = true;

    [JsonProperty("查看")]
    public bool 查看 = true;

    [JsonProperty("探查")]
    public bool 探查 = true;

    [JsonProperty("威胁")]
    public bool 威胁 = true;

    [JsonProperty("截杀")]
    public bool 截杀 = true;
}