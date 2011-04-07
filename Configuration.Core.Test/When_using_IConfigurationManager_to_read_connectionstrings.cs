using Configuration.Interface;
using NUnit.Framework;
using Configuration.Core;

namespace ConfigurationManagerWrapper.Test
{
    [TestFixture(typeof(ConfigurationManagerAdapter))]
    [TestFixture(typeof(WebConfigurationManagerAdapter))]
    public class When_using_IConfigurationManager_to_read_connectionstrings<T> where T : IConfigurationManager, new()
    {
        private IConfigurationManager _target;

        [SetUp]
        public void TestSetUp()
        {
            _target = new T();
        }

        [Test]
        public void Should_return_empty_connectionstrings_when_no_section_in_config()
        {
            ConfigurationFileLoader.LoadConfigurationFile(TestConfig.Empty);

            Assert.That(_target.AppSettings, Is.Empty);
        }

        [Test]
        public void Should_return_empty_connectionstrings_when_connectionstrings_has_no_values()
        {
            ConfigurationFileLoader.LoadConfigurationFile(TestConfig.SectionsNoValues);

            Assert.That(_target.AppSettings, Is.Empty);
        }

        [Test]
        public void Should_return_zero_count_for_connectionstrings_when_no_section_in_config()
        {
            ConfigurationFileLoader.LoadConfigurationFile(TestConfig.Empty);

            Assert.AreEqual(0, _target.AppSettings.Count);

        }

        [Test]
        public void Should_return_zero_count_for_connectionstrings_without_values()
        {
            ConfigurationFileLoader.LoadConfigurationFile(TestConfig.SectionsNoValues);

            Assert.AreEqual(0, _target.AppSettings.Count);

        }

        [Test]
        public void Should_return_count_of_one_for_connectionstrings_with_single_value()
        {
            ConfigurationFileLoader.LoadConfigurationFile(TestConfig.SingleValue);

            Assert.AreEqual(1, _target.ConnectionStrings.Count);
        }

        [Test]
        public void Should_return_expected_connectionstring_name_by_position_for_single_setting()
        {
            ConfigurationFileLoader.LoadConfigurationFile(TestConfig.SingleValue);

            StringAssert.AreEqualIgnoringCase("Test",_target.ConnectionStrings[0].Name);
        }

        [Test]
        public void Should_return_expected_connectionstring_by_position_for_single_setting()
        {
            ConfigurationFileLoader.LoadConfigurationFile(TestConfig.SingleValue);

            StringAssert.AreEqualIgnoringCase("Data Source=myServerAddress;Initial Catalog=myDataBase;Integrated Security=SSPI;",
                                               _target.ConnectionStrings[0].ConnectionString);
        }

        [Test]
        public void Should_return_expected_connectionstring_by_name_for_single_setting()
        {
            ConfigurationFileLoader.LoadConfigurationFile(TestConfig.SingleValue);

            StringAssert.AreEqualIgnoringCase("Data Source=myServerAddress;Initial Catalog=myDataBase;Integrated Security=SSPI;",
                                               _target.ConnectionStrings["Test"].ConnectionString);
        }

        [Test]
        public void Should_return_count_of_two_for_connectionstrings_with_two_values()
        {
            ConfigurationFileLoader.LoadConfigurationFile(TestConfig.MultipleValues);

            Assert.AreEqual(2, _target.ConnectionStrings.Count);
        }

        [Test]
        public void Should_return_expected_connectionstring_name_by_position_with_multiple_settings()
        {
            ConfigurationFileLoader.LoadConfigurationFile(TestConfig.MultipleValues);

            StringAssert.AreEqualIgnoringCase("Test2", _target.ConnectionStrings[1].Name);
        }

        [Test]
        public void Should_return_expected_connectionstring_by_position_with_multiple_settings()
        {
            ConfigurationFileLoader.LoadConfigurationFile(TestConfig.MultipleValues);

            StringAssert.AreEqualIgnoringCase("Data Source=myOtherServerAddress;Initial Catalog=myOtherDataBase;Integrated Security=SSPI;",
                                               _target.ConnectionStrings[1].ConnectionString);
        }

        [Test]
        public void Should_return_expected_connectionstring_by_name_with_multiple_settings()
        {
            ConfigurationFileLoader.LoadConfigurationFile(TestConfig.MultipleValues);

            StringAssert.AreEqualIgnoringCase("Data Source=myOtherServerAddress;Initial Catalog=myOtherDataBase;Integrated Security=SSPI;",
                                               _target.ConnectionStrings["Test2"].ConnectionString);
        }

    }
}
