namespace Configuration.Interface
{
    public interface IConfigurationManagerExtension:IConfigurationManager
    {
        /// <summary>
        /// Gets a specific AppSetting as a specified type
        /// </summary>
        /// <typeparam name="T">Type that is being requested</typeparam>
        /// <param name="key">Key of AppSetting to retrieve</param>
        /// <returns>If able to return as the type then the converted value; otherwise exception that is thrown</returns>
        T GetAppSettingsAs<T>(string key);

        /// <summary>
        /// Gets a specific AppSetting as a specified type or default value for that type
        /// </summary>
        /// <typeparam name="T">Type that is being requested</typeparam>
        /// <param name="key">Key of AppSetting to retrieve</param>
        /// <returns>If able to return as the type then the converted value; otherwise default value for the type</returns>
        T GetDefaultOrAppSettingAs<T>(string key);        
    }
}