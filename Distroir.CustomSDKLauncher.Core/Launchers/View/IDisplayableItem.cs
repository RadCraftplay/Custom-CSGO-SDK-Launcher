using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Distroir.CustomSDKLauncher.Core.Launchers.View
{
    public interface IDisplayableItem
    {
        string Name { get; }
        Image Icon { get; }
    }
}
