# Municipal Services Application — Part 2 (Local Events and Announcements)

**Module:** Programming 3B (PROG7312) / Advanced Application Development (AAPD7112)
**Student:** Nosipho Xulu
**Student number:** ST10507346
**Institution:** IIE Rosebank College

---

## 1. Overview

This Windows Forms application allows residents of a South African municipality to
engage with municipal services. Part 2 adds the **Local Events and Announcements**
feature to the application built in Part 1.

| Menu option | Status |
|---|---|
| Report an Issue | Implemented in Part 1 |
| Local Events and Announcements | **Implemented in Part 2** |
| Service Request Status | Disabled until Part 3 |

The events page lets a resident browse the municipal diary, search it by keyword,
category and date range, read announcements, and receive event recommendations
generated from their own search behaviour.

---

## 2. Requirements

| Requirement | Version |
|---|---|
| Operating system | Windows 10 or Windows 11 |
| IDE | Visual Studio 2019 or later, with the **.NET desktop development** workload |
| Framework | .NET Framework 4.8 |
| Language | C# 7.3 |

No external libraries, NuGet packages, database or internet connection are required.

---

## 3. How to compile

1. Extract the folder to a location on the machine, for example `C:\Dev`.
2. Open **`ST10507346_PROG7312_Part2.sln`**.
3. Build with **Build > Build Solution** or `Ctrl+Shift+B`.

The project targets .NET Framework 4.8 with the root namespace `MunicipalServicesApp`.
If Visual Studio offers to retarget the project, install the .NET Framework 4.8
targeting pack through the Visual Studio Installer instead of accepting the retarget.

From a **Developer Command Prompt**:

```
msbuild ST10507346_PROG7312_Part2.sln /p:Configuration=Debug
```

---

## 4. How to run

- From Visual Studio: `F5` (with debugging) or `Ctrl+F5` (without).
- From the build output: `bin\Debug\ST10507346_PROG7312_Part2.exe`.

---

## 5. How to use the Local Events page

1. From the main menu, click **2. Local Events and Announcements**.
2. The full diary loads in date order. Click any row to read the full details below the list.
3. To search:
   - **Keyword** — matches the event title, description, venue and category.
   - **Category** — narrows results to one category, or leave on *All categories*.
   - **Filter by date range** — tick the box to enable the two date pickers.
   - Click **Search**, or press Enter.
4. **Recommended for you** updates after every search. Click a suggestion to read it and
   see why it was recommended.
5. **Announcements** shows one announcement at a time. Click **Next announcement** to
   cycle through them in the order the municipality published them.
6. **Recent searches** lists your searches with the newest at the top.
7. **Clear** empties the search fields but keeps your history, so recommendations stay
   personalised. **Show all upcoming events** reloads the full diary.
8. **Back to Main Menu** returns to the menu.

### Try this to see the recommendation feature work

1. Search the keyword `clean` — two environment events are returned.
2. Search the category **Environment and Clean-up**.
3. Search the category **Environment and Clean-up** again.
4. Look at the recommendations: environment events now rank at the top, and the reason
   line explains that you searched that category three times.

---

## 6. Data structures used

### 6.1 SortedDictionary — the event diary

```csharp
SortedDictionary<DateTime, List<LocalEvent>> _eventsByDate
```

Events are grouped by calendar day, keyed on the date. A `SortedDictionary<TKey,TValue>`
is implemented internally as a **red-black tree**, so its keys are permanently held in
ascending order. Walking the dictionary yields the diary in chronological order with no
sorting step at all, which is why `GetAllInDateOrder()` contains no call to `Sort` on the
outer collection.

Insert and lookup are both **O(log n)**.

A `Dictionary` would have been faster to insert into (O(1)) but would return the days in
an arbitrary order, requiring an O(n log n) sort every time the diary is displayed.

### 6.2 Dictionary (hash table) — category index

```csharp
Dictionary<string, List<LocalEvent>> _eventsByCategory
```

