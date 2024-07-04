using System;
using System.Collections.Generic;
using System.IO;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools.Builder;

/// <summary>
/// 数据构造器通用父类
/// </summary>
public abstract class BaseBuilder<T>
{
    #region 字段/属性

    /// <summary>
    /// 数据存放路径
    /// </summary>
    private string _path;

    /// <summary>
    /// 数据集
    /// </summary>
    protected readonly List<T> Data = [];

    #endregion

    #region Builder 方法

    /// <summary>
    /// 添加数据
    /// </summary>
    /// <param name="data">数据对象</param>
    public BaseBuilder<T> Add(T data)
    {
        Data.Add(data);
        return this;
    }

    /// <summary>
    /// 添加数据集
    /// </summary>
    /// <param name="data">数据集</param>
    public BaseBuilder<T> AddRange(IEnumerable<T> data)
    {
        Data.AddRange(data);
        return this;
    }

    /// <summary>
    /// 设置 Build 路径
    /// </summary>
    /// <param name="mainClass">主函数类型</param>
    /// <param name="path">数据存放路径</param>
    public BaseBuilder<T> SetBuildPath(Type mainClass, string path = "Data")
    {
        _path = $"{Directory.GetParent(mainClass.Assembly.Location)?.FullName}/{path}";
        return this;
    }

    /// <summary>
    /// 获取构造数据
    /// </summary>
    /// <returns>数据对象</returns>
    public List<T> GetData() { return Data; }

    /// <summary>
    /// 制作数据包
    /// </summary>
    protected void Build(string fileName) { fileName.Archive(_path, Data); }

    /// <summary>
    /// 制作数据包
    /// </summary>
    public abstract void Build();

    /// <summary>
    /// 数据加载
    /// </summary>
    public abstract void Load();

    #endregion
}