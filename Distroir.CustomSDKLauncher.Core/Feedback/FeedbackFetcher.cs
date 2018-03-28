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

        /// <summary>
        /// Activates feedback fetcher
        /// </summary>
        public void Activate()
        {
            bool asked = false;

            //Check if user has been asked for feedback
            Config.TryReadBool("AskedForFeedback", out asked);

            //Show message
            if (!asked)
                ShowMessage();
        }

        void ShowMessage()
        {
            if (MessageBox.Show(FeedbackQuestion, MessageTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                SendFeedback();

            Config.AddVariable("AskedForFeedback", true);
        }

        void SendFeedback()
        {
            Utils.ShellLaunch(SurveyURL);
        }
    }
}
