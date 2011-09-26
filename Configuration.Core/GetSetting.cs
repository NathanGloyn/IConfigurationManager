using System;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Configuration.Core
{
    internal class GetSetting
    {
        internal static T As<T>(NameValueCollection settings, string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key");
            }

            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
            try
            {
                return (T)converter.ConvertFromString(settings[key]);
            }
            catch
            {
                return default(T);
            }
        }
    }
}