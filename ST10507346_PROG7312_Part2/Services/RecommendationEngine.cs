using System;
using System.Collections.Generic;
using MunicipalServicesApp.DataStructures;
using MunicipalServicesApp.Models;

namespace MunicipalServicesApp.Services
{
    /// <summary>
    /// Produces event recommendations from the resident's search history.
    ///
    /// The approach is content-based filtering. Every upcoming event is given a score
    /// built from what the resident has searched for before, and the highest scoring
    /// events are returned.
    ///
    /// Scoring rules:
    ///   +5 per previous search in the same category
    ///   +4 when the event matches the category of the most recent search
    ///   +3 per searched keyword found in the title
    ///   +2 per searched keyword found in the description or venue
    ///   +3 when the event is within 7 days, +2 within 14 days, +1 within 30 days
    ///   -4 when the event is already visible in the current search results
    ///
    /// The scored events are pushed into a PriorityQueue ordered by score descending,
    /// which behaves as a max-heap, and the top items are dequeued. Using a heap rather
    /// than sorting the full list matters because only a handful of recommendations are
    /// displayed: building the heap is O(n) and each removal is O(log n), so taking the
    /// best five costs far less than an O(n log n) sort of everything.
    ///
    /// A HashSet is used to guarantee the same event is never suggested twice.
    /// </summary>
    public static class RecommendationEngine
    {
        private const int MaximumRecommendations = 5;

        public static List<Recommendation> Recommend(List<LocalEvent> currentResults)
        {
            List<Recommendation> scored = new List<Recommendation>();

            // Events already on screen are tracked in a set so they can be pushed down
            // the ranking. Set lookup is O(1), so this stays cheap inside the loop.
            HashSet<int> visibleEventIds = new HashSet<int>();

            if (currentResults != null)
            {
                foreach (LocalEvent visible in currentResults)
                {
                    visibleEventIds.Add(visible.Id);
                }
            }

            Dictionary<string, int> keywords = SearchHistoryService.GetKeywordFrequencies();
            SearchRecord latest = SearchHistoryService.MostRecent();
            string latestCategory = latest == null ? string.Empty : latest.Category;

            foreach (LocalEvent localEvent in EventRepository.GetAllInDateOrder())
            {
                if (!localEvent.IsUpcoming)
                {
                    continue;
                }

                int score = 0;
                List<string> reasons = new List<string>();

                // ----- Category interest -----
                int categoryScore = SearchHistoryService.GetCategoryScore(localEvent.Category);

                if (categoryScore > 0)
                {
                    score += categoryScore * 5;
                    reasons.Add(string.Format("you searched {0} {1} time{2}",
                        localEvent.Category, categoryScore, categoryScore == 1 ? string.Empty : "s"));
                }

                if (latestCategory.Length > 0 &&
                    string.Equals(latestCategory, localEvent.Category, StringComparison.OrdinalIgnoreCase))
                {
                    score += 4;
                }

                // ----- Keyword interest -----
                int keywordHits = 0;

                foreach (KeyValuePair<string, int> entry in keywords)
                {
                    string word = entry.Key;
                    int weight = entry.Value;

                    if (localEvent.Title.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        score += 3 * weight;
                        keywordHits++;
                    }
                    else if (localEvent.Description.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0
                        || localEvent.Venue.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        score += 2 * weight;
                        keywordHits++;
                    }
                }

                if (keywordHits > 0)
                {
                    reasons.Add(string.Format("matches {0} of your search term{1}",
                        keywordHits, keywordHits == 1 ? string.Empty : "s"));
                }

                // ----- How soon the event takes place -----
                int daysAway = localEvent.DaysAway;

                if (daysAway <= 7)
                {
                    score += 3;
                    reasons.Add("happening this week");
                }
                else if (daysAway <= 14)
                {
                    score += 2;
                }
                else if (daysAway <= 30)
                {
                    score += 1;
                }

                // ----- Already on screen -----
                if (visibleEventIds.Contains(localEvent.Id))
                {
                    score -= 4;
                }

                if (score <= 0)
                {
                    continue;
                }

                string reason = reasons.Count > 0
                    ? "Because " + string.Join(" and ", reasons.ToArray())
                    : "Related to your recent activity";

                scored.Add(new Recommendation(localEvent, score, reason));
            }

            // ----- Rank with the priority queue -----
            PriorityQueue<Recommendation> ranking =
                new PriorityQueue<Recommendation>(new RecommendationScoreComparer());

            foreach (Recommendation recommendation in scored)
            {
                ranking.Enqueue(recommendation);
            }

            // A set guards against the same event appearing twice in the final list.
            HashSet<int> alreadySuggested = new HashSet<int>();
            List<Recommendation> top = new List<Recommendation>();

            while (!ranking.IsEmpty && top.Count < MaximumRecommendations)
            {
                Recommendation next = ranking.Dequeue();

                if (alreadySuggested.Add(next.Event.Id))
                {
                    top.Add(next);
                }
            }

            return top;
        }

        /// <summary>
        /// Shown before the resident has searched for anything. The soonest events are
        /// suggested, taken from the repository's priority queue.
        /// </summary>
        public static List<Recommendation> DefaultSuggestions()
        {
            List<Recommendation> suggestions = new List<Recommendation>();

            foreach (LocalEvent localEvent in EventRepository.GetNextUpcoming(MaximumRecommendations))
            {
                suggestions.Add(new Recommendation(localEvent, 0,
                    "Happening soon. Search for an event to receive personalised suggestions."));
            }

            return suggestions;
        }
    }
}
