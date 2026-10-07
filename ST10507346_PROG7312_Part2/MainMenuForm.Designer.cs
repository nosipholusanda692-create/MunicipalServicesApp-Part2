namespace MunicipalServicesApp
{
    partial class MainMenuForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnReportIssues = new System.Windows.Forms.Button();
            this.btnLocalEvents = new System.Windows.Forms.Button();
            this.btnServiceStatus = new System.Windows.Forms.Button();
            this.pnlEngagement = new System.Windows.Forms.Panel();
            this.lblNextLevel = new System.Windows.Forms.Label();
            this.lblLevelValue = new System.Windows.Forms.Label();
            this.lblLevelCaption = new System.Windows.Forms.Label();
            this.lblReportsValue = new System.Windows.Forms.Label();
            this.lblReportsCaption = new System.Windows.Forms.Label();
            this.lblPointsValue = new System.Windows.Forms.Label();
            this.lblPointsCaption = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblFooter = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.pnlHeader.SuspendLayout();
            this.pnlEngagement.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(66)))), ((int)(((byte)(94)))));
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(584, 92);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(202)))), ((int)(((byte)(222)))));
            this.lblSubtitle.Location = new System.Drawing.Point(29, 55);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(285, 17);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Report issues and follow their progress online";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(26, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(266, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Municipal Services";
            // 
            // btnReportIssues
            // 
            this.btnReportIssues.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReportIssues.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(66)))), ((int)(((byte)(94)))));
            this.btnReportIssues.FlatAppearance.BorderSize = 0;
            this.btnReportIssues.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportIssues.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F);
            this.btnReportIssues.ForeColor = System.Drawing.Color.White;
            this.btnReportIssues.Location = new System.Drawing.Point(60, 124);
            this.btnReportIssues.Name = "btnReportIssues";
            this.btnReportIssues.Size = new System.Drawing.Size(464, 52);
            this.btnReportIssues.TabIndex = 1;
            this.btnReportIssues.Text = "1.  Report an Issue";
            this.btnReportIssues.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportIssues.UseVisualStyleBackColor = false;
            this.btnReportIssues.Click += new System.EventHandler(this.btnReportIssues_Click);
            // 
            // btnLocalEvents
            // 
            this.btnLocalEvents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLocalEvents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(66)))), ((int)(((byte)(94)))));
            this.btnLocalEvents.FlatAppearance.BorderSize = 0;
            this.btnLocalEvents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocalEvents.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F);
            this.btnLocalEvents.ForeColor = System.Drawing.Color.White;
            this.btnLocalEvents.Location = new System.Drawing.Point(60, 186);
            this.btnLocalEvents.Name = "btnLocalEvents";
            this.btnLocalEvents.Size = new System.Drawing.Size(464, 52);
            this.btnLocalEvents.TabIndex = 2;
            this.btnLocalEvents.Text = "2.  Local Events and Announcements";
            this.btnLocalEvents.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLocalEvents.UseVisualStyleBackColor = false;
            this.btnLocalEvents.Click += new System.EventHandler(this.btnLocalEvents_Click);
            // 
            // btnServiceStatus
            // 
            this.btnServiceStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnServiceStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(237)))));
            this.btnServiceStatus.Enabled = false;
            this.btnServiceStatus.FlatAppearance.BorderSize = 0;
            this.btnServiceStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServiceStatus.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.btnServiceStatus.Location = new System.Drawing.Point(60, 248);
            this.btnServiceStatus.Name = "btnServiceStatus";
            this.btnServiceStatus.Size = new System.Drawing.Size(464, 52);
            this.btnServiceStatus.TabIndex = 3;
            this.btnServiceStatus.Text = "3.  Service Request Status     (coming soon)";
            this.btnServiceStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnServiceStatus.UseVisualStyleBackColor = false;
            // 
            // pnlEngagement
            // 
            this.pnlEngagement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlEngagement.BackColor = System.Drawing.Color.White;
            this.pnlEngagement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEngagement.Controls.Add(this.lblNextLevel);
            this.pnlEngagement.Controls.Add(this.lblLevelValue);
            this.pnlEngagement.Controls.Add(this.lblLevelCaption);
            this.pnlEngagement.Controls.Add(this.lblReportsValue);
            this.pnlEngagement.Controls.Add(this.lblReportsCaption);
            this.pnlEngagement.Controls.Add(this.lblPointsValue);
            this.pnlEngagement.Controls.Add(this.lblPointsCaption);
            this.pnlEngagement.Location = new System.Drawing.Point(60, 322);
            this.pnlEngagement.Name = "pnlEngagement";
            this.pnlEngagement.Size = new System.Drawing.Size(464, 104);
            this.pnlEngagement.TabIndex = 4;
            // 
            // lblNextLevel
            // 
            this.lblNextLevel.AutoSize = true;
            this.lblNextLevel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNextLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(122)))), ((int)(((byte)(134)))));
            this.lblNextLevel.Location = new System.Drawing.Point(26, 72);
            this.lblNextLevel.Name = "lblNextLevel";
            this.lblNextLevel.Size = new System.Drawing.Size(292, 15);
            this.lblNextLevel.TabIndex = 6;
            this.lblNextLevel.Text = "Report your first issue to start earning civic points.";
            // 
            // lblLevelValue
            // 
            this.lblLevelValue.AutoSize = true;
            this.lblLevelValue.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblLevelValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(66)))), ((int)(((byte)(94)))));
            this.lblLevelValue.Location = new System.Drawing.Point(266, 36);
            this.lblLevelValue.Name = "lblLevelValue";
            this.lblLevelValue.Size = new System.Drawing.Size(88, 21);
            this.lblLevelValue.TabIndex = 5;
            this.lblLevelValue.Text = "Newcomer";
            // 
            // lblLevelCaption
            // 
            this.lblLevelCaption.AutoSize = true;
            this.lblLevelCaption.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblLevelCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(122)))), ((int)(((byte)(134)))));
            this.lblLevelCaption.Location = new System.Drawing.Point(267, 18);
            this.lblLevelCaption.Name = "lblLevelCaption";
            this.lblLevelCaption.Size = new System.Drawing.Size(38, 13);
            this.lblLevelCaption.TabIndex = 4;
            this.lblLevelCaption.Text = "LEVEL";
            // 
            // lblReportsValue
            // 
            this.lblReportsValue.AutoSize = true;
            this.lblReportsValue.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblReportsValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(66)))), ((int)(((byte)(94)))));
            this.lblReportsValue.Location = new System.Drawing.Point(151, 36);
            this.lblReportsValue.Name = "lblReportsValue";
            this.lblReportsValue.Size = new System.Drawing.Size(18, 21);
            this.lblReportsValue.TabIndex = 3;
            this.lblReportsValue.Text = "0";
            // 
            // lblReportsCaption
            // 
            this.lblReportsCaption.AutoSize = true;
            this.lblReportsCaption.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblReportsCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(122)))), ((int)(((byte)(134)))));
            this.lblReportsCaption.Location = new System.Drawing.Point(152, 18);
            this.lblReportsCaption.Name = "lblReportsCaption";
            this.lblReportsCaption.Size = new System.Drawing.Size(56, 13);
            this.lblReportsCaption.TabIndex = 2;
            this.lblReportsCaption.Text = "REPORTS";
            // 
            // lblPointsValue
            // 
            this.lblPointsValue.AutoSize = true;
            this.lblPointsValue.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblPointsValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(66)))), ((int)(((byte)(94)))));
            this.lblPointsValue.Location = new System.Drawing.Point(25, 36);
            this.lblPointsValue.Name = "lblPointsValue";
            this.lblPointsValue.Size = new System.Drawing.Size(18, 21);
            this.lblPointsValue.TabIndex = 1;
            this.lblPointsValue.Text = "0";
            // 
            // lblPointsCaption
            // 
            this.lblPointsCaption.AutoSize = true;
            this.lblPointsCaption.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblPointsCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(122)))), ((int)(((byte)(134)))));
            this.lblPointsCaption.Location = new System.Drawing.Point(26, 18);
            this.lblPointsCaption.Name = "lblPointsCaption";
            this.lblPointsCaption.Size = new System.Drawing.Size(76, 13);
            this.lblPointsCaption.TabIndex = 0;
            this.lblPointsCaption.Text = "CIVIC POINTS";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.White;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(200)))), ((int)(((byte)(210)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnExit.Location = new System.Drawing.Point(424, 442);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 34);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblFooter
            // 
            this.lblFooter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFooter.AutoSize = true;
            this.lblFooter.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(140)))), ((int)(((byte)(150)))));
            this.lblFooter.Location = new System.Drawing.Point(57, 453);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(188, 13);
            this.lblFooter.TabIndex = 6;
            this.lblFooter.Text = "Option 3 is released in a later update.";
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(584, 501);
            this.Controls.Add(this.lblFooter);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.pnlEngagement);
            this.Controls.Add(this.btnServiceStatus);
            this.Controls.Add(this.btnLocalEvents);
            this.Controls.Add(this.btnReportIssues);
            this.Controls.Add(this.pnlHeader);
            this.MinimumSize = new System.Drawing.Size(600, 540);
            this.Name = "MainMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Municipal Services Application";
            this.Load += new System.EventHandler(this.MainMenuForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlEngagement.ResumeLayout(false);
            this.pnlEngagement.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnReportIssues;
        private System.Windows.Forms.Button btnLocalEvents;
        private System.Windows.Forms.Button btnServiceStatus;
        private System.Windows.Forms.Panel pnlEngagement;
        private System.Windows.Forms.Label lblPointsCaption;
        private System.Windows.Forms.Label lblPointsValue;
        private System.Windows.Forms.Label lblReportsCaption;
        private System.Windows.Forms.Label lblReportsValue;
        private System.Windows.Forms.Label lblLevelCaption;
        private System.Windows.Forms.Label lblLevelValue;
        private System.Windows.Forms.Label lblNextLevel;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblFooter;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
