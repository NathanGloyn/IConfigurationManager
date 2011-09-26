using System;
using System.ComponentModel;
using Configuration.Interface;
using System.Collections.Specialized;
using System.Configuration;

namespace Configuration.Core
{
    /// <summary>
    /// Class that wraps the functionality within the standard Configuration Manager class
    /// </summary>
    public class ConfigurationManagerAdapter : IConfigurationManager
    {
        /// <summary>
        /// Provides access to the AppSettings in the configuration file
        /// </summary>
        public NameValueCollection AppSettings
        {
            get
            {
                return ConfigurationManager.AppSettings;
            }
        }

        public ConnectionStringSettingsCollection ConnectionStrings
        {
            get { return ConfigurationManager.ConnectionStrings; }
        }

        public T GetAppSettingsAs<T>(string key)
        {
            if(string.IsNullOrEmpty(key))
            {
                
            }

            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
            try
            {
                return (T)converter.ConvertFromString(AppSettings[key]);
            }
            catch
            {
                return default(T);
            }
        }

        /// <summary>
        /// Provides access to any specific section within the configuration file
        /// </summary>
        /// <typeparam name="T">The type associated with the section</typeparam>
        /// <param name="sectionName">Name of the section to return</param>
        /// <returns>The section specified</returns>
        public T GetSection<T>(string sectionName)
        {
            return (T)ConfigurationManager.GetSection(sectionName);
        }
    }
}
