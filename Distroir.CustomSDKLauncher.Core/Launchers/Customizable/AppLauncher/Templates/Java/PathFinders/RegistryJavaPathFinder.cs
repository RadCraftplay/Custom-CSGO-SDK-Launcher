namespace Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Templates.Java.PathFinders
{
    public class RegistryJavaPathFinder : IJavaPathFinder
    {
        public string Path { get; private set; }
        public bool CanGetPath()
        {
            return Utilities.JavaUtils.TryGetJavaHomePath(out string Path);
        }
    }
}