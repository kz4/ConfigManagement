using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;
using System.Reflection;
using System.IO;

namespace DevProdConfigTest
{
    public class ReadConfig
    {
        #region Constructor

        public ReadConfig(Config version)
        {
            ReadConfigFile(version);
        }

        #endregion Constructor

        #region Private methods

        private void ReadConfigFile(Config version)
        {
            string dir = Assembly.GetExecutingAssembly().Location;
            string solDir = Path.GetFullPath(Path.Combine(dir, @"..\..\..\"));

            string configPath = string.Empty;
            if (version == Config.Development)
            {
                configPath = Path.Combine(solDir, @"App.config");
            }
            else
            {
                configPath = Path.Combine(solDir, @"App1.config");
            }
            
            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = configPath;

            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(
                 configFileMap, ConfigurationUserLevel.None);

            AppSettingsSection section = (AppSettingsSection)config.GetSection("appSettings");
            Test1 = GetAppSettingValue(section, "test:key");
            Test2 = GetAppSettingValue(section, "test:key2");
            Test3 = GetAppSettingValue(section, "test:key3");
            Test4 = GetAppSettingValue(section, "test:key4");
        }

        private string GetAppSettingValue(AppSettingsSection section, string settingKey)
        {
            try
            {
                var keyVal = section.Settings[settingKey];
                if (keyVal != null) return keyVal.Value;
            }
            catch (ConfigurationErrorsException)
            {
                
            }
            return string.Empty;
        }

        #endregion Private methods

        #region Properties

        public string Test1 { get; set; }
        public string Test2 { get; set; }
        public string Test3 { get; set; }
        public string Test4 { get; set; }

        #endregion Properties
    }

    #region Helper classes

    public enum Config
    {
        Development, Production
    }

    #endregion Helper classes
}