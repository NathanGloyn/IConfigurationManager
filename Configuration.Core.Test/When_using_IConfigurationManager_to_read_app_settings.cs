using Configuration.Core;
using Configuration.Interface;
using NUnit.Framework;

namespace ConfigurationManagerWrapper.Test
{
    [TestFixture(typeof(ConfigurationManagerAdapter))]
    [TestFixture(typeof(WebConfigurationManagerAdapter))]
    public class When_using_IConfigurationManager_to_read_app_settings<T> where T: IConfigurationManager, new()
    {
        private IConfigurationManager _target;

        [SetUp]
        public void TestSetUp()
        {
            this._target = new T();
        }

        [Test]
        public void Should_return_empty_app_settings_when_no_section_in_config()
        {
            ConfigurationFileLoader.LoadConfigurationFile(TestConfig.Empty);   

            Assert.That(_target.AppSettings, Is.Empty);
        }

        [Test]
        public void Should_return_empty_app_settings_when_app_settings_has_no_values()
        {
            ConfigurationFileLoader.LoadConfigurationFile(TestConfig.SectionsNoValues);

            Assert.That(_target.AppSettings, Is.Empty);
        }

        [Test]
        public void Should_return_zero_count_for_app_settings_when_no_section_in_config()
        {
            ConfigurationFileLoader.LoadConfigurationFile(TestConfig.Empty);

            Assert.AreEqual(0, _target.AppSettings.Count);

        }

        [Test]
        public void Should_return_zero_count_for_app_settings_without_values()
        {
            ConfigurationFileLoader.LoadConfigurationFile(TestConfig.SectionsNoValues);

            Assert.AreEqual(0, _target.AppSettings.Count);

        }

        [Test]
        public void Should_return_count_of_one_for_app_setting_with_single_value()
        {
            ConfigurationFileLoader.LoadConfigurationFile(TestConfig.SingleValue);

            Assert.AreEqual(1, _target.AppSettings.Count);
        }

        [Test]
        public void Should_return_correct_key_of_single_setting_by_position()
        {
            ConfigurationFileLoader.LoadConfigurationFile(TestConfig.SingleValue);

            Assert.AreEqual("A Key", _target.AppSettings.GetKey(0));
        }

        [Test]
        public void Should_return_correct_value_of_single_setting_by_position()
        {
            ConfigurationFileLoader.LoadConfigurationFile(TestConfig.SingleValue);

            Assert.AreEqual("A value", _target.AppSettings[0]);            
        }

        [Test]
        public void Should_return_correct_value_of_single_setting_by_name()
        {
            ConfigurationFileLoader.LoadConfigurationFile(TestConfig.SingleValue);

            Assert.AreEqual("A value", _target.AppSettings["A Key"]);
        }

        [Test]
        public void Should_return_count_of_two_for_app_setting_with_two_values()
        {
            ConfigurationFileLoader.LoadConfigurationFile(TestConfig.MultipleValues);

            Assert.AreEqual(2, _target.AppSettings.Count);
        }

        [Test]
        public void Should_return_correct_key_of_setting_by_position()
        {
            ConfigurationFileLoader.LoadConfigurationFile(TestConfig.MultipleValues);

            Assert.AreEqual("Another Key", _target.AppSettings.GetKey(1));
        }

        [Test]
        public void Should_return_correct_value_of_setting_by_position()
        {
            ConfigurationFileLoader.LoadConfigurationFile(TestConfig.MultipleValues);

            Assert.AreEqual("Another value", _target.AppSettings[1]);
        }

        [Test]
        public void Should_return_correct_value_of_setting_by_name()
        {
            ConfigurationFileLoader.LoadConfigurationFile(TestConfig.MultipleValues);

            Assert.AreEqual("Another value", _target.AppSettings["Another Key"]);
        }
    }
}
