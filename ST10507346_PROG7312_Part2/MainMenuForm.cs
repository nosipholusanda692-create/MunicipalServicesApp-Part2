using System;
using System.Windows.Forms;
using MunicipalServicesApp.Services;

namespace MunicipalServicesApp
{
    /// <summary>
    /// The first form shown on startup. It presents the three tasks required by the
    /// specification and displays the resident's running civic points total, which is
    /// the visible half of the gamification engagement strategy introduced in Part 1.
    ///
    /// In Part 2 the Local Events and Announcements option is enabled. Service Request
    /// Status remains disabled until Part 3.
    /// </summary>
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            toolTip.SetToolTip(btnReportIssues, "Report a municipal issue in your area.");
            toolTip.SetToolTip(btnLocalEvents, "Browse and search local events and municipal announcements.");
            toolTip.SetToolTip(btnServiceStatus, "This feature is released in a later version of the application.");

            RefreshEngagementPanel();
        }

        /// <summary>
        /// Updates the civic points, report count and level shown on the main menu.
        /// Called on load and again each time the resident returns from another form.
        /// </summary>
        private void RefreshEngagementPanel()
        {
            lblPointsValue.Text = IssueRepository.TotalPoints.ToString();
            lblReportsValue.Text = IssueRepository.IssueCount.ToString();
            lblLevelValue.Text = IssueRepository.GetEngagementLevel();

            if (IssueRepository.IssueCount == 0)
            {
                lblNextLevel.Text = "Report your first issue to start earning civic points.";
            }
            else
            {
                int needed = IssueRepository.PointsToNextLevel();

                if (needed == 0)
                {
                    lblNextLevel.Text = "You have reached the highest level. Thank you for your contribution.";
                }
                else
                {
                    lblNextLevel.Text = string.Format(
                        "{0} more point{1} until your next level.",
                        needed,
                        needed == 1 ? string.Empty : "s");
                }
            }
        }

        private void btnReportIssues_Click(object sender, EventArgs e)
        {
            this.Hide();

            using (ReportIssueForm reportForm = new ReportIssueForm())
            {
                reportForm.ShowDialog(this);
            }

            this.Show();
            RefreshEngagementPanel();
        }

        private void btnLocalEvents_Click(object sender, EventArgs e)
        {
            this.Hide();

            using (LocalEventsForm eventsForm = new LocalEventsForm())
            {
                eventsForm.ShowDialog(this);
            }

            this.Show();
            RefreshEngagementPanel();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to close the Municipal Services Application?",
                "Confirm exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
