/*
Custom SDK Launcher
Copyright (C) 2017-2020 Distroir

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
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
