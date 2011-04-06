using System.Configuration;

namespace ConfigurationManagerWrapper.Test
{
    public class SampleSectionProvider : ConfigurationSection
    {
        [ConfigurationProperty("global")]
        public bool Global
        {
            get { return (bool)this["global"]; }
        }

        // Create a "font" element.
        [ConfigurationProperty("sampleElement")]
        public SampleElement SampleElement
        {
            get { return (SampleElement)this["sampleElement"]; }
            //set { this["sampleElement"] = value; }
        }
    }

    public class SampleElement : ConfigurationElement
    {
        [ConfigurationProperty("name")]
        public string Name
        {
            get { return this["name"] as string; }
        }

        [ConfigurationProperty("value")]
        public string Value
        {
            get { return this["value"] as string; }
        }
    }
}
