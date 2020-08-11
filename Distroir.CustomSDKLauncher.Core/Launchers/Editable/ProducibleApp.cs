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

        public List<Tuple<string, Func<bool>>> GetWaysToConfigure()
        {
            return new List<Tuple<string, Func<bool>>>()
            {
                new Tuple<string, Func<bool>>("Edit...", () => Factory.Configure()),
                new Tuple<string, Func<bool>>("Change type of an action...", ChangeTypeOfAnAction)
            };
        }
        
        private bool ChangeTypeOfAnAction()
        {
            var dialog = new AppSelectorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Factory = dialog.SelectedAppFactory;
                return true;
            }

            return false;
        }
    }
}