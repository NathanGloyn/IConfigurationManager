using System;
using Configuration.Core;
using Configuration.Interface;
using NUnit.Framework;

namespace ConfigurationManagerWrapper.Test
{
    [TestFixture(typeof(ConfigurationManagerAdapter))]
    [TestFixture(typeof(WebConfigurationManagerAdapter))]
    public class When_getting_AppSetting_as_datetime<T> where T : IConfigurationManager, new()
    {
        private IConfigurationManager _target;

        [SetUp]
        public void TestSetUp()
        {
            _target = new T();
            ConfigurationFileLoader.LoadConfigurationFile(TestConfig.ValuesForAsAType);
        }

        [Test]
        public void Should_return_a_datetime_for_short_datetime_in_UK_format()
        {
            Assert.AreEqual(new DateTime(2011, 10, 13), _target.GetAppSettingsAs<DateTime>("short UK date value"));
        }

        [Test]
        public void Should_return_a_datetime_for_short_datetime_in_big_endian_format()
        {
            Assert.AreEqual(new DateTime(2011, 10, 13), _target.GetAppSettingsAs<DateTime>("short big endian date value"));
        }

        [Test]
        [SetCulture("en-US")]
        public void Should_return_a_datetime_for_short_datetime_in_US_format()
        {
            Assert.AreEqual(new DateTime(2011, 10, 13), _target.GetAppSettingsAs<DateTime>("short US date value"));
        }

        [Test]
        public void Should_return_min_value_for_datetime_if_setting_is_US_date_in_non_US_culture()
        {
            Assert.AreEqual(DateTime.MinValue, _target.GetDefaultOrAppSettingAs<DateTime>("short US date value"));
        }

        [Test]
        public void Should_return_a_datetime_for_long_datetime_in_UK_format()
        {
            Assert.AreEqual(new DateTime(2011, 9, 13), _target.GetAppSettingsAs<DateTime>("long UK date value"));
        }

        [Test]
        public void Should_return_a_datetime_for_long_datetime_in_US_format()
        {
            Assert.AreEqual(new DateTime(2011, 9, 13), _target.GetAppSettingsAs<DateTime>("long US date value"));
        }        
    }
}