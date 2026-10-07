using System;
using System.IO;

namespace MunicipalServicesApp.Models
{
    /// <summary>
    /// Represents a single issue reported by a resident.
    /// Instances of this class are stored in the List&lt;Issue&gt; held by IssueRepository.
    /// </summary>
    public class Issue
    {
        public string ReferenceNumber { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string AttachmentPath { get; set; }
        public DateTime DateReported { get; set; }
        public int PointsAwarded { get; set; }
        public string Status { get; set; }

        public Issue()
        {
            DateReported = DateTime.Now;
            Status = "Submitted";
            ReferenceNumber = string.Empty;
            AttachmentPath = string.Empty;
        }

        public bool HasAttachment
        {
            get { return !string.IsNullOrEmpty(AttachmentPath); }
        }

        public string AttachmentFileName
        {
            get { return HasAttachment ? Path.GetFileName(AttachmentPath) : "No attachment"; }
        }

        public override string ToString()
        {
            return string.Format("{0} | {1} | {2} | {3:dd MMM yyyy HH:mm}",
                ReferenceNumber, Category, Location, DateReported);
        }
    }
}