A hash table mapping a category name to every event in that category, giving **O(1)
average** retrieval. When the resident filters by category, `Search()` starts from this
entry rather than scanning the whole diary, so events that cannot possibly match are
never examined.

Two further dictionaries track search behaviour:

```csharp
Dictionary<string, int> _categoryFrequency   // how often each category was searched
Dictionary<string, int> _keywordFrequency    // how often each keyword was searched
```

These are read once per event while scoring recommendations, so O(1) lookup matters:
with a list the scoring loop would become O(n × m).

### 6.3 HashSet — unique categories and dates

```csharp
HashSet<string>   _categories          // distinct categories
HashSet<DateTime> _dates               // distinct event dates
HashSet<string>   _searchedCategories  // categories the resident has searched
HashSet<int>      visibleEventIds      // events already on screen
HashSet<int>      alreadySuggested     // guards against duplicate suggestions
```

A set stores each value at most once and silently ignores a repeat `Add`. The category
dropdown is therefore built without any duplicate checking of its own, even though
eighteen events share eight categories.

`Contains` is **O(1) average**, which is why the recommendation engine uses a set rather
than a list to check whether an event is already displayed — inside a loop over every
event, a list would make that check O(n) and the loop O(n²).

### 6.4 Queue — announcements

```csharp
Queue<Announcement> _announcements
```

Announcements are shown in the order the municipality published them, which is
first in, first out. `NextAnnouncement()` dequeues the front item and immediately
enqueues it again, so the resident can cycle through all announcements indefinitely
without the queue ever emptying.

`Enqueue` and `Dequeue` are both **O(1)**.

### 6.5 Stack — search history

```csharp
Stack<SearchRecord> _recentSearches
```

The search history is a stack because the most recent search is the most relevant, and
a stack makes it the first item available (LIFO). `Push` records a search, `Peek` reads
the latest without disturbing the history, and enumerating the stack walks from the top
downwards — which is exactly the order the Recent Searches list needs, so no reversing
is required.

`Push` and `Peek` are both **O(1)**.

### 6.6 Priority queue — ranking

```csharp
PriorityQueue<LocalEvent>     // min-heap, soonest event first
PriorityQueue<Recommendation> // max-heap, highest score first
```

**.NET Framework 4.8 does not include a priority queue type** —
`System.Collections.Generic.PriorityQueue<TElement,TPriority>` was only added in .NET 6.
It is therefore implemented in `DataStructures/PriorityQueue.cs` as a **binary heap**
stored in a `List<T>`, where for the item at index *i*:

```
parent      = (i - 1) / 2
left child  = 2i + 1
right child = 2i + 2
```

`Enqueue` appends the item and sifts it up; `Dequeue` removes the root, moves the last
item into its place and sifts it down. Both are **O(log n)**; `Peek` is **O(1)**.

The behaviour is controlled entirely by the `IComparer<T>` passed in:

| Comparer | Effect |
|---|---|
| `EventDateComparer` | Ascending by date — a **min-heap**, so the soonest event is at the root |
| `RecommendationScoreComparer` | Comparison reversed — a **max-heap**, so the best score is at the root |

Only five recommendations are displayed. Building the heap is O(n) and each removal is
O(log n), so taking the best five costs roughly O(n + k log n) — cheaper than sorting the
whole collection at O(n log n).

### 6.7 Summary

| Structure | Where | Why |
|---|---|---|
| `SortedDictionary` | Event diary by date | Keys stay ordered, no re-sorting |
| `Dictionary` | Category index, search frequencies | O(1) average lookup |
| `HashSet` | Categories, dates, duplicate guards | Automatic uniqueness, O(1) `Contains` |
| `Queue` | Announcements | FIFO publication order |
| `Stack` | Search history | LIFO, newest first |
| `PriorityQueue` (custom heap) | Soonest events, top recommendations | Best item without a full sort |
| `List` | Reported issues (Part 1), heap storage | Ordered, grows automatically |

---

## 7. The recommendation feature

