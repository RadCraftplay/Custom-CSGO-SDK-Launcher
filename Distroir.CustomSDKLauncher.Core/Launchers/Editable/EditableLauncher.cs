using System.Collections.Generic;
using Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Templates;
using Distroir.CustomSDKLauncher.Core.Managers;

namespace Distroir.CustomSDKLauncher.Core.Launchers.Editable
{
    public class EditableLauncher : Launcher
    {
        public override List<IApp> Apps
        {
            get
            {
                if (DataManagers.CustomizableApplicationInfo.Objects?.Count == 0)
                    if (!DataManagers.CustomizableApplicationInfo.TryLoad())
                        DataManagers.CustomizableApplicationInfo.Objects = GetStandardApps();
                
                return DataManagers.CustomizableApplicationInfo.Objects;
            }
        }

        private List<IApp> GetStandardApps()
        {
            return new List<IApp>
            {
                new TemplateDependentApp() {Template = new BasicAppTemplate(){Application = Customizable.AppLauncher.Templates.SDKApplication.Hammer}},
                new TemplateDependentApp() {Template = new BasicAppTemplate(){Application = Customizable.AppLauncher.Templates.SDKApplication.HLMV}},
                new TemplateDependentApp() {Template = new BasicAppTemplate(){Application = Customizable.AppLauncher.Templates.SDKApplication.FacePoser}}
            };
        }
    }
}