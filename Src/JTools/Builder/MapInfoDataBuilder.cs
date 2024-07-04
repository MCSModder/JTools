using System;
using System.Collections.Generic;
using System.IO;
using TierneyJohn.MiChangSheng.JTools.Manager;
using TierneyJohn.MiChangSheng.JTools.Model.Map;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools.Builder;

/// <summary>
/// 地图数据构造器
/// </summary>
public class MapInfoDataBuilder
{
    #region 字段属性

    private string _path;

    private readonly Dictionary<string, MapInfo> _mapInfos = [];

    #endregion

    #region Builder 方法

    public MapInfoDataBuilder Add(MapInfo data)
    {
        _mapInfos.TryAdd(data.Id, data);
        return this;
    }

    public MapInfoDataBuilder SetBuildPath(Type mainClass, string path = "Data")
    {
        _path = $"{Directory.GetParent(mainClass.Assembly.Location)?.FullName}/{path}";
        return this;
    }

    public Dictionary<string, MapInfo> GetData() { return _mapInfos; }

    public void Build() { DataManager.MapInfoData.Archive(_path, _mapInfos); }

    public void Load()
    {
        foreach (var item in _mapInfos)
        {
            DataManager.Inst.MapInfos.TryAdd(item.Key, item.Value);
        }
    }

    #endregion
}