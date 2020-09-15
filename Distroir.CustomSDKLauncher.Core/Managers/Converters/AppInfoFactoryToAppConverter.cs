using Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Factories;
using Distroir.CustomSDKLauncher.Core.Launchers.Editable;

namespace Distroir.CustomSDKLauncher.Core.Managers.Converters
{
    public class AppInfoFactoryToAppConverter : IConverter<IAppInfoFactory, ProducibleApp>
    {
        public ProducibleApp Convert(IAppInfoFactory input)
        {
            return new ProducibleApp(input);
        }

        public IAppInfoFactory Convert(ProducibleApp input)
        {
            return input.Factory;
        }
    }
}