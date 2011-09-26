using System;
using System.Collections.Specialized;
using System.Configuration;
using Configuration.Interface;

namespace Configuration.Core
{
    /// <summary>
    /// Class that wraps the functionality within the Web Configuration Manager class
    /// </summary>
    public class WebConfigurationManagerAdapter: IConfigurationManager
    {
        /// <summary>
        /// Provides access to the AppSettings in the configuration file
        /// </summary>
        public NameValueCollection AppSettings
        {
            get
            {
                return System.Web.Configuration.WebConfigurationManager.AppSettings;
            }
        }

        public ConnectionStringSettingsCollection ConnectionStrings
        {
            get { return System.Web.Configuration.WebConfigurationManager.ConnectionStrings; }
        }

        public T GetAppSettingsAs<T>(string key)
        {
            return GetSetting.As<T>(System.Web.Configuration.WebConfigurationManager.AppSettings, key);
        }

        /// <summary>
        /// Provides access to any specific section within the configuration file
        /// </summary>
        /// <typeparam name="T">The type associated with the section</typeparam>
        /// <param name="sectionName">Name of the section to return</param>
        /// <returns>The section specified</returns>
        public T GetSection<T>(string sectionName)
        {
            return (T)System.Web.Configuration.WebConfigurationManager.GetSection(sectionName);
        }
    }
}
