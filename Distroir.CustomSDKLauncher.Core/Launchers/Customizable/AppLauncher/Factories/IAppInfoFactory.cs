namespace Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Factories
{
    public interface IAppInfoFactory
    {
        AppInfo GetInfo();
        IAppInfoFactory Configure();
    }
}