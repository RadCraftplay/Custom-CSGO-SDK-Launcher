using Distroir.CustomSDKLauncher.Core;
using Distroir.CustomSDKLauncher.Core.Utilities;
using NUnit.Framework;

namespace UnitTests.Distroir.CustomSDKLauncher.Core.Utilities
{
    [TestFixture]
    public class BitmapComparerTests
    {
        [Test]
        public void EqualityTest()
        {
            var result = BitmapComparer.Compare(Data.DefaultIcon, Data.DefaultIcon);
            Assert.IsTrue(result);
        }

        [Test]
        public void FirstNullTest()
        {
            var result = BitmapComparer.Compare(null, Data.DefaultIcon);
            Assert.IsFalse(result);
        }
        
        [Test]
        public void SecondNullTest()
        {
            var result = BitmapComparer.Compare(Data.DefaultIcon, null);
            Assert.IsFalse(result);
        }
        
        [Test]
        public void BothNullTest()
        {
            var result = BitmapComparer.Compare(null, null);
            Assert.IsTrue(result);
        }

        [Test]
        public void DifferentTest()
        {
            var result = BitmapComparer.Compare(Data.HammerIcon, Data.DefaultIcon);
            Assert.IsFalse(result);
        }
    }
}