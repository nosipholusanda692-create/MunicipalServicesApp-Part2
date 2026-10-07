using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MunicipalServicesApp.Models;
using MunicipalServicesApp.Services;

namespace MunicipalServicesApp
{
    /// <summary>
    /// Captures a single issue report from a resident (Part 1).
    ///
    /// The gamification engagement strategy is implemented here in two visible parts:
    /// a ProgressBar that advances as each part of the report is completed, and a Label
    /// that changes its message to encourage the resident towards the next step.
    /// </summary>
    public partial class ReportIssueForm : Form
    {
        private const int MinimumDescriptionLength = 10;

        private string _attachmentPath = string.Empty;

        public ReportIssueForm()
        {
            InitializeComponent();
        }

        private void ReportIssueForm_Load(object sender, EventArgs e)
        {
            // Items.Add is used rather than DataSource because a data-bound ComboBox does
            // not reliably return to an unselected state when the form is cleared.
            cboCategory.Items.Clear();

            foreach (string category in IssueRepository.Categories)
            {
                cboCategory.Items.Add(category);
            }

            cboCategory.SelectedIndex = -1;

            toolTip.SetToolTip(txtLocation, "For example: 12 Church Street, Sunnyside, or the corner of Main and 5th.");
            toolTip.SetToolTip(btnAttach, "Attaching a photo helps the municipal team locate and assess the issue.");
            toolTip.SetToolTip(btnSubmit, "Submit this report and earn civic points.");

            UpdateEngagement();
        }

        private void InputChanged(object sender, EventArgs e)
        {
            UpdateEngagement();
        }

        /// <summary>
        /// Counts how many of the four parts of a report have been completed and updates
        /// the progress bar and encouragement message accordingly.
        /// </summary>
        private void UpdateEngagement()
        {
            int completedSteps = 0;

            if (!string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                completedSteps++;
            }

            if (cboCategory.SelectedIndex >= 0)
            {
                completedSteps++;
            }

            if (rtbDescription.Text.Trim().Length >= MinimumDescriptionLength)
            {
                completedSteps++;
            }

            if (!string.IsNullOrEmpty(_attachmentPath))
            {
                completedSteps++;
            }

            prgCompletion.Value = completedSteps * 25;
            lblEngagementMessage.Text = GetEncouragementMessage(completedSteps);
            lblEngagementCaption.Text = string.Format("REPORT COMPLETENESS  -  {0}%", prgCompletion.Value);
        }

        private string GetEncouragementMessage(int completedSteps)
        {
            switch (completedSteps)
            {
                case 0:
                    return "Start by telling us where the problem is.";
                case 1:
                    return "Good start. Now choose the category that fits best.";
                case 2:
                    return "Halfway there. Describe the issue in your own words.";
                case 3:
                    return "Almost done. Add a photo to help the team find it faster.";
                default:
                    return "Your report is complete. Submit it to earn your civic points.";
            }
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Attach a photo or document";
                dialog.Filter =
                    "Images (*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif|" +
                    "Documents (*.pdf;*.doc;*.docx;*.txt)|*.pdf;*.doc;*.docx;*.txt|" +
                    "All files (*.*)|*.*";
                dialog.Multiselect = false;
                dialog.CheckFileExists = true;

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        FileInfo info = new FileInfo(dialog.FileName);

                        const long maximumBytes = 10 * 1024 * 1024;

                        if (info.Length > maximumBytes)
                        {
                            MessageBox.Show(
                                "That file is larger than 10 MB. Please attach a smaller file.",
                                "File too large",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }

                        _attachmentPath = dialog.FileName;

                        lblAttachment.Text = string.Format("Attached: {0} ({1} KB)",
                            info.Name, Math.Max(1, info.Length / 1024));
                        lblAttachment.ForeColor = Color.FromArgb(20, 66, 94);
                        lblAttachment.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

                        btnAttach.Text = "Change attachment";

                        UpdateEngagement();
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show(
                            "The file could not be read: " + ex.Message,
                            "Attachment error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        MessageBox.Show(
                            "You do not have permission to open that file.",
                            "Attachment error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!ValidateReport())
            {
                return;
            }

            Issue issue = new Issue
            {
                Location = txtLocation.Text.Trim(),
                Category = cboCategory.SelectedItem.ToString(),
                Description = rtbDescription.Text.Trim(),
                AttachmentPath = _attachmentPath
            };

            IssueRepository.AddIssue(issue);

            string message = string.Format(
                "Thank you. Your report has been submitted.{0}{0}" +
                "Reference number: {1}{0}" +
                "Category: {2}{0}" +
                "Attachment: {3}{0}{0}" +
                "You earned {4} civic points for this report.{0}" +
                "Your total is now {5} points ({6}).",
                Environment.NewLine,
                issue.ReferenceNumber,
                issue.Category,
                issue.AttachmentFileName,
                issue.PointsAwarded,
                IssueRepository.TotalPoints,
                IssueRepository.GetEngagementLevel());

            MessageBox.Show(message, "Report submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ResetForm();
        }

        private bool ValidateReport()
        {
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show(
                    "Please enter the location of the issue so the municipal team can find it.",
                    "Location required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtLocation.Focus();
                return false;
            }

            if (cboCategory.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Please select the category that best describes the issue.",
                    "Category required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                cboCategory.Focus();
                return false;
            }

            if (rtbDescription.Text.Trim().Length < MinimumDescriptionLength)
            {
                MessageBox.Show(
                    string.Format(
                        "Please describe the issue in at least {0} characters so the report can be assessed.",
                        MinimumDescriptionLength),
                    "Description required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                rtbDescription.Focus();
                return false;
            }

            return true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "Clear everything you have entered on this form?",
                "Confirm clear",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                ResetForm();
            }
        }

        private void ResetForm()
        {
            txtLocation.Clear();
            cboCategory.SelectedIndex = -1;
            rtbDescription.Clear();

            _attachmentPath = string.Empty;
            lblAttachment.Text = "No file attached (optional)";
            lblAttachment.ForeColor = Color.FromArgb(110, 122, 134);
            lblAttachment.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            btnAttach.Text = "Attach photo or document";

            UpdateEngagement();
            txtLocation.Focus();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            bool hasUnsavedInput =
                !string.IsNullOrWhiteSpace(txtLocation.Text) ||
                cboCategory.SelectedIndex >= 0 ||
                rtbDescription.Text.Trim().Length > 0 ||
                !string.IsNullOrEmpty(_attachmentPath);

            if (hasUnsavedInput)
            {
                DialogResult confirm = MessageBox.Show(
                    "This report has not been submitted. Return to the main menu and discard it?",
                    "Discard report",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm == DialogResult.No)
                {
                    return;
                }
            }

            this.Close();
        }
    }
}
