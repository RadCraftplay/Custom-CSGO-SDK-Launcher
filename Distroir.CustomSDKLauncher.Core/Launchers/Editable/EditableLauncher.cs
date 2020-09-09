using System.Collections.Generic;
using System.Linq;
using Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Factories;
using Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Factories.Basic;
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
                {
                    if (!DataManagers.CustomizableApplicationInfo.TryLoad())
                    {
                        DataManagers.CustomizableApplicationInfo.Objects = GetStandardApps();
                        DataManagers.CustomizableApplicationInfo.Save();
                    }
                }

                return DataManagers.CustomizableApplicationInfo.Objects?
                    .Select(x => x as IApp).ToList();
            }
        }

        public override string Name => "Editable launcher (improved customizable launcher)";

        private List<ProducibleApp> GetStandardApps()
        {
            return new List<ProducibleApp>
            {
                new ProducibleApp(new BasicAppFactory(SdkApplication.Hammer)),
                new ProducibleApp(new BasicAppFactory(SdkApplication.HLMV)),
                new ProducibleApp(new BasicAppFactory(SdkApplication.FacePoser))
            };
        }
    }
}