using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Distroir.CustomSDKLauncher.Core.Launchers.Apps;

namespace Distroir.CustomSDKLauncher.Core.Launchers
{
    public class StandardLauncher : Launcher
    {
        private readonly List<IApp> _apps;

        public override List<IApp> Apps => _apps;

        public StandardLauncher()
        {
            _apps = new List<IApp>()
            {
                new StandardApp(StandardSdkApplication.Hammer),
                new StandardApp(StandardSdkApplication.HLMV),
                new StandardApp(StandardSdkApplication.FacePoser)
            };
        }
    }
}
