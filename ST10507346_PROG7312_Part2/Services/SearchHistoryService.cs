using System;
using System.Collections.Generic;
using System.Linq;
using MunicipalServicesApp.Models;

namespace MunicipalServicesApp.Services
{
    /// <summary>
    /// Records what the resident searches for, which is the input to the recommendation feature.
    ///
    ///   Stack&lt;SearchRecord&gt;  _recentSearches
    ///       The search history is a stack because the most recent search is the most
    ///       useful one and should be the first available. Push on each search, Peek to
    ///       read the latest without disturbing the history.
    ///
    ///   Dictionary&lt;string, int&gt;  _categoryFrequency  and  _keywordFrequency
    ///       Hash tables counting how often each category and keyword has been searched.
    ///       Retrieval is O(1) on average, so scoring every event stays fast.
    ///
    ///   HashSet&lt;string&gt;  _searchedCategories
    ///       The distinct categories the resident has ever searched, used to decide
    ///       whether an event is in familiar territory or is a new suggestion.
    /// </summary>
    public static class SearchHistoryService
    {
        private static readonly Stack<SearchRecord> _recentSearches = new Stack<SearchRecord>();

        private static readonly Dictionary<string, int> _categoryFrequency =
            new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        private static readonly Dictionary<string, int> _keywordFrequency =
            new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        private static readonly HashSet<string> _searchedCategories =
            new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        public static int SearchCount
        {
            get { return _recentSearches.Count; }
        }

        public static bool HasHistory
        {
            get { return _recentSearches.Count > 0; }
        }

        /// <summary>
        /// Stores one search. The record is pushed onto the stack and the frequency
        /// counters are updated so later recommendations reflect the resident's interests.
        /// </summary>
        public static void Record(SearchRecord record)
        {
            if (record == null)
            {
                return;
            }

            _recentSearches.Push(record);

            if (record.Category.Length > 0)
            {
                Increment(_categoryFrequency, record.Category);
                _searchedCategories.Add(record.Category);
            }

            if (record.Keyword.Length > 0)
            {
                // Each word is counted separately so a search for "community meeting"
                // contributes to both "community" and "meeting".
                string[] words = record.Keyword.Split(
                    new[] { ' ', ',', ';', '.', '-' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string word in words)
                {
                    if (word.Length >= 3)
                    {
                        Increment(_keywordFrequency, word);
                    }
                }
            }
        }

        private static void Increment(Dictionary<string, int> counter, string key)
        {
            if (counter.ContainsKey(key))
            {
                counter[key] = counter[key] + 1;
            }
            else
            {
                counter[key] = 1;
            }
        }

        /// <summary>
        /// The most recent search, read from the top of the stack without removing it.
        /// </summary>
        public static SearchRecord MostRecent()
        {
            return _recentSearches.Count == 0 ? null : _recentSearches.Peek();
        }

        /// <summary>
        /// The most recent searches, newest first. Enumerating a Stack&lt;T&gt; already
        /// walks from the top downwards, so no reversing is required.
        /// </summary>
        public static List<SearchRecord> GetRecent(int maximum)
        {
            return _recentSearches.Take(maximum).ToList();
        }

        public static int GetCategoryScore(string category)
        {
            if (string.IsNullOrWhiteSpace(category) || !_categoryFrequency.ContainsKey(category))
            {
                return 0;
            }

            return _categoryFrequency[category];
        }

        public static Dictionary<string, int> GetKeywordFrequencies()
        {
            return new Dictionary<string, int>(_keywordFrequency, StringComparer.OrdinalIgnoreCase);
        }

        public static HashSet<string> GetSearchedCategories()
        {
            return new HashSet<string>(_searchedCategories, StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// The category searched most often, or an empty string when nothing has been searched.
        /// </summary>
        public static string FavouriteCategory()
        {
            string favourite = string.Empty;
            int best = 0;

            foreach (KeyValuePair<string, int> entry in _categoryFrequency)
            {
                if (entry.Value > best)
                {
                    best = entry.Value;
                    favourite = entry.Key;
                }
            }

            return favourite;
        }

        /// <summary>
        /// Clears the history. Used by the Clear button on the events page.
        /// </summary>
        public static void Clear()
        {
            _recentSearches.Clear();
            _categoryFrequency.Clear();
            _keywordFrequency.Clear();
            _searchedCategories.Clear();
        }
    }
}
