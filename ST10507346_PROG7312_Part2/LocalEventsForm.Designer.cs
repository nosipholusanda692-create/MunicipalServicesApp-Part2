namespace MunicipalServicesApp
{
    partial class LocalEventsForm
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
            this.lblSubHeader = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblFrom = new System.Windows.Forms.Label();
            this.chkDateFilter = new System.Windows.Forms.CheckBox();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.lblKeyword = new System.Windows.Forms.Label();
            this.lblSearchCaption = new System.Windows.Forms.Label();
            this.lblResultsCaption = new System.Windows.Forms.Label();
            this.lvEvents = new System.Windows.Forms.ListView();
            this.colDate = new System.Windows.Forms.ColumnHeader();
            this.colTime = new System.Windows.Forms.ColumnHeader();
            this.colTitle = new System.Windows.Forms.ColumnHeader();
            this.colCategory = new System.Windows.Forms.ColumnHeader();
            this.colVenue = new System.Windows.Forms.ColumnHeader();
            this.lblDetailCaption = new System.Windows.Forms.Label();
            this.rtbDetail = new System.Windows.Forms.RichTextBox();
            this.lblRecCaption = new System.Windows.Forms.Label();
            this.lvRecommend = new System.Windows.Forms.ListView();
            this.colRecEvent = new System.Windows.Forms.ColumnHeader();
            this.colRecWhen = new System.Windows.Forms.ColumnHeader();
            this.lblRecReason = new System.Windows.Forms.Label();
            this.lblAnnCaption = new System.Windows.Forms.Label();
            this.lblAnnouncement = new System.Windows.Forms.Label();
            this.btnNextAnnouncement = new System.Windows.Forms.Button();
            this.lblRecentCaption = new System.Windows.Forms.Label();
            this.lstRecentSearches = new System.Windows.Forms.ListBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblStats = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.pnlHeader.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(66)))), ((int)(((byte)(94)))));
            this.pnlHeader.Controls.Add(this.lblSubHeader);
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1020, 76);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(24, 14);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(354, 30);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Local Events and Announcements";
            // 
            // lblSubHeader
            // 
            this.lblSubHeader.AutoSize = true;
            this.lblSubHeader.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblSubHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(202)))), ((int)(((byte)(222)))));
            this.lblSubHeader.Location = new System.Drawing.Point(26, 48);
            this.lblSubHeader.Name = "lblSubHeader";
            this.lblSubHeader.Size = new System.Drawing.Size(311, 17);
            this.lblSubHeader.TabIndex = 1;
            this.lblSubHeader.Text = "Find what is happening in your municipality";
            // 
            // pnlSearch
            // 
            this.pnlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSearch.BackColor = System.Drawing.Color.White;
            this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearch.Controls.Add(this.btnShowAll);
            this.pnlSearch.Controls.Add(this.btnClearSearch);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.dtpTo);
            this.pnlSearch.Controls.Add(this.lblTo);
            this.pnlSearch.Controls.Add(this.dtpFrom);
            this.pnlSearch.Controls.Add(this.lblFrom);
            this.pnlSearch.Controls.Add(this.chkDateFilter);
            this.pnlSearch.Controls.Add(this.cboCategory);
            this.pnlSearch.Controls.Add(this.lblCategory);
            this.pnlSearch.Controls.Add(this.txtKeyword);
            this.pnlSearch.Controls.Add(this.lblKeyword);
            this.pnlSearch.Controls.Add(this.lblSearchCaption);
            this.pnlSearch.Location = new System.Drawing.Point(24, 92);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(972, 124);
            this.pnlSearch.TabIndex = 1;
            // 
            // lblSearchCaption
            // 
            this.lblSearchCaption.AutoSize = true;
            this.lblSearchCaption.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblSearchCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(122)))), ((int)(((byte)(134)))));
            this.lblSearchCaption.Location = new System.Drawing.Point(18, 12);
            this.lblSearchCaption.Name = "lblSearchCaption";
            this.lblSearchCaption.Size = new System.Drawing.Size(80, 13);
            this.lblSearchCaption.TabIndex = 0;
            this.lblSearchCaption.Text = "FIND AN EVENT";
            // 
            // lblKeyword
            // 
            this.lblKeyword.AutoSize = true;
            this.lblKeyword.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblKeyword.Location = new System.Drawing.Point(18, 45);
            this.lblKeyword.Name = "lblKeyword";
            this.lblKeyword.Size = new System.Drawing.Size(61, 17);
            this.lblKeyword.TabIndex = 1;
            this.lblKeyword.Text = "Keyword";
            // 
            // txtKeyword
            // 
            this.txtKeyword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKeyword.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtKeyword.Location = new System.Drawing.Point(90, 42);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(230, 25);
            this.txtKeyword.TabIndex = 2;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblCategory.Location = new System.Drawing.Point(340, 45);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(60, 17);
            this.lblCategory.TabIndex = 3;
            this.lblCategory.Text = "Category";
            // 
            // cboCategory
            // 
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(410, 42);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(230, 25);
            this.cboCategory.TabIndex = 4;
            // 
            // chkDateFilter
            // 
            this.chkDateFilter.AutoSize = true;
            this.chkDateFilter.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.chkDateFilter.Location = new System.Drawing.Point(20, 86);
            this.chkDateFilter.Name = "chkDateFilter";
            this.chkDateFilter.Size = new System.Drawing.Size(140, 21);
            this.chkDateFilter.TabIndex = 5;
            this.chkDateFilter.Text = "Filter by date range";
            this.chkDateFilter.UseVisualStyleBackColor = true;
            this.chkDateFilter.CheckedChanged += new System.EventHandler(this.chkDateFilter_CheckedChanged);
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblFrom.Location = new System.Drawing.Point(180, 87);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(38, 17);
            this.lblFrom.TabIndex = 6;
            this.lblFrom.Text = "From";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Enabled = false;
            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(224, 84);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(130, 25);
            this.dtpFrom.TabIndex = 7;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblTo.Location = new System.Drawing.Point(370, 87);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(22, 17);
            this.lblTo.TabIndex = 8;
            this.lblTo.Text = "To";
            // 
            // dtpTo
            // 
            this.dtpTo.Enabled = false;
            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(398, 84);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(130, 25);
            this.dtpTo.TabIndex = 9;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(66)))), ((int)(((byte)(94)))));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(820, 40);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(132, 32);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearSearch.BackColor = System.Drawing.Color.White;
            this.btnClearSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(200)))), ((int)(((byte)(210)))));
            this.btnClearSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnClearSearch.Location = new System.Drawing.Point(676, 40);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(132, 32);
            this.btnClearSearch.TabIndex = 11;
            this.btnClearSearch.Text = "Clear";
            this.btnClearSearch.UseVisualStyleBackColor = false;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowAll.BackColor = System.Drawing.Color.White;
            this.btnShowAll.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(200)))), ((int)(((byte)(210)))));
            this.btnShowAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowAll.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnShowAll.Location = new System.Drawing.Point(676, 80);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(276, 30);
            this.btnShowAll.TabIndex = 12;
            this.btnShowAll.Text = "Show all upcoming events";
            this.btnShowAll.UseVisualStyleBackColor = false;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // lblResultsCaption
            // 
            this.lblResultsCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lblResultsCaption.AutoSize = true;
            this.lblResultsCaption.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblResultsCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(122)))), ((int)(((byte)(134)))));
            this.lblResultsCaption.Location = new System.Drawing.Point(24, 228);
            this.lblResultsCaption.Name = "lblResultsCaption";
            this.lblResultsCaption.Size = new System.Drawing.Size(114, 13);
            this.lblResultsCaption.TabIndex = 2;
            this.lblResultsCaption.Text = "UPCOMING EVENTS";
            // 
            // lvEvents
            // 
            this.lvEvents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvEvents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDate,
            this.colTime,
            this.colTitle,
            this.colCategory,
            this.colVenue});
            this.lvEvents.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lvEvents.FullRowSelect = true;
            this.lvEvents.GridLines = true;
            this.lvEvents.HideSelection = false;
            this.lvEvents.Location = new System.Drawing.Point(24, 248);
            this.lvEvents.MultiSelect = false;
            this.lvEvents.Name = "lvEvents";
            this.lvEvents.Size = new System.Drawing.Size(624, 300);
            this.lvEvents.TabIndex = 3;
            this.lvEvents.UseCompatibleStateImageBehavior = false;
            this.lvEvents.View = System.Windows.Forms.View.Details;
            this.lvEvents.SelectedIndexChanged += new System.EventHandler(this.lvEvents_SelectedIndexChanged);
            // 
            // colDate
            // 
            this.colDate.Text = "Date";
            this.colDate.Width = 100;
            // 
            // colTime
            // 
            this.colTime.Text = "Time";
            this.colTime.Width = 55;
            // 
            // colTitle
            // 
            this.colTitle.Text = "Event";
            this.colTitle.Width = 215;
            // 
            // colCategory
            // 
            this.colCategory.Text = "Category";
            this.colCategory.Width = 150;
            // 
            // colVenue
            // 
            this.colVenue.Text = "Venue";
            this.colVenue.Width = 180;
            // 
            // lblDetailCaption
            // 
            this.lblDetailCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDetailCaption.AutoSize = true;
            this.lblDetailCaption.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblDetailCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(122)))), ((int)(((byte)(134)))));
            this.lblDetailCaption.Location = new System.Drawing.Point(24, 558);
            this.lblDetailCaption.Name = "lblDetailCaption";
            this.lblDetailCaption.Size = new System.Drawing.Size(84, 13);
            this.lblDetailCaption.TabIndex = 4;
            this.lblDetailCaption.Text = "EVENT DETAILS";
            // 
            // rtbDetail
            // 
            this.rtbDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rtbDetail.BackColor = System.Drawing.Color.White;
            this.rtbDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbDetail.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.rtbDetail.Location = new System.Drawing.Point(24, 578);
            this.rtbDetail.Name = "rtbDetail";
            this.rtbDetail.ReadOnly = true;
            this.rtbDetail.Size = new System.Drawing.Size(624, 92);
            this.rtbDetail.TabIndex = 5;
            this.rtbDetail.Text = "Select an event from the list to read its full details.";
            // 
            // lblRecCaption
            // 
            this.lblRecCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRecCaption.AutoSize = true;
            this.lblRecCaption.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblRecCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(122)))), ((int)(((byte)(134)))));
            this.lblRecCaption.Location = new System.Drawing.Point(668, 228);
            this.lblRecCaption.Name = "lblRecCaption";
            this.lblRecCaption.Size = new System.Drawing.Size(151, 13);
            this.lblRecCaption.TabIndex = 6;
            this.lblRecCaption.Text = "RECOMMENDED FOR YOU";
            // 
            // lvRecommend
            // 
            this.lvRecommend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lvRecommend.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRecEvent,
            this.colRecWhen});
            this.lvRecommend.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lvRecommend.FullRowSelect = true;
            this.lvRecommend.GridLines = true;
            this.lvRecommend.HideSelection = false;
            this.lvRecommend.Location = new System.Drawing.Point(668, 248);
            this.lvRecommend.MultiSelect = false;
            this.lvRecommend.Name = "lvRecommend";
            this.lvRecommend.Size = new System.Drawing.Size(328, 150);
            this.lvRecommend.TabIndex = 7;
            this.lvRecommend.UseCompatibleStateImageBehavior = false;
            this.lvRecommend.View = System.Windows.Forms.View.Details;
            this.lvRecommend.SelectedIndexChanged += new System.EventHandler(this.lvRecommend_SelectedIndexChanged);
            // 
            // colRecEvent
            // 
            this.colRecEvent.Text = "Suggested event";
            this.colRecEvent.Width = 212;
            // 
            // colRecWhen
            // 
            this.colRecWhen.Text = "When";
            this.colRecWhen.Width = 92;
            // 
            // lblRecReason
            // 
            this.lblRecReason.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRecReason.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblRecReason.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(66)))), ((int)(((byte)(94)))));
            this.lblRecReason.Location = new System.Drawing.Point(668, 404);
            this.lblRecReason.Name = "lblRecReason";
            this.lblRecReason.Size = new System.Drawing.Size(328, 46);
            this.lblRecReason.TabIndex = 8;
            this.lblRecReason.Text = "Search for an event to receive personalised suggestions.";
            // 
            // lblAnnCaption
            // 
            this.lblAnnCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAnnCaption.AutoSize = true;
            this.lblAnnCaption.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblAnnCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(122)))), ((int)(((byte)(134)))));
            this.lblAnnCaption.Location = new System.Drawing.Point(668, 458);
            this.lblAnnCaption.Name = "lblAnnCaption";
            this.lblAnnCaption.Size = new System.Drawing.Size(99, 13);
            this.lblAnnCaption.TabIndex = 9;
            this.lblAnnCaption.Text = "ANNOUNCEMENTS";
            // 
            // lblAnnouncement
            // 
            this.lblAnnouncement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAnnouncement.BackColor = System.Drawing.Color.White;
            this.lblAnnouncement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAnnouncement.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAnnouncement.Location = new System.Drawing.Point(668, 478);
            this.lblAnnouncement.Name = "lblAnnouncement";
            this.lblAnnouncement.Padding = new System.Windows.Forms.Padding(8);
            this.lblAnnouncement.Size = new System.Drawing.Size(328, 80);
            this.lblAnnouncement.TabIndex = 10;
            this.lblAnnouncement.Text = "No announcements.";
            // 
            // btnNextAnnouncement
            // 
            this.btnNextAnnouncement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextAnnouncement.BackColor = System.Drawing.Color.White;
            this.btnNextAnnouncement.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(200)))), ((int)(((byte)(210)))));
            this.btnNextAnnouncement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextAnnouncement.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNextAnnouncement.Location = new System.Drawing.Point(668, 564);
            this.btnNextAnnouncement.Name = "btnNextAnnouncement";
            this.btnNextAnnouncement.Size = new System.Drawing.Size(170, 30);
            this.btnNextAnnouncement.TabIndex = 11;
            this.btnNextAnnouncement.Text = "Next announcement";
            this.btnNextAnnouncement.UseVisualStyleBackColor = false;
            this.btnNextAnnouncement.Click += new System.EventHandler(this.btnNextAnnouncement_Click);
            // 
            // lblRecentCaption
            // 
            this.lblRecentCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRecentCaption.AutoSize = true;
            this.lblRecentCaption.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblRecentCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(122)))), ((int)(((byte)(134)))));
            this.lblRecentCaption.Location = new System.Drawing.Point(668, 602);
            this.lblRecentCaption.Name = "lblRecentCaption";
            this.lblRecentCaption.Size = new System.Drawing.Size(185, 13);
            this.lblRecentCaption.TabIndex = 12;
            this.lblRecentCaption.Text = "RECENT SEARCHES (most recent first)";
            // 
            // lstRecentSearches
            // 
            this.lstRecentSearches.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lstRecentSearches.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstRecentSearches.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstRecentSearches.FormattingEnabled = true;
            this.lstRecentSearches.ItemHeight = 15;
            this.lstRecentSearches.Location = new System.Drawing.Point(668, 622);
            this.lstRecentSearches.Name = "lstRecentSearches";
            this.lstRecentSearches.Size = new System.Drawing.Size(328, 47);
            this.lstRecentSearches.TabIndex = 13;
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBack.BackColor = System.Drawing.Color.White;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(200)))), ((int)(((byte)(210)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnBack.Location = new System.Drawing.Point(24, 690);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(190, 40);
            this.btnBack.TabIndex = 14;
            this.btnBack.Text = "Back to Main Menu";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblStats
            // 
            this.lblStats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStats.AutoSize = true;
            this.lblStats.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblStats.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(140)))), ((int)(((byte)(150)))));
            this.lblStats.Location = new System.Drawing.Point(232, 703);
            this.lblStats.Name = "lblStats";
            this.lblStats.Size = new System.Drawing.Size(60, 13);
            this.lblStats.TabIndex = 15;
            this.lblStats.Text = "Loading...";
            // 
            // LocalEventsForm
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1020, 752);
            this.Controls.Add(this.lblStats);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lstRecentSearches);
            this.Controls.Add(this.lblRecentCaption);
            this.Controls.Add(this.btnNextAnnouncement);
            this.Controls.Add(this.lblAnnouncement);
            this.Controls.Add(this.lblAnnCaption);
            this.Controls.Add(this.lblRecReason);
            this.Controls.Add(this.lvRecommend);
            this.Controls.Add(this.lblRecCaption);
            this.Controls.Add(this.rtbDetail);
            this.Controls.Add(this.lblDetailCaption);
            this.Controls.Add(this.lvEvents);
            this.Controls.Add(this.lblResultsCaption);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlHeader);
            this.MinimumSize = new System.Drawing.Size(1036, 791);
            this.Name = "LocalEventsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Local Events and Announcements - Municipal Services Application";
            this.Load += new System.EventHandler(this.LocalEventsForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblSubHeader;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblSearchCaption;
        private System.Windows.Forms.Label lblKeyword;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.CheckBox chkDateFilter;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Label lblResultsCaption;
        private System.Windows.Forms.ListView lvEvents;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colTime;
        private System.Windows.Forms.ColumnHeader colTitle;
        private System.Windows.Forms.ColumnHeader colCategory;
        private System.Windows.Forms.ColumnHeader colVenue;
        private System.Windows.Forms.Label lblDetailCaption;
        private System.Windows.Forms.RichTextBox rtbDetail;
        private System.Windows.Forms.Label lblRecCaption;
        private System.Windows.Forms.ListView lvRecommend;
        private System.Windows.Forms.ColumnHeader colRecEvent;
        private System.Windows.Forms.ColumnHeader colRecWhen;
        private System.Windows.Forms.Label lblRecReason;
        private System.Windows.Forms.Label lblAnnCaption;
        private System.Windows.Forms.Label lblAnnouncement;
        private System.Windows.Forms.Button btnNextAnnouncement;
        private System.Windows.Forms.Label lblRecentCaption;
        private System.Windows.Forms.ListBox lstRecentSearches;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblStats;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
