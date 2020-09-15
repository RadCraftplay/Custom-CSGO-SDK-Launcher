using Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Templates;
using NUnit.Framework;

namespace UnitTests.Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Templates
{
    [TestFixture]
    public class BasicAppTemplateTests
    {
        [Test]
        public void EqualityTest()
        {
            var template1 = new BasicAppTemplate() {Application = SDKApplication.Hammer};
            var template2 = new BasicAppTemplate() {Application = SDKApplication.Hammer};

            Assert.AreEqual(template1, template2);
        }

        [Test]
        public void DifferenceTest()
        {
            var template1 = new BasicAppTemplate() {Application = SDKApplication.Hammer};
            var template2 = new BasicAppTemplate() {Application = SDKApplication.HLMV};
            
            Assert.AreNotEqual(template1, template2);
        }
    }
}