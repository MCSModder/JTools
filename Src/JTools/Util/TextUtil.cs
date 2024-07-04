namespace TierneyJohn.MiChangSheng.JTools.Util;

/// <summary>Text 文本显示工具类</summary>
public static class TextUtil
{
    /// <summary>返回 Title 特殊文本</summary>
    /// <param name="text">文本信息</param>
    /// <returns>格式化后文本</returns>
    public static string Title(this string text) { return $"<Title>{text}</Title>"; }

    /// <summary>返回 Image 特殊文本</summary>
    /// <param name="text">文本信息</param>
    /// <returns>格式化后文本</returns>
    public static string Image(this string text) { return $"<Image>{text}</Image>"; }

    /// <summary>显示红色特殊文本</summary>
    /// <param name="text">文本信息</param>
    /// <returns>格式化后文本</returns>
    public static string Red(this string text) { return $"<color=#bd3c3c>【{text}】</color>"; }

    /// <summary>显示红色特殊文本 适配 JFungus 文本</summary>
    /// <param name="text">文本信息</param>
    /// <returns>格式化后文本</returns>
    public static string JRed(this string text) { return $"{{color=#bd3c3c}}{text}{{/color}}"; }

    /// <summary>显示蓝色特殊文本</summary>
    /// <param name="text">文本信息</param>
    /// <returns>格式化后文本</returns>
    public static string Blue(this string text) { return $"<color=#4169E1>【{text}】</color>"; }

    /// <summary>显示蓝色特殊文本 适配 JFungus 文本</summary>
    /// <param name="text">文本信息</param>
    /// <returns>格式化后文本</returns>
    public static string JBlue(this string text) { return $"{{color=#4169E1}}{text}{{/color}}"; }

    /// <summary>显示绿色特殊文本</summary>
    /// <param name="text">文本信息</param>
    /// <returns>格式化后文本</returns>
    public static string Green(this string text) { return $"<color=#008800>【{text}】</color>"; }

    /// <summary>显示绿色特殊文本 适配 JFungus 文本</summary>
    /// <param name="text">文本信息</param>
    /// <returns>格式化后文本</returns>
    public static string JGreen(this string text) { return $"{{color=#008800}}{text}{{/color}}"; }

    /// <summary>屏幕抖动 适配 JFungus 文本</summary>
    /// <param name="text">文本信息</param>
    /// <returns>格式化后文本</returns>
    public static string JShaking(this string text) { return $"{{vpunch=10, 0.5}}{text}"; }
}