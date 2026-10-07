using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MunicipalServicesApp.Models;
using MunicipalServicesApp.Services;

namespace MunicipalServicesApp
{
    /// <summary>
    /// Displays local events and announcements, allows the resident to search the diary
    /// by keyword, category and date, and suggests related events based on what has
    /// been searched for before.
    /// </summary>
    public partial class LocalEventsForm : Form
    {
        private const string AllCategories = "All categories";

        private List<LocalEvent> _currentResults = new List<LocalEvent>();
        private List<Recommendation> _currentRecommendations = new List<Recommendation>();

        public LocalEventsForm()
        {
            InitializeComponent();
        }

        private void LocalEventsForm_Load(object sender, EventArgs e)
        {
            EventRepository.Initialise();

            LoadCategories();

            dtpFrom.Value = DateTime.Today;
            dtpTo.Value = DateTime.Today.AddMonths(2);

            toolTip.SetToolTip(txtKeyword, "Search the event title, description, venue and category.");
            toolTip.SetToolTip(cboCategory, "Narrow the results to a single category.");
            toolTip.SetToolTip(chkDateFilter, "Tick this to limit results to a date range.");
            toolTip.SetToolTip(btnNextAnnouncement, "Announcements are shown in the order the municipality published them.");

            ShowEvents(EventRepository.GetAllInDateOrder(), "UPCOMING EVENTS");
            ShowRecommendations(RecommendationEngine.DefaultSuggestions());
            ShowNextAnnouncement();
            RefreshRecentSearches();
            RefreshStats();
        }

        /// <summary>
        /// Fills the category dropdown from the set of distinct categories held by the
        /// repository. Because a HashSet cannot contain duplicates, no filtering is needed.
        /// </summary>
        private void LoadCategories()
        {
            cboCategory.Items.Clear();
            cboCategory.Items.Add(AllCategories);

            foreach (string category in EventRepository.GetCategories())
            {
                cboCategory.Items.Add(category);
            }

            cboCategory.SelectedIndex = 0;
        }

        private void chkDateFilter_CheckedChanged(object sender, EventArgs e)
        {
            dtpFrom.Enabled = chkDateFilter.Checked;
            dtpTo.Enabled = chkDateFilter.Checked;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtKeyword.Text.Trim();
            string category = SelectedCategory();

            DateTime? from = null;
            DateTime? to = null;

            if (chkDateFilter.Checked)
            {
                if (dtpFrom.Value.Date > dtpTo.Value.Date)
                {
                    MessageBox.Show(
                        "The start of the date range cannot be after the end of the range.",
                        "Check the dates",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                from = dtpFrom.Value.Date;
                to = dtpTo.Value.Date;
            }

            List<LocalEvent> results = EventRepository.Search(keyword, category, from, to);

            // The search is recorded before the recommendations are produced, so that the
            // search the resident has just performed influences what is suggested.
            SearchHistoryService.Record(new SearchRecord(keyword, category, results.Count));

            string caption = results.Count == 0
                ? "NO MATCHING EVENTS"
                : string.Format("SEARCH RESULTS ({0} found)", results.Count);

            ShowEvents(results, caption);

            if (results.Count == 0)
            {
                rtbDetail.Text =
                    "No events matched your search. Try a different keyword, widen the date range, " +
                    "or choose \"All categories\". The suggestions on the right may still be useful.";
            }

            ShowRecommendations(RecommendationEngine.Recommend(results));
            RefreshRecentSearches();
            RefreshStats();
        }

        private string SelectedCategory()
        {
            if (cboCategory.SelectedIndex <= 0)
            {
                return string.Empty;
            }

            return cboCategory.SelectedItem.ToString();
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtKeyword.Clear();
            cboCategory.SelectedIndex = 0;
            chkDateFilter.Checked = false;

            ShowEvents(EventRepository.GetAllInDateOrder(), "UPCOMING EVENTS");

            rtbDetail.Text = "Select an event from the list to read its full details.";

            // The history is kept, so the recommendations remain personalised.
            ShowRecommendations(SearchHistoryService.HasHistory
                ? RecommendationEngine.Recommend(_currentResults)
                : RecommendationEngine.DefaultSuggestions());

            RefreshStats();
            txtKeyword.Focus();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            ShowEvents(EventRepository.GetAllInDateOrder(), "UPCOMING EVENTS");
            RefreshStats();
        }

        /// <summary>
        /// Loads a list of events into the results ListView.
        /// </summary>
        private void ShowEvents(List<LocalEvent> events, string caption)
        {
            _currentResults = events ?? new List<LocalEvent>();

            lvEvents.BeginUpdate();
            lvEvents.Items.Clear();

            foreach (LocalEvent localEvent in _currentResults)
            {
                ListViewItem row = new ListViewItem(localEvent.Date.ToString("dd MMM yyyy"));
                row.SubItems.Add(localEvent.Date.ToString("HH:mm"));
                row.SubItems.Add(localEvent.Title);
                row.SubItems.Add(localEvent.Category);
                row.SubItems.Add(localEvent.Venue);
                row.Tag = localEvent;

                lvEvents.Items.Add(row);
            }

            lvEvents.EndUpdate();
            lblResultsCaption.Text = caption;
        }

        /// <summary>
        /// Loads recommendations into the suggestions ListView.
        /// </summary>
        private void ShowRecommendations(List<Recommendation> recommendations)
        {
            _currentRecommendations = recommendations ?? new List<Recommendation>();

            lvRecommend.BeginUpdate();
            lvRecommend.Items.Clear();

            foreach (Recommendation recommendation in _currentRecommendations)
            {
                ListViewItem row = new ListViewItem(recommendation.Event.Title);
                row.SubItems.Add(recommendation.Event.Date.ToString("dd MMM"));
                row.Tag = recommendation;

                lvRecommend.Items.Add(row);
            }

            lvRecommend.EndUpdate();

            if (_currentRecommendations.Count == 0)
            {
                lblRecReason.Text = "No suggestions yet. Search for an event to build your profile.";
            }
            else
            {
                lblRecReason.Text = EnsureSentence(_currentRecommendations[0].Reason);
            }
        }

        /// <summary>
        /// Adds a full stop only when the text does not already end with one, so that a
        /// reason which is already a complete sentence is not given a second full stop.
        /// </summary>
        private static string EnsureSentence(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return string.Empty;
            }

            string trimmed = text.TrimEnd();
            return trimmed.EndsWith(".") ? trimmed : trimmed + ".";
        }

        private void lvEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvEvents.SelectedItems.Count == 0)
            {
                return;
            }

