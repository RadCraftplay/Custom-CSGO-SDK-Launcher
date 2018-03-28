using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Distroir.Configuration;

namespace Distroir.CustomSDKLauncher.Core.Feedback
{
    //TODO: Shedue showing message
    public class FeedbackFetcher
    {
        string FeedbackQuestion = "Would you like to answer few questions regarding Custom SDK Launcher?\nThis will take less than 5 minutes";
        string MessageTitle = "Feedback notification";
        string SurveyURL = "https://docs.google.com/forms/d/e/1FAIpQLScanK0_P7bHWM9RGHPirBvnIQp_3PoCqXufOz_-umPcPDuYnQ/viewform?usp=sf_link";
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

        void SendFeedback()
        {
            Utils.ShellLaunch(SurveyURL);
        }
    }
}
