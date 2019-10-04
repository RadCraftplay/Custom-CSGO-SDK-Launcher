using Distroir.CustomSDKLauncher.Core.AppLauncher;
using Distroir.CustomSDKLauncher.Core.Launchers.View;

namespace Distroir.CustomSDKLauncher.Core.Launchers.Apps
{
    public class CustomizableApp : IApp
    {
        private readonly AppInfo _info;

        public IDisplayableItem DisplayableItem => new AppDependentDisplayableItem(_info);

        public CustomizableApp(AppInfo info)
        {
            _info = info;
        }

        public void Launch(Game associatedGame)
        {
            _info.Launch();
        }
    }
}
