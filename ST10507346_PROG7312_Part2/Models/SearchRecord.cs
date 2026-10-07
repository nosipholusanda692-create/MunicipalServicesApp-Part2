using System;

namespace MunicipalServicesApp.Models
{
    /// <summary>
    /// One search performed by the resident. Search records are pushed onto a Stack so
    /// that the most recent search is always the first one available (LIFO), and they
    /// are also aggregated into frequency dictionaries that drive the recommendations.
    /// </summary>
    public class SearchRecord
    {
        public string Keyword { get; set; }
        public string Category { get; set; }
        public DateTime SearchedAt { get; set; }
        public int ResultCount { get; set; }

        public SearchRecord()
        {
            Keyword = string.Empty;
            Category = string.Empty;
            SearchedAt = DateTime.Now;
        }

        public SearchRecord(string keyword, string category, int resultCount)
        {
            Keyword = string.IsNullOrWhiteSpace(keyword) ? string.Empty : keyword.Trim();
            Category = string.IsNullOrWhiteSpace(category) ? string.Empty : category.Trim();
            ResultCount = resultCount;
            SearchedAt = DateTime.Now;
        }

        /// <summary>
        /// A short description of the search, shown in the recent searches list.
        /// </summary>
        public string Summary
        {
            get
            {
                string what;

                if (Keyword.Length > 0 && Category.Length > 0)
                {
                    what = string.Format("\"{0}\" in {1}", Keyword, Category);
                }
                else if (Keyword.Length > 0)
                {
                    what = string.Format("\"{0}\"", Keyword);
                }
                else if (Category.Length > 0)
                {
                    what = Category;
                }
                else
                {
                    what = "all events";
                }

                return string.Format("{0:HH:mm}  {1}  ({2} found)", SearchedAt, what, ResultCount);
            }
        }
    }

    /// <summary>
    /// An event suggested to the resident, together with the score it was given and a
    /// plain-language reason that is shown in the interface.
    /// </summary>
    public class Recommendation
    {
        public LocalEvent Event { get; set; }
        public int Score { get; set; }
        public string Reason { get; set; }

        public Recommendation(LocalEvent localEvent, int score, string reason)
        {
            Event = localEvent;
            Score = score;
            Reason = reason;
        }
    }
}
