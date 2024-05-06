using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TierneyJohn.MiChangSheng.JTools.Exception.ArchiveException;

namespace TierneyJohn.MiChangSheng.JTools.Util;

/// <summary>
/// 数据存读档工具类
/// </summary>
public static class ArchiveUtil
{
    /// <summary>
    /// 数据归档方法
    /// </summary>
    /// <param name="fileName">归档文件名称</param>
    /// <param name="path">归档文件路径</param>
    /// <param name="data">归档数据</param>
    /// <typeparam name="T">归档数据类型</typeparam>
    /// <returns>归档结果</returns>
    public static bool Archive<T>(this string fileName, string path, T data)
    {
        var archivePath = $"{path}/{fileName}";
        var dir = archivePath.Substring(0, archivePath.LastIndexOf("/", StringComparison.Ordinal));
        var name = archivePath.Substring(archivePath.LastIndexOf("/", StringComparison.Ordinal) + 1);
        if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

        if (!File.Exists(archivePath)) name.SaveWarn("文件不存在，正在重新创建该文件");

        var fileStream = new FileStream(archivePath, FileMode.Create, FileAccess.Write);
        var binaryFormatter = new BinaryFormatter();

        try
        {
            binaryFormatter.Serialize(fileStream, data);
            name.SaveInfo();
            return true;
        }
        catch (System.Exception e)
        {
            e.Error();
            return false;
        }
        finally
        {
            fileStream.Flush();
            fileStream.Close();
        }
    }

    /// <summary>
    /// 数据归档方法
    /// </summary>
    /// <param name="fileName">归档文件名称</param>
    /// <param name="data">归档数据</param>
    /// <typeparam name="T">归档数据类型</typeparam>
    /// <returns>归档结果</returns>
    public static bool Archive<T>(this string fileName, T data)
    {
        return Archive(fileName, GetArchivePath(), data);
    }

    /// <summary>
    /// 获取归档文件数据方法
    /// </summary>
    /// <param name="fileName">归档文件名称</param>
    /// <param name="path">归档文件路径</param>
    /// <typeparam name="T">归档数据类型</typeparam>
    /// <returns>归档数据</returns>
    /// <exception cref="ArchiveFileNotExistException">文件不存在异常</exception>
    public static T GetArchive<T>(this string fileName, string path) where T : class
    {
        var archivePath = $"{path}/{fileName}";

        if (!File.Exists(archivePath))
        {
            throw new ArchiveFileNotExistException(fileName);
        }

        var fileStream = new FileStream(archivePath, FileMode.Open, FileAccess.Read);
        var binaryFormatter = new BinaryFormatter();

        try
        {
            var result = binaryFormatter.Deserialize(fileStream) as T;
            fileName.LoadInfo();
            return result;
        }
        catch (System.Exception e)
        {
            e.Error();
            return default;
        }
        finally
        {
            fileStream.Flush();
            fileStream.Close();
        }
    }

    /// <summary>
    /// 获取归档文件数据方法
    /// </summary>
    /// <param name="fileName">归档文件名称</param>
    /// <typeparam name="T">归档数据类型</typeparam>
    /// <returns>归档数据</returns>
    /// <exception cref="ArchiveFileNotExistException">文件不存在异常</exception>
    public static T GetArchive<T>(this string fileName) where T : class
    {
        return GetArchive<T>(fileName, GetArchivePath());
    }

    /// <summary>
    /// 获取归档文件数据方法
    /// </summary>
    /// <param name="fileName">归档文件名称</param>
    /// <param name="path">归档文件路径</param>
    /// <param name="value">归档数据存放对象</param>
    /// <typeparam name="T">归档数据类型</typeparam>
    /// <returns>归档数据获取结果</returns>
    public static bool TryGetArchive<T>(this string fileName, string path, out T value) where T : class
    {
        try
        {
            value = GetArchive<T>(fileName, path);
            return value != default;
        }
        catch (ArchiveException e)
        {
            value = default;
            fileName.LoadWarn(e.Message);
            return false;
        }
    }

    /// <summary>
    /// 获取归档文件数据方法
    /// </summary>
    /// <param name="fileName">归档文件名称</param>
    /// <param name="value">归档数据存放对象</param>
    /// <typeparam name="T">归档数据类型</typeparam>
    /// <returns>归档数据获取结果</returns>
    public static bool TryGetArchive<T>(this string fileName, out T value) where T : class
    {
        try
        {
            value = GetArchive<T>(fileName);
            return value != default;
        }
        catch (ArchiveException e)
        {
            value = default;
            fileName.LoadWarn(e.Message);
            return false;
        }
    }

    /// <summary>
    /// 获取归档文件数据方法 (对于List类型归档数据的增强处理)
    /// </summary>
    /// <param name="fileName">归档文件名称</param>
    /// <param name="path">归档文件路径</param>
    /// <param name="value">归档数据存放对象</param>
    /// <typeparam name="T">归档数据类型</typeparam>
    /// <returns>归档数据获取结果</returns>
    public static bool TryGetArchive<T>(this string fileName, string path, out List<T> value)
    {
        try
        {
            value = GetArchive<List<T>>(fileName, path);
            return value != default;
        }
        catch (ArchiveException e)
        {
            value = default;
            fileName.LoadWarn(e.Message);
            return false;
        }
    }

    /// <summary>
    /// 获取归档文件数据方法 (对于List类型归档数据的增强处理)
    /// </summary>
    /// <param name="fileName">归档文件名称</param>
    /// <param name="value">归档数据存放对象</param>
    /// <typeparam name="T">归档数据类型</typeparam>
    /// <returns>归档数据获取结果</returns>
    public static bool TryGetArchive<T>(this string fileName, out List<T> value)
    {
        try
        {
            value = GetArchive<List<T>>(fileName);
            return value != default;
        }
        catch (ArchiveException e)
        {
            value = default;
            fileName.LoadWarn(e.Message);
            return false;
        }
    }

    /// <summary>
    /// 根据文件名称，获取当前游戏存档的文件路径
    /// </summary>
    public static string GetArchivePath()
    {
        return $"{Paths.GetNewSavePath()}/{YSNewSaveSystem.NowAvatarPathPre}";
    }

    /// <summary>
    /// 根据文件名称，获取当前游戏存档的文件路径 (基于这个文件名本身的路径)
    /// </summary>
    /// <param name="fileName">归档文件名称</param>
    /// <returns>完整文件路径</returns>
    public static string GetArchivePath(this string fileName)
    {
        return $"{GetArchivePath()}/{fileName}";
    }

    /// <summary>
    /// 根据文件名称，获取指定存档编号的文件路径 (基于这个文件名本身的路径)
    /// </summary>
    /// <param name="fileName">归档文件名称</param>
    /// <param name="index">Avatar 存档编号</param>
    /// <returns>完整文件路径</returns>
    public static string GetArchiveParentPath(this string fileName, int index)
    {
        return $"{Paths.GetNewSavePath()}/Avatar{index}/{fileName}";
    }
}