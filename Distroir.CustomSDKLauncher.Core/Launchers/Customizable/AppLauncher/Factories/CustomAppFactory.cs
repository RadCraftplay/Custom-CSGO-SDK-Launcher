namespace Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Factories
{
    public class CustomAppFactory : IAppInfoFactory
    {
        public CustomAppFactory(AppInfo info)
        {
            Info = info;
        }

        public AppInfo Info { get; }

        public AppInfo GetInfo()
        {
            return Info;
        }
    }
}