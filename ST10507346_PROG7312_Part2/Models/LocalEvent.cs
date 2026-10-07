using System;

namespace MunicipalServicesApp.Models
{
    /// <summary>
    /// Represents a single local event or municipal activity.
    /// The class is named LocalEvent rather than Event because "event" is a C# keyword.
    /// </summary>
    public class LocalEvent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public string Venue { get; set; }
        public string Description { get; set; }

        public LocalEvent()
        {
            Title = string.Empty;
            Category = string.Empty;
            Venue = string.Empty;
            Description = string.Empty;
        }

        public LocalEvent(int id, string title, string category, DateTime date, string venue, string description)
        {
            Id = id;
            Title = title;
            Category = category;
            Date = date;
            Venue = venue;
            Description = description;
        }

        /// <summary>
        /// The date without the time component. Used as the key in the SortedDictionary
        /// so that every event on the same calendar day groups together.
        /// </summary>
        public DateTime DateOnly
        {
            get { return Date.Date; }
        }

        /// <summary>
        /// Whole days between today and the event. Negative for events already past.
        /// Used by the recommendation engine to favour events happening sooner.
        /// </summary>
        public int DaysAway
        {
            get { return (int)(Date.Date - DateTime.Today).TotalDays; }
        }

        public bool IsUpcoming
        {
            get { return Date.Date >= DateTime.Today; }
        }

        public override string ToString()
        {
            return string.Format("{0:dd MMM yyyy HH:mm} - {1} ({2})", Date, Title, Category);
        }
    }
}
