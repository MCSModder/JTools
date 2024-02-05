using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TierneyJohn.MiChangSheng.JTools.Exception.ArchiveException;

namespace TierneyJohn.MiChangSheng.JTools.Util
{
    /// <summary>
    /// 数据存读档工具类
    /// </summary>
    public static class ArchiveUtil
    {
        /// <summary>
        /// 数据归档方法
        /// </summary>
        /// <param name="fileName">归档文件名称</param>
        /// <param name="data">归档数据</param>
        /// <typeparam name="T">归档数据类型</typeparam>
        /// <returns>归档结果</returns>
        public static bool Archive<T>(this string fileName, T data)
        {
            var archivePath = GetArchivePath(fileName);
            var fileStream = new FileStream(archivePath, FileMode.Create, FileAccess.Write);
            var binaryFormatter = new BinaryFormatter();

            if (!File.Exists(archivePath))
            {
                fileName.SaveWarn("文件不存在，已重新创建该文件");
            }

            try
            {
                binaryFormatter.Serialize(fileStream, data);
                fileName.SaveInfo();
                return true;
            }
            catch (System.Exception e)
            {
                fileName.SaveError(e.Message);
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
        /// 获取归档文件数据方法
        /// </summary>
        /// <param name="fileName">归档文件名称</param>
        /// <typeparam name="T">归档数据类型</typeparam>
        /// <returns>归档数据</returns>
        /// <exception cref="ArchiveFileNotExistException">文件不存在异常</exception>
        public static T GetArchive<T>(this string fileName) where T : class
        {
            var archivePath = GetArchivePath(fileName);

            if (!File.Exists(archivePath))
            {
                throw new ArchiveFileNotExistException("The archive file does not exist.");
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
                fileName.LoadError(e.Message);
                e.Error();
                return default;
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
            value = default;

            var archivePath = GetArchivePath(fileName);

            if (!File.Exists(archivePath))
            {
                fileName.LoadWarn("归档文件不存在");
                return false;
            }

            var fileStream = new FileStream(archivePath, FileMode.Open, FileAccess.Read);
            var binaryFormatter = new BinaryFormatter();

            try
            {
                value = binaryFormatter.Deserialize(fileStream) as T;
                fileName.LoadInfo();
                return true;
            }
            catch (System.Exception e)
            {
                fileName.LoadError(e.Message);
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
        /// 获取归档文件数据方法 (对于List类型归档数据的增强处理)
        /// </summary>
        /// <param name="fileName">归档文件名称</param>
        /// <param name="value">归档数据存放对象</param>
        /// <typeparam name="T">归档数据类型</typeparam>
        /// <returns>归档数据获取结果</returns>
        public static bool TryGetArchive<T>(this string fileName, out List<T> value)
        {
            value = default;

            var archivePath = GetArchivePath(fileName);

            if (!File.Exists(archivePath))
            {
                fileName.LoadWarn("归档文件不存在");
                return false;
            }

            var fileStream = new FileStream(archivePath, FileMode.Open, FileAccess.Read);
            var binaryFormatter = new BinaryFormatter();

            try
            {
                value = binaryFormatter.Deserialize(fileStream) as List<T>;
                fileName.LoadInfo();
                return true;
            }
            catch (System.Exception e)
            {
                fileName.LoadError(e.Message);
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
        /// 根据文件名称，获取当前游戏存档的文件路径 (基于这个文件名本身的路径)
        /// </summary>
        /// <param name="fileName">归档文件名称</param>
        /// <returns>完整文件路径</returns>
        public static string GetArchivePath(this string fileName)
        {
            return $"{Paths.GetNewSavePath()}/{YSNewSaveSystem.NowAvatarPathPre}/{fileName}";
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
}