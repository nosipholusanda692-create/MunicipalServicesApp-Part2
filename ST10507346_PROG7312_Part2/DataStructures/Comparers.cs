using System.Collections.Generic;
using MunicipalServicesApp.Models;

namespace MunicipalServicesApp.DataStructures
{
    /// <summary>
    /// Orders events by date, soonest first. Used with the PriorityQueue to build a
    /// min-heap so that the next event to take place is always at the root.
    /// </summary>
    public class EventDateComparer : IComparer<LocalEvent>
    {
        public int Compare(LocalEvent first, LocalEvent second)
        {
            if (first == null && second == null)
            {
                return 0;
            }
            if (first == null)
            {
                return 1;
            }
            if (second == null)
            {
                return -1;
            }

            int byDate = first.Date.CompareTo(second.Date);

            // Events at the same date and time are ordered alphabetically so the
            // result is predictable rather than dependent on insertion order.
            return byDate != 0 ? byDate : string.CompareOrdinal(first.Title, second.Title);
        }
    }

    /// <summary>
    /// Orders recommendations by score, highest first. The comparison is reversed so
    /// that the same min-heap implementation behaves as a max-heap, which means the
    /// best scoring recommendation is always dequeued first.
    /// </summary>
    public class RecommendationScoreComparer : IComparer<Recommendation>
    {
        public int Compare(Recommendation first, Recommendation second)
        {
            if (first == null && second == null)
            {
                return 0;
            }
            if (first == null)
            {
                return 1;
            }
            if (second == null)
            {
                return -1;
            }

            // Reversed: a higher score must compare as "smaller" to reach the root.
            int byScore = second.Score.CompareTo(first.Score);

            if (byScore != 0)
            {
                return byScore;
            }

            // Equal scores are broken by whichever event happens sooner.
            return first.Event.Date.CompareTo(second.Event.Date);
        }
    }
}
