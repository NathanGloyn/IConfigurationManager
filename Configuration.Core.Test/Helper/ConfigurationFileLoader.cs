using System.Reflection;
using System.IO;
using System;
using System.Configuration;
using System.Threading;

namespace ConfigurationManagerWrapper.Test
{
    public class ConfigurationFileLoader
    {
        private const string FullFileNameFormat = "{0}.config";
        private const string CopyFileNameFormat = "Configs\\{0}.config";

        public static void LoadConfigurationFile(TestConfig config)
        {
            string configFileName = GetConfigFileName();
            
            DeleteExistingConfig(configFileName);

            CopySpecifiedTestConfig(configFileName, config);

            SetCurrentDomainConfig(configFileName);
        }

        private static string GetConfigFileName()
        {
            return string.Format(FullFileNameFormat, Assembly.GetExecutingAssembly().GetName().Name);
        }

        private static void DeleteExistingConfig(string configFileName)
        {
            if(File.Exists(configFileName)) File.Delete(configFileName);
        }

        private static void CopySpecifiedTestConfig(string configFileName, TestConfig config)
        {
            string fileToCopy = string.Format(CopyFileNameFormat, config);

            bool copied = false;
            int attempts = 0;

            do
            {
                try
                {
                    File.Copy(fileToCopy, configFileName, true);
                    copied = true;
                }
                catch (System.UnauthorizedAccessException ex)
                {
                    attempts++;
                    Thread.Sleep(10);
                }
            } while (!copied || attempts > 5);
        }

        private static void SetCurrentDomainConfig(string configFileName)
        {
            AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", configFileName);
            typeof(ConfigurationManager).GetField("s_initState", BindingFlags.NonPublic | BindingFlags.Static).SetValue(null, 0);
        }

    }
}
