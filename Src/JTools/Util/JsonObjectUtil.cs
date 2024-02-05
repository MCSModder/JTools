using System;
using System.Collections.Generic;
using System.Linq;

namespace TierneyJohn.MiChangSheng.JTools.Util
{
    /// <summary>
    /// JSONObject 数据处理工具类
    /// </summary>
    public static class JsonObjectUtil
    {
        private const double Tolerance = 1e-6;

        /// <summary>
        /// List 数据转换成 JSONObject 数据
        /// </summary>
        /// <param name="list">值数据集合</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject ToJsonObject(this List<int> list)
        {
            var result = JSONObject.arr;

            if (list == null) return result;

            foreach (var i in list)
            {
                result.Add(i);
            }

            return result;
        }

        /// <summary>
        /// 获取 JSONObject 对象的 int 类型字段数据
        /// </summary>
        /// <param name="data">JSONObject 对象</param>
        /// <param name="key">字段名</param>
        /// <returns>字段数据</returns>
        public static int GetFieldInt(this JSONObject data, string key)
        {
            return data.HasField(key) ? data.GetField(key).I : -1;
        }

        /// <summary>
        /// 获取 JSONObject 对象的 long 类型字段数据
        /// </summary>
        /// <param name="data">JSONObject 对象</param>
        /// <param name="key">字段名</param>
        /// <returns>字段数据</returns>
        public static long GetFieldLong(this JSONObject data, string key)
        {
            return data.HasField(key) ? data.GetField(key).i : -1;
        }

        /// <summary>
        /// 获取 JSONObject 对象的 float 类型字段数据
        /// </summary>
        /// <param name="data">JSONObject 对象</param>
        /// <param name="key">字段名</param>
        /// <returns>字段数据</returns>
        public static float GetFieldFloat(this JSONObject data, string key)
        {
            return data.HasField(key) ? data.GetField(key).f : -1f;
        }

        /// <summary>
        /// 获取 JSONObject 对象的 string 类型字段数据
        /// </summary>
        /// <param name="data">JSONObject 对象</param>
        /// <param name="key">字段名</param>
        /// <returns>字段数据</returns>
        public static string GetFieldStr(this JSONObject data, string key)
        {
            return data.HasField(key) ? data.GetField(key).str : "";
        }

        /// <summary>
        /// 获取 JSONObject 对象的 bool 类型字段数据
        /// </summary>
        /// <param name="data">JSONObject 对象</param>
        /// <param name="key">字段名</param>
        /// <returns>字段数据</returns>
        public static bool GetFieldBool(this JSONObject data, string key)
        {
            return data.HasField(key) && data.GetField(key).b;
        }

        /// <summary>
        /// 获取 JSONObject 对象的 List:int 类型字段数据
        /// </summary>
        /// <param name="data">JSONObject 对象</param>
        /// <param name="key">字段名</param>
        /// <returns>字段数据</returns>
        public static List<int> GetFieldList(this JSONObject data, string key)
        {
            var value = new List<int>();

            if (data.HasField(key))
            {
                value = data.GetField(key).ToList();
            }

            return value;
        }

        /// <summary>
        /// 获取 JSONObject 对象的 DateTime 类型字段数据
        /// </summary>
        /// <param name="data">JSONObject 对象</param>
        /// <param name="key">字段名</param>
        /// <returns>字段数据</returns>
        public static DateTime GetFieldTime(this JSONObject data, string key)
        {
            return data.HasField(key) ? DateTime.Parse(data.GetFieldStr(key)) : DateTime.Parse("0001-01-01");
        }

        /// <summary>
        /// 比较两个 JSONObject 对象的字段值是否相同
        /// </summary>
        /// <param name="data1">JSONObject 对象1</param>
        /// <param name="data2">JSONObject 对象2</param>
        /// <param name="key">字段名</param>
        /// <typeparam name="T">字段类型</typeparam>
        /// <returns>比较结果</returns>
        public static bool EqualsField<T>(this JSONObject data1, JSONObject data2, string key)
        {
            if (!data1.HasField(key))
            {
                return false;
            }

            if (!data2.HasField(key))
            {
                return false;
            }

            if (typeof(T) == typeof(int))
            {
                return data1.GetFieldInt(key) == data2.GetFieldInt(key);
            }

            if (typeof(T) == typeof(long))
            {
                return data1.GetFieldLong(key) == data2.GetFieldLong(key);
            }

            if (typeof(T) == typeof(float))
            {
                return Math.Abs(data1.GetFieldFloat(key) - data2.GetFieldFloat(key)) < Tolerance;
            }

            if (typeof(T) == typeof(string))
            {
                return data1.GetFieldStr(key) == data2.GetFieldStr(key);
            }

            if (typeof(T) == typeof(bool))
            {
                return data1.GetFieldBool(key) == data2.GetFieldBool(key);
            }

            if (typeof(T) == typeof(List<int>))
            {
                return data1.GetFieldList(key).SequenceEqual(data2.GetFieldList(key));
            }

            return false;
        }

        /// <summary>
        /// 比较两个 JSONObject 对象的一组字段值是否相同
        /// </summary>
        /// <param name="data1">JSONObject 对象1</param>
        /// <param name="data2">JSONObject 对象2</param>
        /// <param name="args">字段组</param>
        /// <returns>比较结果</returns>
        public static bool EqualsField(this JSONObject data1, JSONObject data2, List<(string, Type)> args)
        {
            foreach (var (key, type) in args)
            {
                if (type == typeof(int))
                {
                    if (data1.EqualsField<int>(data2, key))
                    {
                        continue;
                    }

                    return false;
                }

                if (type == typeof(long))
                {
                    if (data1.EqualsField<long>(data2, key))
                    {
                        continue;
                    }

                    return false;
                }

                if (type == typeof(float))
                {
                    if (data1.EqualsField<float>(data2, key))
                    {
                        continue;
                    }

                    return false;
                }

                if (type == typeof(string))
                {
                    if (data1.EqualsField<string>(data2, key))
                    {
                        continue;
                    }

                    return false;
                }

                if (type == typeof(bool))
                {
                    if (data1.EqualsField<bool>(data2, key))
                    {
                        continue;
                    }

                    return false;
                }

                if (type == typeof(List<int>))
                {
                    if (data1.EqualsField<List<int>>(data2, key))
                    {
                        continue;
                    }

                    return false;
                }
            }

            return true;
        }
    }
}