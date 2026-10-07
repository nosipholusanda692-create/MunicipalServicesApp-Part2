using System;
using System.Collections.Generic;

namespace MunicipalServicesApp.DataStructures
{
    /// <summary>
    /// A generic priority queue implemented as a binary heap.
    ///
    /// .NET Framework 4.8 does not provide a PriorityQueue type (System.Collections.Generic.PriorityQueue
    /// was only introduced in .NET 6), so the structure is implemented here directly.
    ///
    /// The heap is stored in a List&lt;T&gt;, where for the item at index i:
    ///     parent      = (i - 1) / 2
    ///     left child  = 2i + 1
    ///     right child = 2i + 2
    ///
    /// The supplied IComparer&lt;T&gt; decides priority. A comparer that orders items
    /// ascending produces a min-heap, so the smallest item is always dequeued first.
    /// To obtain a max-heap, pass a comparer that reverses the comparison.
    ///
    /// Complexity: Enqueue O(log n), Dequeue O(log n), Peek O(1), Count O(1).
    /// </summary>
    public class PriorityQueue<T>
    {
        private readonly List<T> _heap = new List<T>();
        private readonly IComparer<T> _comparer;

        public PriorityQueue(IComparer<T> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException("comparer");
            }

            _comparer = comparer;
        }

        public int Count
        {
            get { return _heap.Count; }
        }

        public bool IsEmpty
        {
            get { return _heap.Count == 0; }
        }

        /// <summary>
        /// Adds an item to the queue and restores the heap property by sifting it up.
        /// </summary>
        public void Enqueue(T item)
        {
            _heap.Add(item);
            SiftUp(_heap.Count - 1);
        }

        /// <summary>
        /// Removes and returns the highest priority item, which always sits at the root.
        /// The last item is moved to the root and sifted down to restore the heap.
        /// </summary>
        public T Dequeue()
        {
            if (_heap.Count == 0)
            {
                throw new InvalidOperationException("The priority queue is empty.");
            }

            T root = _heap[0];
            int lastIndex = _heap.Count - 1;

            _heap[0] = _heap[lastIndex];
            _heap.RemoveAt(lastIndex);

            if (_heap.Count > 0)
            {
                SiftDown(0);
            }

            return root;
        }

        /// <summary>
        /// Returns the highest priority item without removing it.
        /// </summary>
        public T Peek()
        {
            if (_heap.Count == 0)
            {
                throw new InvalidOperationException("The priority queue is empty.");
            }

            return _heap[0];
        }

        public void Clear()
        {
            _heap.Clear();
        }

        /// <summary>
        /// Removes items in priority order until the queue is empty, or until the
        /// requested number of items has been taken.
        /// </summary>
        public List<T> DequeueMany(int maximum)
        {
            List<T> taken = new List<T>();

            while (_heap.Count > 0 && taken.Count < maximum)
            {
                taken.Add(Dequeue());
            }

            return taken;
        }

        /// <summary>
        /// Moves the item at the given index up while it has a higher priority than its parent.
        /// </summary>
        private void SiftUp(int index)
        {
            while (index > 0)
            {
                int parent = (index - 1) / 2;

                if (_comparer.Compare(_heap[index], _heap[parent]) >= 0)
                {
                    break;
                }

                Swap(index, parent);
                index = parent;
            }
        }

        /// <summary>
        /// Moves the item at the given index down while either child has a higher priority.
        /// </summary>
        private void SiftDown(int index)
        {
            int count = _heap.Count;

            while (true)
            {
                int left = (2 * index) + 1;
                int right = (2 * index) + 2;
                int smallest = index;

                if (left < count && _comparer.Compare(_heap[left], _heap[smallest]) < 0)
                {
                    smallest = left;
                }

                if (right < count && _comparer.Compare(_heap[right], _heap[smallest]) < 0)
                {
                    smallest = right;
                }

                if (smallest == index)
                {
                    break;
                }

                Swap(index, smallest);
                index = smallest;
            }
        }

        private void Swap(int first, int second)
        {
            T temporary = _heap[first];
            _heap[first] = _heap[second];
            _heap[second] = temporary;
        }
    }
}
