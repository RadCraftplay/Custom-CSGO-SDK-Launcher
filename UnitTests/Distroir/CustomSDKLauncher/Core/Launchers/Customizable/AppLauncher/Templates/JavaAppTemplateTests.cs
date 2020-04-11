using Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher;
using Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Templates;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace UnitTests.Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Templates
{
    [TestFixture]
    public class JavaAppTemplateTests
    {
        private AppInfo _info => new AppInfo()
        {
            DisplayText = "Test info"
        };
        
        [Test]
        public void EqualityTest()
        {
            var template1 = new JavaAppTemplate(_info);
            var template2 = new JavaAppTemplate(_info);

            Assert.AreEqual(template1, template2);
        }

        [Test]
        public void DifferenceTest()
        {
            var template1 = new JavaAppTemplate(_info);
            var template2 = new JavaAppTemplate(new AppInfo());
            
            Assert.AreNotEqual(template1, template2);
        }
    }
}