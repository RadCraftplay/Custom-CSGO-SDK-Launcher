using System;
using Distroir.CustomSDKLauncher.Core;
using Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Templates.Java.PathFinders;
using NUnit.Framework;

namespace UnitTests.Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Templates.Java.PathFinders
{
    [TestFixture]
    public class PathJavaPathFinderTests
    {
        [Test]
        public void TestPath()
        {
            IJavaPathFinder finder = new PathJavaPathFinder();
            Assert.AreEqual(finder.CanGetPath(), Utils.TryLaunch("javaw"));
        }

        [Test]
        public void TestCanGetPathPerformance()
        {
            IJavaPathFinder finder = new PathJavaPathFinder();
            finder.CanGetPath();
        }

        [Test]
        public void TestOldCanGetPathMethodPerformance()
        {
            Utils.TryLaunch("javaw");
        }
    }
}