The approach is **content-based filtering**: the resident's own search history builds a
profile, and every upcoming event is scored against it.

### Scoring

| Signal | Points |
|---|---|
| Each previous search in the event's category | +5 each |
| Event matches the category of the most recent search | +4 |
| A searched keyword appears in the title | +3 × times searched |
| A searched keyword appears in the description or venue | +2 × times searched |
| Event is within 7 days | +3 |
| Event is within 14 days | +2 |
| Event is within 30 days | +1 |
| Event is already visible in the current results | −4 |

Events scoring zero or below are discarded. The rest are enqueued into the max-heap and
the top five are dequeued, de-duplicated through a `HashSet` of event ids.

### Why these rules

- **Category weighting is highest** because an explicit category search is the clearest
  statement of interest a resident can make.
- **Keywords are weighted by frequency**, so a term searched three times counts three
  times as strongly as one searched once.
- **Recency is rewarded** because a recommendation for an event eight weeks away is less
  actionable than one happening this week.
- **Visible events are penalised** rather than removed. A recommendation panel that
  repeats what is already on screen adds nothing, but an event the resident has seen is
  not irrelevant, so it is pushed down rather than excluded.

Before any search has been performed, the panel falls back to the soonest upcoming
events, taken from the repository's min-heap.

Each recommendation carries a plain-language reason — for example *"Because you searched
Environment and Clean-up 3 times and matches 2 of your search terms"* — which is
displayed under the list so the suggestion is explainable rather than arbitrary.

---

## 8. Project structure

```
ST10507346_PROG7312_Part2.sln
README.md
ST10507346_PROG7312_Part2/
├── ST10507346_PROG7312_Part2.csproj
├── App.config
├── DataStructures/
│   ├── PriorityQueue.cs         Binary heap implementation
│   └── Comparers.cs             Min-heap and max-heap comparers
├── Models/
│   ├── Issue.cs                 Reported issue (Part 1)
│   ├── LocalEvent.cs            A local event
│   ├── Announcement.cs          A municipal announcement
│   └── SearchRecord.cs          A search, and a Recommendation
├── Services/
│   ├── IssueRepository.cs       List<Issue> store (Part 1)
│   ├── EventRepository.cs       SortedDictionary, Dictionary, sets, queue
│   ├── SearchHistoryService.cs  Stack and frequency dictionaries
│   └── RecommendationEngine.cs  Scoring and max-heap ranking
├── Properties/
│   └── AssemblyInfo.cs
├── MainMenuForm.cs / .Designer.cs
├── ReportIssueForm.cs / .Designer.cs      (Part 1)
├── LocalEventsForm.cs / .Designer.cs      (Part 2)
└── Program.cs
```

---

## 9. Event handling

| Control | Event | Handler |
|---|---|---|
| `btnLocalEvents` | Click | Opens the Local Events form |
| `btnSearch` | Click | Searches, records the search, refreshes recommendations |
| `btnClearSearch` | Click | Resets the fields, keeps the history |
| `btnShowAll` | Click | Reloads the full diary |
| `chkDateFilter` | CheckedChanged | Enables or disables the date pickers |
| `lvEvents` | SelectedIndexChanged | Shows the selected event's details |
| `lvRecommend` | SelectedIndexChanged | Shows the suggestion and why it was made |
| `btnNextAnnouncement` | Click | Dequeues and re-enqueues the next announcement |
| `btnBack` | Click | Returns to the main menu |

---

## 10. Display scaling and responsiveness

All forms use `AutoScaleMode.Font` and every control is anchored. The search panel
stretches horizontally, the results list grows vertically with the window, the
suggestions column stays pinned to the right edge, and the navigation buttons hold the
bottom. `App.config` declares per-monitor DPI awareness for high-resolution displays.

---

## 11. Known limitations

- Events and announcements are seeded in code. Persistence is not required by this part
  of the specification.
- The search history is held in memory for the session and is not retained between runs.
- Service Request Status is intentionally disabled until Part 3.
