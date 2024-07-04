namespace TierneyJohn.MiChangSheng.JTools.Util;

/// <summary>
/// 枚举类数据处理增强方法
/// </summary>
public static class EnumUtil
{
    public static int GenEnumIndex<T>(this System.Enum @enum)
    {
        if (@enum is not T) return -1;

        var index = 0;

        foreach (var value in System.Enum.GetValues(typeof(T)))
        {
            if (value.Equals(@enum)) return index;
            index++;
        }

        return -1;
    }

    public static T GetIndexValue<T>(this int index)
    {
        var arr = System.Enum.GetValues(typeof(T));

        if (arr.Length >= index) return default;

        return (T)System.Enum.GetValues(typeof(T)).GetValue(index);
    }
}