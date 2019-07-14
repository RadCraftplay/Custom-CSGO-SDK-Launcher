using Distroir.CustomSDKLauncher.Shared.Core;
using System.Windows.Forms;

namespace Distroir.CustomSDKLauncher.Shared.UI
{
    public partial class HelpDialog : Form
    {
        public HelpDialog(HelpTopic topic)
        {
            InitializeComponent();
            UpdateUI(topic);
        }

        private void UpdateUI(HelpTopic topic)
        {
            topicNameLabel.Text = topic.Name;
            topicTextRichTextBox.Text = topic.Text;
        }
    }
}
