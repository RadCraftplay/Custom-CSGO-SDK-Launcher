using Distroir.CustomSDKLauncher.Core.AppLauncher;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Distroir.CustomSDKLauncher.Core.Launchers.View
{
    class AppDependentDisplayableItem : IDisplayableItem
    {
        private readonly AppInfo _associatedInfo;

        public AppDependentDisplayableItem(AppInfo associatedInfo)
        {
            _associatedInfo = associatedInfo ?? throw new ArgumentNullException(nameof(associatedInfo));
        }

        public string Name => _associatedInfo.DisplayText;

        public Image Icon => _associatedInfo.Icon;
    }
}
