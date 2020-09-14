using System;
using System.Drawing;
using System.Text.RegularExpressions;
using Distroir.CustomSDKLauncher.Core.Utilities;
using Newtonsoft.Json;

namespace Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Factories.Java
{
    public class JavaApplication
    {
        public JavaApplication(string name, string jarFilePath, string javaExecutablePath, Image icon)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            JarFilePath = jarFilePath ?? throw new ArgumentNullException(nameof(jarFilePath));
            JavaExecutablePath = javaExecutablePath ?? throw new ArgumentNullException(nameof(javaExecutablePath));
            Icon = (SerializableImage)icon ?? throw new ArgumentNullException(nameof(icon));
        }
        
        [JsonConstructor]
        public JavaApplication(string name, string jarFilePath, string javaExecutablePath, SerializableImage icon)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            JarFilePath = jarFilePath ?? throw new ArgumentNullException(nameof(jarFilePath));
            JavaExecutablePath = javaExecutablePath ?? throw new ArgumentNullException(nameof(javaExecutablePath));
            Icon = icon ?? throw new ArgumentNullException(nameof(icon));
        }

        public JavaApplication(AppInfo info)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));
            
            Name = info.DisplayText;
            Icon = (SerializableImage)info.Icon;
            JavaExecutablePath = info.Path;
            JarFilePath = DeconstructJarFilePathFromArgumentList(info.Arguments);
        }

        private string DeconstructJarFilePathFromArgumentList(string arguments)
        {
            var regex = new Regex("-jar\\s\"(.+)\"");
            var match = regex.Match(arguments);
            
            return match.Success ? match.Groups[1].Value : null;
        }

        public string Name { get; }
        public string JarFilePath { get; }
        public string JavaExecutablePath { get; }
        public SerializableImage Icon { get; }
    }
}