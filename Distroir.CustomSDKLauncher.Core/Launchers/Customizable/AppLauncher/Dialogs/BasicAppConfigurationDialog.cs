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
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Factories.Basic;
using Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Templates;

namespace Distroir.CustomSDKLauncher.UI.Dialogs.AppLauncher
{
    public partial class BasicAppConfigurationDialog : Form
    {
        public SdkApplication SelectedApplication;

        public BasicAppConfigurationDialog()
        {
            InitializeComponent();
            Init(0);
        }

        public BasicAppConfigurationDialog(SdkApplication app)
        {
            InitializeComponent();
            Init((int)app);
        }

        void Init(int selectedId)
        {
            appComboBox.SelectedIndex = selectedId;
            SelectedApplication = (SdkApplication)selectedId;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            SelectedApplication = (SdkApplication)appComboBox.SelectedIndex;
            Close();
        }
    }
}
