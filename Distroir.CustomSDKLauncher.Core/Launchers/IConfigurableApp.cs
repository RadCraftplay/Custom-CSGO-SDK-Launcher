using System;
using System.Collections;
using System.Collections.Generic;

namespace Distroir.CustomSDKLauncher.Core.Launchers
{
    public interface IConfigurableApp : IApp
    {
        List<Tuple<string, Func<bool>>> GetWaysToConfigure();
    }
}