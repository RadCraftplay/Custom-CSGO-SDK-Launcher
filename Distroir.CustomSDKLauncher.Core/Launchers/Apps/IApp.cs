using Distroir.CustomSDKLauncher.Core.Launchers.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Distroir.CustomSDKLauncher.Core.Launchers.Apps
{
    public interface IApp
    {
        IDisplayableItem DisplayableItem { get; }
        void Launch(Game associatedGame);
    }
}
