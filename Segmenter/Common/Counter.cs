using System.Collections.Generic;
using System.Linq;

namespace JiebaNet.Segmenter.Common
{
    public interface ICounter<T>
    {
        int Count { get; }
        int Total { get; }
        int this[T key] { get; set; }
        IEnumerable<KeyValuePair<T, int>> Elements { get; }

        /// <summary>
        /// Lists the n most common elements from the most common to the least.
        /// </summary>
        /// <param name="n">Number of elements, list all elements if n is less than 0.</param>
        /// <returns></returns>
        IEnumerable<KeyValuePair<T, int>> MostCommon(int n = -1);

        /// <summary>
        /// Subtracts items from a counter.
        /// </summary>
        /// <param name="items"></param>
        void Subtract(IEnumerable<T> items);

        /// <summary>
        /// Subtracts counts from another counter.
        /// </summary>
        /// <param name="other"></param>
        void Subtract(ICounter<T> other);

        /// <summary>
        /// Adds items to a counter.
        /// </summary>
        /// <param name="items"></param>
        void Add(IEnumerable<T> items);

        /// <summary>
        /// Adds another counter.
        /// </summary>
        /// <param name="other"></param>
        void Add(ICounter<T> other);

        /// <summary>
        /// Union is the maximum of value in either of the input <see cref="ICounter{T}"/>.
        /// </summary>
        /// <param name="other">The other counter.</param>
        ICounter<T> Union(ICounter<T> other);

        void Remove(T key);
        void Clear();
        bool Contains(T key);
    }

    public class Counter<T> : ICounter<T>
    {
        private readonly Dictionary<T, int> _data = new Dictionary<T, int>();

        private Counter()
        {
        }

        public Counter(IEnumerable<T> items)
        {
            CountItems(items);
        }

        public int Count => _data.Count;
        public int Total => _data.Values.Sum();
        public IEnumerable<KeyValuePair<T, int>> Elements => _data;

        public int this[T key]
        {
            get => _data.ContainsKey(key) ? _data[key] : 0;
            set => _data[key] = value;
        }

        public IEnumerable<KeyValuePair<T, int>> MostCommon(int n = -1)
        {
            var pairs = _data.Where(pair => pair.Value > 0).OrderByDescending(pair => pair.Value);
            return n < 0 ? pairs : pairs.Take(n);
        }

        public void Subtract(IEnumerable<T> items)
        {
            SubtractItems(items);
        }

        public void Subtract(ICounter<T> other)
        {
            SubtractPairs(other.Elements);
        }

        public void Add(IEnumerable<T> items)
        {
            CountItems(items);
        }

        public void Add(ICounter<T> other)
        {
            CountPairs(other.Elements);
        }

        public ICounter<T> Union(ICounter<T> other)
        {
            var result = new Counter<T>();
            foreach (var pair in _data)
            {
                var count = pair.Value;
                var otherCount = other[pair.Key];
                var newCount = count < otherCount ? otherCount : count;
                result[pair.Key] = newCount;
            }

            foreach (var pair in other.Elements)
                if (!Contains(pair.Key))
                    result[pair.Key] = pair.Value;

            return result;
        }

        public void Remove(T key)
        {
            if (_data.ContainsKey(key))
                _data.Remove(key);
        }

        public void Clear()
        {
            _data.Clear();
        }

        public bool Contains(T key)
        {
            return _data.ContainsKey(key);
        }

        #region Private Methods

        private void CountItems(IEnumerable<T> items)
        {
            foreach (var item in items)
                _data[item] = _data.GetDefault(item, 0) + 1;
        }

        private void CountPairs(IEnumerable<KeyValuePair<T, int>> pairs)
        {
            foreach (var pair in pairs)
                this[pair.Key] += pair.Value;
        }

        private void SubtractItems(IEnumerable<T> items)
        {
            foreach (var item in items)
                _data[item] = _data.GetDefault(item, 0) - 1;
        }

        private void SubtractPairs(IEnumerable<KeyValuePair<T, int>> pairs)
        {
            foreach (var pair in pairs)
                this[pair.Key] -= pair.Value;
        }

        #endregion
    }
}