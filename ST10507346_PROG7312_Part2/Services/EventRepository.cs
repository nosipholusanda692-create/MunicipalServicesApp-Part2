using System;
using System.Collections.Generic;
using System.Linq;
using MunicipalServicesApp.DataStructures;
using MunicipalServicesApp.Models;

namespace MunicipalServicesApp.Services
{
    /// <summary>
    /// Central store for local events and announcements.
    ///
    /// Several data structures are used deliberately, each for the job it is best at:
    ///
    ///   SortedDictionary&lt;DateTime, List&lt;LocalEvent&gt;&gt;  _eventsByDate
    ///       Keeps events grouped by calendar day and permanently ordered by date, so the
    ///       diary can be read out in chronological order without sorting it again. Lookup
    ///       and insert are O(log n) because the sorted dictionary is a red-black tree.
    ///
    ///   Dictionary&lt;string, List&lt;LocalEvent&gt;&gt;  _eventsByCategory
    ///       A hash table giving O(1) average retrieval of every event in a category,
    ///       which is what makes filtering by category immediate.
    ///
    ///   HashSet&lt;string&gt;  _categories  and  HashSet&lt;DateTime&gt;  _dates
    ///       Sets holding the distinct categories and distinct dates. A set rejects
    ///       duplicates automatically, so the category dropdown is built without any
    ///       duplicate checking of its own.
    ///
    ///   Queue&lt;Announcement&gt;  _announcements
    ///       Announcements are shown in the order the municipality published them, which
    ///       is first in, first out.
    ///
    ///   PriorityQueue&lt;LocalEvent&gt;
    ///       Used in GetNextUpcoming to pull the soonest events off the top of a min-heap.
    /// </summary>
    public static class EventRepository
    {
        private static readonly SortedDictionary<DateTime, List<LocalEvent>> _eventsByDate =
            new SortedDictionary<DateTime, List<LocalEvent>>();

        private static readonly Dictionary<string, List<LocalEvent>> _eventsByCategory =
            new Dictionary<string, List<LocalEvent>>(StringComparer.OrdinalIgnoreCase);

        private static readonly HashSet<string> _categories =
            new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        private static readonly HashSet<DateTime> _dates = new HashSet<DateTime>();

        private static readonly Queue<Announcement> _announcements = new Queue<Announcement>();

        private static readonly List<LocalEvent> _allEvents = new List<LocalEvent>();

        private static bool _isSeeded;

