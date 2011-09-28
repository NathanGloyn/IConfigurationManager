using System;
using Configuration.Core;
using Configuration.Interface;
using NUnit.Framework;

namespace ConfigurationManagerWrapper.Test
{
    [TestFixture(typeof(ConfigurationManagerAdapter))]
    [TestFixture(typeof(WebConfigurationManagerAdapter))]
    public class When_using_IConfigurationManager_to_get_AppSetting_as_a_specified_type<T> where T : IConfigurationManagerExtension, new()
    {
        private IConfigurationManagerExtension _target;

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
        public void Should_throw_ArgumentException_when_setting_missing()
        {
            Assert.Throws<ArgumentException>(()=> _target.GetAppSettingsAs<int>("missing"));
        }

        [Test]
        public void Should_throw_exception_if_attempts_to_cast_to_smaller_type()
        {
            Assert.Throws<Exception>(()=> _target.GetAppSettingsAs<int>("long value"));
        }

        [Test]
        public void Should_throw_exception_if_trying_to_convert_to_incompatible_type()
        {
            Assert.Throws<Exception>(() => _target.GetAppSettingsAs<byte>("bool value"));
        }

        
    }
}