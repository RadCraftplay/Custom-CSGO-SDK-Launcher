using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Dialogs;
using Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Factories;

namespace Distroir.CustomSDKLauncher.Core.Launchers.Editable
{
    public class ProducibleApp : IConfigurableApp
    {
        public ProducibleApp(IAppInfoFactory factory)
        {
            Factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }
        
        public IAppInfoFactory Factory { get; private set; }
        public IDisplayableItem DisplayableItem => new ProducibleDisplayableItem(Factory);
        public void Launch(Game associatedGame)
        {
            Factory.GetInfo().Launch();
        }

        public List<AppConfigurator> GetWaysToConfigure()
        {
            return new List<AppConfigurator>()
            {
                new AppConfigurator("Edit...", (app) => new ProducibleApp(Factory.Configure())),
                new AppConfigurator("Change type of an action...", Configure)
            };
        }
        
        private IApp Configure(IApp app)
        {
            if (!(app is ProducibleApp application))
                return this;
            
            var dialog = new AppSelectorDialog();
            return dialog.ShowDialog() == DialogResult.OK ? new ProducibleApp(dialog.SelectedAppFactory) : this;
        }
    }
}