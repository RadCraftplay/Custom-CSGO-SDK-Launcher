using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Distroir.CustomSDKLauncher.Core.Launchers.View
{
    class StandardDisplayableItem : IDisplayableItem
    {
        private readonly StandardSdkApplication _application;

        public StandardDisplayableItem(StandardSdkApplication application)
        {
            _application = application;
        }

        public string Name => GetApplicationName(_application);

        public Image Icon => GetApplicationIcon(_application);

        private string GetApplicationName(StandardSdkApplication application)
        {
            switch (application)
            {
                case StandardSdkApplication.Hammer:
                    return "Hammer World Editor";
                case StandardSdkApplication.HLMV:
                    return "Model Viewer";
                case StandardSdkApplication.FacePoser:
                    return "Face poser";
                default:
                    return string.Empty;
            }
        }

        private Image GetApplicationIcon(StandardSdkApplication application)
        {
            switch (application)
            {
                case StandardSdkApplication.Hammer:
                    return Data.HammerIcon;
                case StandardSdkApplication.HLMV:
                    return Data.ModelViewerIcon;
                case StandardSdkApplication.FacePoser:
                    return Data.FacePoserIcon;
                default:
                    return null;
            }
        }
    }
}
