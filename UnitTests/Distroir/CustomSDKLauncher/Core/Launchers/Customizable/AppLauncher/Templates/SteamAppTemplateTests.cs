using System.Drawing;
using System.Net.Mime;
using Distroir.CustomSDKLauncher.Core;
using Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Templates;
using NUnit.Framework;

namespace UnitTests.Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Templates
{
    [TestFixture]
    public class SteamAppTemplateTests
    {
        [Test]
        public void EqualityTest()
        {
            var template1 = new SteamAppTemplate("Test app", 1234, Data.HammerIcon);
            var template2 = new SteamAppTemplate("Test app", 1234, Data.HammerIcon);

            Assert.AreEqual(template1, template2);
        }

        [Test]
        public void DifferenceTest()
        {
            var template1 = new SteamAppTemplate("Test app", 1234);
            var template2 = new SteamAppTemplate();
            
            Assert.AreNotEqual(template1, template2);
        }
    }
}