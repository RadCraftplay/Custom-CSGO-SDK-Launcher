using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher;
using Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Dialogs;

namespace Distroir.CustomSDKLauncher.Core.Launchers.Editable
{
    public class TemplateDependentApp : IConfigurableApp
    {
        public AppTemplate Template { get; set; }
        public IDisplayableItem DisplayableItem => new TemplateDependentDisplayableItem(Template);

        public void Launch(Game associatedGame)
        {
            Template.Info.Launch();
        }

        public List<Tuple<string, Func<bool>>> GetWaysToConfigure()
        {
            return new List<Tuple<string, Func<bool>>>()
            {
                new Tuple<string, Func<bool>>("Edit", Template.Configure),
                new Tuple<string, Func<bool>>("Change type of an action", ChangeTypeOfAnAction)
            };
        }

        private bool ChangeTypeOfAnAction()
        {
            var dialog = new AppSelectorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Template = dialog.SelectedAppTemplate;
                return true;
            }

            return false;
        }
    }
}