        /// <summary>
        /// Loads the sample events and announcements the first time the page is opened.
        /// Dates are generated relative to today so the diary always contains upcoming events.
        /// </summary>
        public static void Initialise()
        {
            if (_isSeeded)
            {
                return;
            }

            DateTime today = DateTime.Today;

            AddEvent(new LocalEvent(1, "Ward 12 Community Meeting", "Community Meeting",
                today.AddDays(2).AddHours(18), "Sunnyside Community Hall",
                "Monthly ward committee meeting. Residents can raise service delivery concerns directly with the ward councillor and the municipal manager."));

            AddEvent(new LocalEvent(2, "Mobile Clinic Outreach", "Health and Wellness",
                today.AddDays(3).AddHours(8), "Mamelodi Community Centre",
                "Free blood pressure and glucose screening, immunisations for children under five, and general health advice."));

            AddEvent(new LocalEvent(3, "Saturday Street Clean-Up", "Environment and Clean-up",
                today.AddDays(4).AddHours(7), "Church Street, Pretoria Central",
                "Community clean-up campaign. Gloves, bags and refreshments are provided by the municipality."));

            AddEvent(new LocalEvent(4, "Water Interruption Notice", "Service Notice",
                today.AddDays(5).AddHours(9), "Pretoria West",
                "Planned maintenance on the main supply line. Water will be interrupted between 09:00 and 16:00. Residents should store water in advance."));

            AddEvent(new LocalEvent(5, "Youth Soccer Tournament", "Sports and Recreation",
                today.AddDays(6).AddHours(10), "Caledonian Stadium",
                "Inter-ward under-17 soccer tournament. Entry is free for spectators and teams must register at the municipal sports office."));

            AddEvent(new LocalEvent(6, "Small Business Skills Workshop", "Education and Skills",
                today.AddDays(7).AddHours(9), "Pretoria City Library",
                "A practical workshop covering business registration, basic bookkeeping and how to tender for municipal contracts."));

            AddEvent(new LocalEvent(7, "Heritage Day Celebration", "Arts and Culture",
                today.AddDays(9).AddHours(11), "Freedom Park",
                "Traditional music, dance and food stalls celebrating the cultural diversity of the municipality."));

            AddEvent(new LocalEvent(8, "Neighbourhood Watch Information Session", "Public Safety",
                today.AddDays(10).AddHours(18), "Arcadia Police Station",
                "Learn how to start or join a neighbourhood watch, and how to report crime and suspicious activity effectively."));

            AddEvent(new LocalEvent(9, "Ward 8 Community Meeting", "Community Meeting",
                today.AddDays(11).AddHours(17), "Atteridgeville Civic Centre",
                "Feedback session on the ward's infrastructure budget and progress on outstanding service requests."));

            AddEvent(new LocalEvent(10, "Senior Citizens Wellness Day", "Health and Wellness",
                today.AddDays(12).AddHours(9), "Danville Clinic",
                "Health screening, exercise demonstrations and nutrition advice aimed at residents over sixty."));

            AddEvent(new LocalEvent(11, "Recycling Awareness Drive", "Environment and Clean-up",
                today.AddDays(14).AddHours(10), "Hatfield Square",
                "Demonstrations on separating waste at source, with free recycling bags for households that register on the day."));

            AddEvent(new LocalEvent(12, "Computer Literacy Course", "Education and Skills",
                today.AddDays(16).AddHours(14), "Soshanguve Public Library",
                "A six-week introductory course covering basic computer use, email and online government services."));

            AddEvent(new LocalEvent(13, "Electricity Maintenance Notice", "Service Notice",
                today.AddDays(18).AddHours(8), "Garsfontein",
                "Scheduled substation maintenance. Power will be off between 08:00 and 14:00 in the affected blocks."));

            AddEvent(new LocalEvent(14, "Community Fun Run", "Sports and Recreation",
                today.AddDays(20).AddHours(6), "Groenkloof Nature Reserve",
                "Five and ten kilometre routes open to all ages. Proceeds support local sports development programmes."));

            AddEvent(new LocalEvent(15, "Public Art Exhibition", "Arts and Culture",
                today.AddDays(23).AddHours(10), "Pretoria Art Museum",
                "An exhibition of work by artists living in the municipality, with guided tours on the hour."));

            AddEvent(new LocalEvent(16, "Fire Safety Demonstration", "Public Safety",
                today.AddDays(26).AddHours(13), "Centurion Fire Station",
                "Practical demonstration of household fire prevention, extinguisher use and emergency evacuation."));

            AddEvent(new LocalEvent(17, "Ward 12 Budget Feedback Session", "Community Meeting",
                today.AddDays(30).AddHours(18), "Sunnyside Community Hall",
                "Presentation of how the ward's allocated budget was spent during the current financial year."));

            AddEvent(new LocalEvent(18, "Tree Planting Campaign", "Environment and Clean-up",
                today.AddDays(35).AddHours(9), "Eersterust Sports Grounds",
                "Residents are invited to help plant indigenous trees. Saplings are supplied by the parks department."));

            // ----- Announcements, held in a queue in publication order -----
            _announcements.Enqueue(new Announcement("Refuse collection schedule change",
                "Refuse in the central business district will be collected on Tuesdays instead of Mondays from the start of next month.",
                today.AddDays(-6)));

            _announcements.Enqueue(new Announcement("Municipal accounts now available online",
                "Residents can register on the municipal portal to view and pay their accounts without visiting a walk-in centre.",
                today.AddDays(-4)));

            _announcements.Enqueue(new Announcement("Pothole repair programme underway",
                "The roads department has begun a repair programme on arterial routes. Residents are encouraged to report potholes through this application.",
                today.AddDays(-3)));

            _announcements.Enqueue(new Announcement("Library operating hours extended",
                "All municipal libraries will remain open until 19:00 on weekdays during the examination period.",
                today.AddDays(-1)));

            _isSeeded = true;
        }

        /// <summary>
        /// Adds an event to every structure that indexes it.
        /// </summary>
        private static void AddEvent(LocalEvent localEvent)
        {
            _allEvents.Add(localEvent);

            // Sorted dictionary, keyed by calendar day and permanently in date order.
            DateTime key = localEvent.DateOnly;

            if (!_eventsByDate.ContainsKey(key))
            {
                _eventsByDate[key] = new List<LocalEvent>();
            }

            _eventsByDate[key].Add(localEvent);

            // Dictionary (hash table), keyed by category for O(1) average lookup.
            if (!_eventsByCategory.ContainsKey(localEvent.Category))
            {
                _eventsByCategory[localEvent.Category] = new List<LocalEvent>();
            }

            _eventsByCategory[localEvent.Category].Add(localEvent);

            // Sets. Add returns false when the value is already present, so no duplicate
            // checking of our own is needed.
            _categories.Add(localEvent.Category);
            _dates.Add(key);
        }

