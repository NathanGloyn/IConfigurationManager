using System.Collections.Specialized;
using System.Configuration;

namespace Configuration.Interface
{
    public interface IConfigurationManager
    {
        /// <summary>
        /// Gets the System.Configuration.AppSettingsSection data for the current application's default configuration
        /// </summary>
        /// <returns>Returns a System.Collections.Specialized.NameValueCollection object that contains the contents of the System.Configuration.AppSettingsSection object for the current application's default configuration.</returns>
        NameValueCollection AppSettings { get; }

        /// <summary>
        /// Gets a specific AppSetting as a specified type
        /// </summary>
        /// <typeparam name="T">Type that is being requested</typeparam>
        /// <param name="key">Key of AppSetting to retrieve</param>
        /// <returns>If able to return as the type then the converted value; otherwise default value for the type</returns>
        T GetAppSettingsAs<T>(string key);

        /// <summary>
        /// Gets the System.Configuration.ConnectionStringsSection data for the current application's default configuration.
        /// </summary>
        /// <returns>Returns a System.Configuration.ConnectionStringSettingsCollection object that contains the contents of the System.Configuration.ConnectionStringsSection object for the current application's default configuration.</returns>
        ConnectionStringSettingsCollection ConnectionStrings { get; }

        /// <summary>
        /// Retrieves a specified configuration section for the current application's default configuration.
        /// </summary>
        /// <typeparam name="T">The type associated with the configuration section</typeparam>
        /// <param name="sectionName">The configuration section path and name.</param>
        /// <returns>The specified System.Configuration.ConfigurationSection object, or null if the section does not exist.</returns>
        T GetSection<T>(string sectionName);
    }
}
