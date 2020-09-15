using System.Drawing;
using Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Factories;

namespace Distroir.CustomSDKLauncher.Core.Launchers.Editable
{
    public class ProducibleDisplayableItem : IDisplayableItem
    {
        private readonly IAppInfoFactory _factory;
        
        public ProducibleDisplayableItem(IAppInfoFactory factory)
        {
            _factory = factory;
        }

        public string Name => _factory.GetInfo().DisplayText;
        public Image Icon => _factory.GetInfo().Icon;
    }
}