        public static int EventCount
        {
            get { return _allEvents.Count; }
        }

        public static int CategoryCount
        {
            get { return _categories.Count; }
        }

        public static int DateCount
        {
            get { return _dates.Count; }
        }

        public static int AnnouncementCount
        {
            get { return _announcements.Count; }
        }

        /// <summary>
        /// The distinct categories, taken from the set and ordered alphabetically for display.
        /// </summary>
        public static List<string> GetCategories()
        {
            List<string> categories = _categories.ToList();
            categories.Sort(StringComparer.OrdinalIgnoreCase);
            return categories;
        }

        /// <summary>
        /// Every event in chronological order. No sorting is performed here because the
        /// SortedDictionary already keeps its keys in order.
        /// </summary>
        public static List<LocalEvent> GetAllInDateOrder()
        {
            List<LocalEvent> ordered = new List<LocalEvent>();

            foreach (KeyValuePair<DateTime, List<LocalEvent>> day in _eventsByDate)
            {
                List<LocalEvent> sameDay = new List<LocalEvent>(day.Value);
                sameDay.Sort(new EventDateComparer());
                ordered.AddRange(sameDay);
            }

            return ordered;
        }

        /// <summary>
        /// Every event in a single category, retrieved from the hash table.
        /// </summary>
        public static List<LocalEvent> GetByCategory(string category)
        {
            if (string.IsNullOrWhiteSpace(category) || !_eventsByCategory.ContainsKey(category))
            {
                return new List<LocalEvent>();
            }

            return new List<LocalEvent>(_eventsByCategory[category]);
        }

        /// <summary>
        /// Searches the diary by keyword, category and optional date range.
        ///
        /// When a category is supplied the search starts from the hash table entry for that
        /// category, which avoids scanning events that cannot match. Otherwise it walks the
        /// sorted dictionary, which is already in date order.
        /// </summary>
        public static List<LocalEvent> Search(string keyword, string category,
            DateTime? from, DateTime? to)
        {
            IEnumerable<LocalEvent> candidates;

            if (!string.IsNullOrWhiteSpace(category))
            {
                candidates = GetByCategory(category);
            }
            else
            {
                candidates = GetAllInDateOrder();
            }

            List<LocalEvent> results = new List<LocalEvent>();
            string trimmedKeyword = string.IsNullOrWhiteSpace(keyword) ? null : keyword.Trim();

            foreach (LocalEvent localEvent in candidates)
            {
                if (from.HasValue && localEvent.DateOnly < from.Value.Date)
                {
                    continue;
                }

                if (to.HasValue && localEvent.DateOnly > to.Value.Date)
                {
                    continue;
                }

                if (trimmedKeyword != null && !MatchesKeyword(localEvent, trimmedKeyword))
                {
                    continue;
                }

                results.Add(localEvent);
            }

            results.Sort(new EventDateComparer());
            return results;
        }

        private static bool MatchesKeyword(LocalEvent localEvent, string keyword)
        {
            return localEvent.Title.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0
                || localEvent.Description.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0
                || localEvent.Venue.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0
                || localEvent.Category.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        /// <summary>
        /// Returns the events happening soonest, using the priority queue.
        ///
        /// Every upcoming event is enqueued into a min-heap ordered by date, and the
        /// requested number is then dequeued. The heap gives the soonest event in
        /// O(log n) per removal without sorting the whole collection.
        /// </summary>
        public static List<LocalEvent> GetNextUpcoming(int count)
        {
            PriorityQueue<LocalEvent> queue = new PriorityQueue<LocalEvent>(new EventDateComparer());

            foreach (LocalEvent localEvent in _allEvents)
            {
                if (localEvent.IsUpcoming)
                {
                    queue.Enqueue(localEvent);
                }
            }

            return queue.DequeueMany(count);
        }

        /// <summary>
        /// Returns the announcement at the front of the queue and moves it to the back, so
        /// the resident can cycle through all announcements in publication order.
        /// </summary>
        public static Announcement NextAnnouncement()
        {
            if (_announcements.Count == 0)
            {
                return null;
            }

            Announcement next = _announcements.Dequeue();
            _announcements.Enqueue(next);
            return next;
        }

        /// <summary>
        /// Looks at the announcement at the front of the queue without removing it.
        /// </summary>
        public static Announcement PeekAnnouncement()
        {
            return _announcements.Count == 0 ? null : _announcements.Peek();
        }
    }
}
