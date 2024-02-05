using BepInEx.Configuration;
using SkySwordKill.Next.Mod;

namespace TierneyJohn.MiChangSheng.JTools_Next.Util
{
    /// <summary>
    /// Next ModManager 管理器扩展工具类
    /// </summary>
    public static class ModManagerUtil
    {
        public static void InitModSettingAction(this ConfigEntry<bool> configEntry, string key)
        {
            configEntry.SettingChanged += (sender, args) => { ModManager.SetModSetting(key, configEntry.Value); };
        }

        public static void InitModSettingAction(this ConfigEntry<long> configEntry, string key)
        {
            configEntry.SettingChanged += (sender, args) => { ModManager.SetModSetting(key, configEntry.Value); };
        }

        public static void InitModSettingAction(this ConfigEntry<double> configEntry, string key)
        {
            configEntry.SettingChanged += (sender, args) => { ModManager.SetModSetting(key, configEntry.Value); };
        }

        public static void InitModSettingAction(this ConfigEntry<string> configEntry, string key)
        {
            configEntry.SettingChanged += (sender, args) => { ModManager.SetModSetting(key, configEntry.Value); };
        }

        public static void InitModLoadComplete(this ConfigEntry<bool> configEntry, string key)
        {
            ModManager.SetModSetting(key, configEntry.Value);
        }

        public static void InitModLoadComplete(this ConfigEntry<long> configEntry, string key)
        {
            ModManager.SetModSetting(key, configEntry.Value);
        }

        public static void InitModLoadComplete(this ConfigEntry<double> configEntry, string key)
        {
            ModManager.SetModSetting(key, configEntry.Value);
        }

        public static void InitModLoadComplete(this ConfigEntry<string> configEntry, string key)
        {
            ModManager.SetModSetting(key, configEntry.Value);
        }

        public static void InitModSettingChanged(this ConfigEntry<bool> configEntry, string key)
        {
            if (ModManager.TryGetModSetting(key, out bool value))
            {
                configEntry.Value = value;
            }
        }

        public static void InitModSettingChanged(this ConfigEntry<long> configEntry, string key)
        {
            if (ModManager.TryGetModSetting(key, out long value))
            {
                configEntry.Value = value;
            }
        }

        public static void InitModSettingChanged(this ConfigEntry<double> configEntry, string key)
        {
            if (ModManager.TryGetModSetting(key, out double value))
            {
                configEntry.Value = value;
            }
        }

        public static void InitModSettingChanged(this ConfigEntry<string> configEntry, string key)
        {
            if (ModManager.TryGetModSetting(key, out string value))
            {
                configEntry.Value = value;
            }
        }
    }
}