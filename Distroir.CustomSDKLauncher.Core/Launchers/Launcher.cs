using Distroir.CustomSDKLauncher.Core.Launchers.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Distroir.CustomSDKLauncher.Core.Launchers
{
    public abstract class Launcher
    {
        public abstract List<IDisplayableItem> DisplayableItems { get; }

        public abstract void Launch(int appId);
    }
}
