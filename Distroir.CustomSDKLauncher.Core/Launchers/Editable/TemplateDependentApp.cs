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

        public List<AppConfigurator> GetWaysToConfigure()
        {
            return new List<AppConfigurator>()
            {
                new AppConfigurator("Edit", (app) =>
                {
                    Template.Configure();
                    return this;
                }),
                new AppConfigurator("Change type of an action", Configure)
            };
        }

        private IApp Configure(IApp app)
        {
            if (!(app is ProducibleApp application))
                return this;
            
            var dialog = new AppSelectorDialog();
            return dialog.ShowDialog() == DialogResult.OK
                ? new TemplateDependentApp() {Template = dialog.SelectedAppTemplate}
                : this;
        }
    }
}