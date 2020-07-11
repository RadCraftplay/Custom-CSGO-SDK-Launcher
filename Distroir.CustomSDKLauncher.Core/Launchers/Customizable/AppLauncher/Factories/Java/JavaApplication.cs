using System;
using System.Drawing;

namespace Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Factories.Java
{
    public class JavaApplication
    {
        public JavaApplication(string name, string jarFilePath, string javaExecutablePath, Image icon)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            JarFilePath = jarFilePath ?? throw new ArgumentNullException(nameof(jarFilePath));
            JavaExecutablePath = javaExecutablePath ?? throw new ArgumentNullException(nameof(javaExecutablePath));
            Icon = icon ?? throw new ArgumentNullException(nameof(icon));
        }

        public string Name { get; }
        public string JarFilePath { get; }
        public string JavaExecutablePath { get; }
        public Image Icon { get; }
    }
}