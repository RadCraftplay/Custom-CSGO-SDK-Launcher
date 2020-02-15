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
using Distroir.Configuration;
using Distroir.CustomSDKLauncher.Core.Utilities;

namespace Distroir.CustomSDKLauncher.Core.Feedback
{
    //TODO: Shedue showing message
    public class FeedbackFetcher
    {
        string FeedbackQuestion = "Would you like to answer few questions regarding Custom SDK Launcher?\nThis will take less than 5 minutes";
        string MessageTitle = "Feedback notification";
        static string SurveyURL = "https://docs.google.com/forms/d/e/1FAIpQLScanK0_P7bHWM9RGHPirBvnIQp_3PoCqXufOz_-umPcPDuYnQ/viewform?usp=sf_link";
        TimeSpan feedbackDelay = TimeSpan.FromDays(60);

        /// <summary>
        /// Activates feedback fetcher
        /// </summary>
        public void Activate()
        {
            string lastFetchDate = string.Empty;

            Scheduler s = new Scheduler(feedbackDelay);

            //Try to get date of previous fetch
            if (!Config.TryReadString("LastFeedbackFetchDate", out lastFetchDate))
            {
                //If variable does not exist, reset date
                ResetDate(out lastFetchDate);
                return;
            }

            //Check if time passed
            if (s.Check(lastFetchDate))
            {
                //Show message
                ShowMessage();
                //Reset date
                ResetDate();
            }
        }

        /// <summary>
        /// Resets last fetch date to actual date on machine
        /// </summary>
        void ResetDate(out string fetchDate)
        {
            fetchDate = DateSerializer.SerializeDate(DateTime.Now);
            Config.AddVariable("LastFeedbackFetchDate", fetchDate);
        }

        /// <summary>
        /// Resets last fetch date to actual date on machine
        /// </summary>
        public void ResetDate()
        {
            Config.AddVariable("LastFeedbackFetchDate", DateSerializer.SerializeDate(DateTime.Now));
        }

        /// <summary>
        /// Ask user to participate
        /// </summary>
        void ShowMessage()
        {
            if (MessageBox.Show(FeedbackQuestion, MessageTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                SendFeedback();
        }

        public static void SendFeedback()
        {
            Utils.ShellLaunch(SurveyURL);
        }
    }
}
