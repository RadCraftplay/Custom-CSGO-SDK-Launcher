using System.Drawing;
using Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher;

namespace Distroir.CustomSDKLauncher.Core.Launchers.Editable
{
    public class TemplateDependentDisplayableItem : IDisplayableItem
    {
        public AppTemplate AssociatedTemplate { get; }

        public TemplateDependentDisplayableItem(AppTemplate associatedTemplate)
        {
            AssociatedTemplate = associatedTemplate;
        }

        public string Name => AssociatedTemplate.Info.DisplayText;
        public Image Icon => AssociatedTemplate.Info.Icon;
    }
}