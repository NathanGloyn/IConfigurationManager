using System.Reflection;
using System.IO;
using System;
using System.Configuration;

namespace ConfigurationManagerWrapper.Test
{
    public class ConfigurationFileLoader
    {
        private const string FullFileNameFormat = "{0}.config";
        private const string CopyFileNameFormat = "Configs\\{0}.config";

        public static void LoadConfigurationFile(TestConfig config)
        {
            string configFileName = string.Format(FullFileNameFormat, Assembly.GetExecutingAssembly().GetName().Name);
            string fileToCopy = string.Format(CopyFileNameFormat, config);

            if(File.Exists(configFileName)) File.Delete(configFileName);
            
            File.Copy(fileToCopy, configFileName,true);

            AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE",configFileName);
            typeof(ConfigurationManager).GetField("s_initState", BindingFlags.NonPublic | BindingFlags.Static).SetValue(null, 0);
        }
    }
}
