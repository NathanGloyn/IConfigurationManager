using NUnit.Framework;
using Configuration.Core;

namespace ConfigurationManagerWrapper.Test
{
    [TestFixture]
    public class When_using_WebConfigurationManagerAdapter_to_get_custom_section
    {
        private WebConfigurationManagerAdapter _target;
        private SampleSectionProvider _provider;

        [SetUp]
        public void TestSetUp()
        {
            _target = new WebConfigurationManagerAdapter();
        }

        private void LoadProvider()
        {
            _provider = _target.GetSection<SampleSectionProvider>("sampleSection");            
        }

        [Test]
        public void Should_return_instance_of_correct_type()
        {
            ConfigurationFileLoader.LoadConfigurationFile(TestConfig.CustomSectionProviderDefinitionOnly);
            LoadProvider();
            Assert.IsNotNull(_provider);
        }

        [Test]
        public void Should_return_value_of_section_attribute_global()
        {
            ConfigurationFileLoader.LoadConfigurationFile(TestConfig.CustomSectionProviderSectionAttribute);
            LoadProvider();    
            Assert.IsTrue(_provider.Global);
        }

        [Test]
        public void Should_be_able_to_get_name_of_sample_element()
        {
            ConfigurationFileLoader.LoadConfigurationFile(TestConfig.CustomSectionProviderWithValues);
            LoadProvider();
            Assert.AreEqual("abc", _provider.SampleElement.Name);
        }

        [Test]
        public void Should_be_able_to_get_value_of_sample_element()
        {
            ConfigurationFileLoader.LoadConfigurationFile(TestConfig.CustomSectionProviderWithValues);
            LoadProvider();
            Assert.AreEqual("123", _provider.SampleElement.Value);
        }
    }
}
