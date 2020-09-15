namespace Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Templates.Java.PathFinders
{
    public interface IJavaPathFinder
    {
        /// <summary>
        /// Returns path to java executable
        /// </summary>
        string Path { get; }
        
        /// <summary>
        /// Tests if executable can be found that way
        /// </summary>
        bool CanGetPath();
    }
}