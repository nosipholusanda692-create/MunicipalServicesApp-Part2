using System;

namespace MunicipalServicesApp.Models
{
    /// <summary>
    /// A municipal announcement. Announcements are held in a Queue so that they are
    /// shown to the resident in the order the municipality published them (FIFO).
    /// </summary>
    public class Announcement
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime PostedOn { get; set; }

        public Announcement()
        {
            Title = string.Empty;
            Message = string.Empty;
            PostedOn = DateTime.Now;
        }

        public Announcement(string title, string message, DateTime postedOn)
        {
            Title = title;
            Message = message;
            PostedOn = postedOn;
        }

        public override string ToString()
        {
            return string.Format("{0} ({1:dd MMM yyyy})", Title, PostedOn);
        }
    }
}
