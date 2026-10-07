using System;
using System.Collections.Generic;
using MunicipalServicesApp.Models;

namespace MunicipalServicesApp.Services
{
    /// <summary>
    /// Central in-memory store for reported issues (Part 1).
    ///
    /// A List&lt;Issue&gt; is used because reports are added one at a time, are read back
    /// in the order they were captured, and the collection has no fixed size.
    ///
    /// The class is static so that both MainMenuForm and ReportIssueForm read and write
    /// the same collection and the same points total without passing references between forms.
    /// </summary>
    public static class IssueRepository
    {
        private static readonly List<Issue> _issues = new List<Issue>();
        private static int _totalPoints;
        private static int _referenceCounter = 1000;

        public static readonly List<string> Categories = new List<string>
        {
            "Roads and Potholes",
            "Water and Sanitation",
            "Electricity and Street Lighting",
            "Waste Removal",
            "Stormwater and Drainage",
            "Parks and Public Spaces",
            "Public Safety",
            "Other"
        };

        public static List<Issue> Issues
        {
            get { return _issues; }
        }

        public static int IssueCount
        {
            get { return _issues.Count; }
        }

        public static int TotalPoints
        {
            get { return _totalPoints; }
        }

        public static string GenerateReferenceNumber()
        {
            _referenceCounter++;
            return string.Format("MSA-{0}-{1}", DateTime.Now.Year, _referenceCounter);
        }

        public static void AddIssue(Issue issue)
        {
            if (issue == null)
            {
                throw new ArgumentNullException("issue");
            }

            issue.ReferenceNumber = GenerateReferenceNumber();
            issue.PointsAwarded = CalculatePoints(issue);

            _issues.Add(issue);
            _totalPoints += issue.PointsAwarded;
        }

        /// <summary>
        /// Points reward the completeness of one report rather than the number of reports
        /// submitted, so that volume is not rewarded over accuracy.
        /// </summary>
        public static int CalculatePoints(Issue issue)
        {
            int points = 10;

            if (!string.IsNullOrWhiteSpace(issue.Location) && issue.Location.Trim().Length >= 5)
            {
                points += 5;
            }

            if (!string.IsNullOrWhiteSpace(issue.Description) && issue.Description.Trim().Length >= 30)
            {
                points += 5;
            }

            if (issue.HasAttachment)
            {
                points += 5;
            }

            return points;
        }

        public static string GetEngagementLevel()
        {
            if (_totalPoints >= 100)
            {
                return "Community Champion";
            }
            if (_totalPoints >= 50)
            {
                return "Active Citizen";
            }
            if (_totalPoints > 0)
            {
                return "Community Contributor";
            }
            return "Newcomer";
        }

        public static int PointsToNextLevel()
        {
            if (_totalPoints >= 100)
            {
                return 0;
            }
            if (_totalPoints >= 50)
            {
                return 100 - _totalPoints;
            }
            return 50 - _totalPoints;
        }
    }
}
