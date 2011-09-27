using System;
using Configuration.Core;
using Configuration.Interface;
using NUnit.Framework;

namespace ConfigurationManagerWrapper.Test
{
    [TestFixture(typeof(ConfigurationManagerAdapter))]
    [TestFixture(typeof(WebConfigurationManagerAdapter))]
    public class When_using_IConfigurationManager_to_get_AppSetting_as_a_specified_type <T> where T : IConfigurationManager, new()
    {
        private IConfigurationManager _target;

        [SetUp]
        public void TestSetUp()
        {
            _target = new T();
            ConfigurationFileLoader.LoadConfigurationFile(TestConfig.ValuesForAsAType);
        }

        [Test]
        public void Should_throw_ArgumentNullException_if_empty_string_provided_for_the_key()
        {
            Assert.Throws<ArgumentNullException>(() => _target.GetAppSettingsAs<int>(string.Empty));
        }

        [Test]
        public void Should_throw_ArgumentNullException_if_null_provided_for_the_key()
        {
            Assert.Throws<ArgumentNullException>(() => _target.GetAppSettingsAs<int>(null));
        }


        [Test]
        public void Should_return_a_byte_setting_as_an_int()
        {
            Assert.AreEqual(123, _target.GetAppSettingsAs<int>("byte value"));
        }

        [Test]
        public void Should_return_correct_value_for_int_setting()
        {

            Assert.AreEqual(2147483647, _target.GetAppSettingsAs<int>("int value"));
        }

        [Test]
        public void Should_return_default_value_when_setting_missing()
        {
            Assert.AreEqual(default(int),_target.GetAppSettingsAs<int>("missing"));
        }


        [Test]
        public void Should_return_a_float_setting_as_a_Single()
        {
            Assert.AreEqual(1.0m, _target.GetAppSettingsAs<Single>("float value"));
        }

        [Test]
        public void Should_return_a_float_setting_as_a_Decimal()
        {
            Assert.AreEqual(1.0m, _target.GetAppSettingsAs<Decimal>("float value"));
        }

        [Test]
        public void Should_implicitly_cast_to_specified_type()
        {
            Assert.AreEqual(32767, _target.GetAppSettingsAs<int>("short value"));
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
            Assert.AreEqual(DateTime.MinValue, _target.GetAppSettingsAs<DateTime>("short US date value"));
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