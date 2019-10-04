/*
Custom SDK Launcher
Copyright (C) 2017-2019 Distroir

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
using Distroir.CustomSDKLauncher.Core.AppLauncher;
using Distroir.CustomSDKLauncher.Core.Launchers.View;

namespace Distroir.CustomSDKLauncher.Core.Launchers.Apps
{
    public class CustomizableApp : IApp
    {
        private readonly AppInfo _info;

        public IDisplayableItem DisplayableItem => new AppDependentDisplayableItem(_info);

        public CustomizableApp(AppInfo info)
        {
            _info = info;
        }

        public void Launch(Game associatedGame)
        {
            _info.Launch();
        }
    }
}
