using System;
using Newtonsoft.Json;

namespace TierneyJohn.MiChangSheng.JTools.Model.Spine;

/// <summary>
/// Spine 配置文件模板
/// </summary>
[JsonObject]
[Serializable]
public class SpineConfig
{
    #region 字段/属性

    /// <summary>
    /// 角色皮肤名称
    /// </summary>
    [JsonProperty("Skin")]
    public string skin;

    /// <summary>
    /// 角色对话框配置
    /// </summary>
    [JsonProperty("SayDialog")]
    public SpineConfigItem sayDialog;

    /// <summary>
    /// 交互界面配置
    /// </summary>
    [JsonProperty("Pop")]
    public SpineConfigItem pop;

    /// <summary>
    /// 详情界面配置
    /// </summary>
    [JsonProperty("Info")]
    public SpineConfigItem info;

    /// <summary>
    /// 交易背包界面配置
    /// </summary>
    [JsonProperty("Shop")]
    public SpineConfigItem shop;

    /// <summary>
    /// 拍卖界面配置
    /// </summary>
    [JsonProperty("Auction")]
    public SpineConfigItem auction;

    /// <summary>
    /// 左侧面板配置
    /// </summary>
    [JsonProperty("Left")]
    public SpineConfigItem left;

    /// <summary>
    /// 论道面板配置
    /// </summary>
    [JsonProperty("Tao")]
    public SpineConfigItem tao;

    /// <summary>
    /// 战斗准备界面配置
    /// </summary>
    [JsonProperty("FightPop")]
    public SpineConfigItem fightPop;

    /// <summary>
    /// 战斗界面配置
    /// </summary>
    [JsonProperty("Fight")]
    public SpineConfigItem fight;

    #endregion

    #region 重构方法

    public override string ToString() => JsonConvert.SerializeObject(this, Formatting.None);

    #endregion
}