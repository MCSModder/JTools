using System;
using Newtonsoft.Json;

namespace TierneyJohn.MiChangSheng.JTools.Model.Spine;

/// <summary>
/// Spine 配置文件通用子项
/// </summary>
[JsonObject]
[Serializable]
public class SpineConfigItem
{
    #region 字段

    /// <summary>
    /// X 坐标偏移量
    /// </summary>
    [JsonProperty("OffsetX")]
    public float offsetX;

    /// <summary>
    /// Y 坐标偏移量
    /// </summary>
    [JsonProperty("OffsetY")]
    public float offsetY;

    /// <summary>
    /// 缩放倍率
    /// </summary>
    [JsonProperty("Scale")]
    public float scale = 1f;

    #endregion

    #region 重构方法

    public override string ToString() => JsonConvert.SerializeObject(this, Formatting.None);

    #endregion
}