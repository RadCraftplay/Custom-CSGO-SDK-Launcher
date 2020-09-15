using Distroir.CustomSDKLauncher.Core.Launchers.Customizable;
using Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher;

namespace Distroir.CustomSDKLauncher.Core.Managers.Converters
{
    public class AppTemplateToAppConverter : IConverter<AppInfo, CustomizableApp>
    {
        public AppInfo Convert(CustomizableApp input)
        {
            return input.Info;
        }

        public CustomizableApp Convert(AppInfo input)
        {
            return new CustomizableApp(input);
        }
    }
}