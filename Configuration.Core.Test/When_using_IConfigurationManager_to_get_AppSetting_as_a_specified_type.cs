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

        [TestCase(typeof(byte), 123)]
        [TestCase(typeof(sbyte),-99)]
        [TestCase(typeof(int), 2147483647)]
        [TestCase(typeof(uint), 4294967295)]
        [TestCase(typeof(short), 32767)]
        [TestCase(typeof(ushort), 65535)]
        [TestCase(typeof(long), 922337203685477507)]
        [TestCase(typeof(ulong), 18446744073709551615)]
        [TestCase(typeof(float), 1.0)]
        [TestCase(typeof(double),1.0)]
        [TestCase(typeof(decimal),1.0)]
        [TestCase(typeof(bool), true)]
        [TestCase(typeof(char), 'A')]
        public void Should_return_correct_value_for_setting_and_type(T typeToGet,  object expectedValue)
        {
            var settingName = string.Format("{0} value", typeToGet.GetType().Name);

            Assert.AreEqual(expectedValue, _target.GetAppSettingsAs<T>(settingName));
        }

        [TestCase(typeof(byte))]
        [TestCase(typeof(sbyte))]
        [TestCase(typeof(int))]
        [TestCase(typeof(uint))]
        [TestCase(typeof(short))]
        [TestCase(typeof(ushort))]
        [TestCase(typeof(long))]
        [TestCase(typeof(ulong))]
        [TestCase(typeof(float))]
        [TestCase(typeof(double))]
        [TestCase(typeof(decimal))]
        [TestCase(typeof(DateTime))]
        [TestCase(typeof(bool))]
        [TestCase(typeof(char))]
        public void Should_return_default_value_when_setting_missing(T typetoGet)
        {
            Assert.AreEqual(default(T),_target.GetAppSettingsAs<T>("missing"));
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