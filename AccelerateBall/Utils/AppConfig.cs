using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace AccelerateBall.Utils
{
    /// <summary>
    /// 应用程序配置
    /// </summary>
    public class AppConfig
    {
        /// <summary>
        /// 小球初始化X坐标
        /// </summary>
        public static List<string> CodeList
        {
            get
            {
                var codeStr = GetAppsettingValue("codeList") as string;
                return codeStr.Split(',').ToList();
            }
            private set => SetAppsettingValue("codeList", value.ToString());
        }

        /// <summary>
        /// 小球初始化X坐标
        /// </summary>
        public static int LocationX
        {
            get => GetAppsettingValue("locationX", 100);
            set => SetAppsettingValue("locationX", value.ToString());
        }

        /// <summary>
        /// 小球初始化Y坐标
        /// </summary>
        public static int LocationY
        {
            get => GetAppsettingValue("locationY", 100);
            set => SetAppsettingValue("locationY", value.ToString());
        }

        /// <summary>
        /// 透明度信息
        /// </summary>
        public static int Opacity
        {
            get => GetAppsettingValue("opacity", 100);
            set => SetAppsettingValue("opacity", value.ToString());
        }

        /// <summary>
        /// 是否置于顶层
        /// </summary>
        public static bool TopMost
        {
            get => GetAppsettingValue("topMost", true);
            set => SetAppsettingValue("topMost", value.ToString());
        }

        private static bool SetAppsettingValue(string key, string value)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (config.AppSettings.Settings[key] != null)
                    config.AppSettings.Settings[key].Value = value;
                else
                    config.AppSettings.Settings.Add(key, value);
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static T GetAppsettingValue<T>(string key, T defaultValue)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings[key] == null || config.AppSettings.Settings[key].Value == null) return defaultValue;

            try
            {
                var ret = Convert.ChangeType(config.AppSettings.Settings[key].Value, typeof(T));

                return (T)ret;
            }
            catch { return defaultValue; }
        }

        private static object GetAppsettingValue(string key, object defaultValue = null)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings[key] == null || config.AppSettings.Settings[key].Value == null) return defaultValue;

            return config.AppSettings.Settings[key].Value;
        }
    }
}
