using System;
using Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher;

namespace Distroir.CustomSDKLauncher.Core.Launchers.Editable
{
    public class TemplateDependentApp : IApp
    {
        public AppTemplate Template { get; set; }
        public IDisplayableItem DisplayableItem => new TemplateDependentDisplayableItem(Template);
        public void Launch(Game associatedGame)
        {
            Template.Info.Launch();
        }
    }
}