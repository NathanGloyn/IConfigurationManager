using Configuration.Core;
using Configuration.Interface;
using NUnit.Framework;

namespace ConfigurationManagerWrapper.Test
{
    [TestFixture(typeof(ConfigurationManagerAdapter))]
    //[TestFixture(typeof(WebConfigurationManagerAdapter))]
    public class When_using_IConfigurationManager_to_get_AppSetting_as_a_specified_type //<T> where T : IConfigurationManager, new()
    {
        private IConfigurationManager _target;

        [SetUp]
        public void TestSetUp()
        {
            _target = new ConfigurationManagerAdapter();
        }

        [Test]
        public void Should_return_an_int_setting_as_an_int()
        {
            ConfigurationFileLoader.LoadConfigurationFile(TestConfig.ValuesForAsAType);

            Assert.AreEqual(123, _target.GetAppSettingsAs<int>("int value"));
        }

        [Test]
        public void Should_return_an_bool_setting_as_true()
        {
            ConfigurationFileLoader.LoadConfigurationFile(TestConfig.ValuesForAsAType);

            Assert.AreEqual(true, _target.GetAppSettingsAs<bool>("bool value"));
        }
    }
}