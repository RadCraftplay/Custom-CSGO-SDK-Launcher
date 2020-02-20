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
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Distroir.CustomSDKLauncher.Core.Utilities
{
    public class MessageBoxes
    {
        public static void Error(string Message)
        {
            MessageBox.Show(Message, "Custom SDK Launcher", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void Error(string Message, Exception ex)
        {
            MessageBox.Show(Message + "\nMessage: " + ex.Message, "Custom SDK Launcher", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //Log an exception
            ExceptionLogger.Log(ex);
        }

        public static void Info(string message)
        {
            MessageBox.Show(message, "Custom SDK Launcher", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Warning(string Message)
        {
            MessageBox.Show(Message, "Custom SDK Launcher", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static DialogResult Warning(string Message, MessageBoxButtons buttons)
        {
            return MessageBox.Show(Message, "Custom SDK Launcher", buttons, MessageBoxIcon.Warning);
        }
    }
}
