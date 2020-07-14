using System;
using System.Collections.Generic;
using Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Factories;

namespace Distroir.CustomSDKLauncher.Core.Launchers.Editable
{
    public class ProducibleApp : IConfigurableApp
    {
        public ProducibleApp(IAppInfoFactory factory)
        {
            Factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }
        
        public IAppInfoFactory Factory { get; }
        public IDisplayableItem DisplayableItem => new ProducibleDisplayableItem(Factory);
        public void Launch(Game associatedGame)
        {
            Factory.GetInfo().Launch();
        }

        public List<Tuple<string, Func<bool>>> GetWaysToConfigure()
        {
            throw new NotImplementedException();
        }
    }
}