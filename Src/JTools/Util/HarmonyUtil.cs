using System;
using HarmonyLib;

namespace TierneyJohn.MiChangSheng.JTools.Util
{
    public static class HarmonyUtil
    {
        public static void ChangeFieldValue<T>(this object instance, string fieldName, Action<T> action)
        {
            var clazz = Traverse.Create(instance);
            if (!clazz.Field(fieldName).FieldExists()) return;
            var value = clazz.Field(fieldName).GetValue<T>();
            action.Invoke(value);
            clazz.Field(fieldName).SetValue(value);
        }

        public static void ChangeFieldValue<T, TR>(this string fieldName, Action<TR> action)
        {
            var clazz = Traverse.Create<T>();
            if (!clazz.Field(fieldName).FieldExists()) return;
            var value = clazz.Field(fieldName).GetValue<TR>();
            action.Invoke(value);
            clazz.Field(fieldName).SetValue(value);
        }

        public static void ChangePropertyValue<T>(this object instance, string propertyName, Action<T> action)
        {
            var clazz = Traverse.Create(instance);
            if (!clazz.Property(propertyName).PropertyExists()) return;
            var value = clazz.Property(propertyName).GetValue<T>();
            action.Invoke(value);
            clazz.Property(propertyName).SetValue(value);
        }

        public static void ChangePropertyValue<T, TR>(this string propertyName, Action<TR> action)
        {
            var clazz = Traverse.Create<T>();
            if (!clazz.Property(propertyName).PropertyExists()) return;
            var value = clazz.Property(propertyName).GetValue<TR>();
            action.Invoke(value);
            clazz.Property(propertyName).SetValue(value);
        }
    }
}