using System;
using Configuration.Core;
using Configuration.Interface;
using NUnit.Framework;

namespace ConfigurationManagerWrapper.Test
{
    [TestFixture(typeof(ConfigurationManagerAdapter))]
    [TestFixture(typeof(WebConfigurationManagerAdapter))]
    public class When_getting_setting_using_DefaultOrSettingAs<T> where T : IConfigurationManagerExtension, new()
    {
        private IConfigurationManagerExtension _target;

        [SetUp]
        public void TestSetUp()
        {
            _target = new T();
            ConfigurationFileLoader.LoadConfigurationFile(TestConfig.ValuesForAsAType);
        }

        [Test]
        public void Should_return_default_value_when_setting_missing()
        {
            Assert.AreEqual(default(int), _target.GetDefaultOrAppSettingAs<int>("missing"));
        }

        [Test]
        public void Should_return_default_value_if_attempts_to_cast_to_smaller_type()
        {
            Assert.AreEqual(default(int), _target.GetDefaultOrAppSettingAs<int>("long value"));
        }
    }
}