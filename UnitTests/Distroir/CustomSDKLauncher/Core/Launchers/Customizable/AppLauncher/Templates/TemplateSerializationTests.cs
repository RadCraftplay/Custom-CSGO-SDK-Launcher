using System;
using System.IO;
using Distroir.CustomSDKLauncher.Core;
using Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher;
using Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Templates;
using Newtonsoft.Json;
using NUnit.Framework;
using SDKApplication = Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Templates.SDKApplication;

namespace UnitTests.Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Templates
{
    [TestFixture]
    public class TemplateSerializationTests
    {
        private string Serialize<T>(T toSerialize)
        {
            var serializer = new JsonSerializer();
            var stringWriter = new StringWriter();
            
            using (JsonTextWriter writer = new JsonTextWriter(stringWriter))
                serializer.Serialize(writer, toSerialize);

            return stringWriter.ToString();
        }

        private T Deserialize<T>(string toDeserialize)
        {
            var serializer = new JsonSerializer();
            var stringReader = new StringReader(toDeserialize);

            using (JsonTextReader reader = new JsonTextReader(stringReader))
                return serializer.Deserialize<T>(reader);
        }

        private T SerializeAndDeserialize<T>(T toSerializeAndDeserialize)
        {
            var serialized = Serialize(toSerializeAndDeserialize);
            return Deserialize<T>(serialized);
        }

        [Test]
        public void BasicAppTemplateSerializationTest()
        {
            var expected = new BasicAppTemplate() { Application = SDKApplication.Hammer };
            var actual = SerializeAndDeserialize(expected);
            
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CustomAppTemplateSerializationTest()
        {
            var expected = new CustomAppTemplate( new AppInfo() { DisplayText = "Example app" });
            var actual = SerializeAndDeserialize(expected);
            
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void JavaAppTemplateSerializationTest()
        {
            var expected = new JavaAppTemplate( new AppInfo() { DisplayText = "Example app" });
            var actual = SerializeAndDeserialize(expected);
            
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void SteamAppTemplateSerializationTest()
        {
            var expected = new SteamAppTemplate("Test app", 1234, Data.DefaultIcon);
            var actual = SerializeAndDeserialize(expected);
            
            Assert.AreEqual(expected, actual);
        }
    }
}