            LocalEvent selected = lvEvents.SelectedItems[0].Tag as LocalEvent;

            if (selected == null)
            {
                return;
            }

            rtbDetail.Text = string.Format(
                "{0}{1}{2:dddd, dd MMMM yyyy} at {2:HH:mm}   |   {3}   |   {4}{1}{1}{5}",
                selected.Title,
                Environment.NewLine,
                selected.Date,
                selected.Category,
                selected.Venue,
                selected.Description);
        }

        private void lvRecommend_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvRecommend.SelectedItems.Count == 0)
            {
                return;
            }

            Recommendation selected = lvRecommend.SelectedItems[0].Tag as Recommendation;

            if (selected == null)
            {
                return;
            }

            lblRecReason.Text = EnsureSentence(selected.Reason);

            rtbDetail.Text = string.Format(
                            "{0}{1}{2:dddd, dd MMMM yyyy} at {2:HH:mm}   |   {3}   |   {4}{1}{1}{5}{1}{1}{6}",
                selected.Event.Title,
                Environment.NewLine,
                selected.Event.Date,
                selected.Event.Category,
                selected.Event.Venue,
                selected.Event.Description,
                EnsureSentence(selected.Reason));
        }

        /// <summary>
        /// Takes the next announcement from the front of the queue and displays it.
        /// </summary>
        private void ShowNextAnnouncement()
        {
            Announcement announcement = EventRepository.NextAnnouncement();

            if (announcement == null)
            {
                lblAnnouncement.Text = "There are no announcements at this time.";
                return;
            }

            lblAnnouncement.Text = string.Format("{0}{1}{2}{1}{1}Posted {3:dd MMM yyyy}",
                announcement.Title,
                Environment.NewLine,
                announcement.Message,
                announcement.PostedOn);
        }

        private void btnNextAnnouncement_Click(object sender, EventArgs e)
        {
            ShowNextAnnouncement();
        }

        /// <summary>
        /// Refreshes the recent searches list from the stack. Enumerating a stack walks
        /// from the top downwards, so the newest search appears first without reversing.
        /// </summary>
        private void RefreshRecentSearches()
        {
            lstRecentSearches.BeginUpdate();
            lstRecentSearches.Items.Clear();

            foreach (SearchRecord record in SearchHistoryService.GetRecent(10))
            {
                lstRecentSearches.Items.Add(record.Summary);
            }

            lstRecentSearches.EndUpdate();
        }

        private void RefreshStats()
        {
            string favourite = SearchHistoryService.FavouriteCategory();

            lblStats.Text = string.Format(
                "{0} events  |  {1} categories  |  {2} event dates  |  {3} searches this session{4}",
                EventRepository.EventCount,
                EventRepository.CategoryCount,
                EventRepository.DateCount,
                SearchHistoryService.SearchCount,
                favourite.Length > 0 ? "  |  most searched: " + favourite : string.Empty);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
