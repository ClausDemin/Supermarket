namespace Supermarket.Model
{
    public class Inventory<T>
        where T : notnull
    {
        private Dictionary<T, int> _storage;

        public Inventory()
        {
            _storage = new();
        }

        public IReadOnlyDictionary<T, int> Storage => _storage;
        public int ItemsCount { get; private set; }

        public void Add(T item, int count = 1)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(count);

            if (_storage.ContainsKey(item) == false)
            {
                _storage.Add(item, count);
            }
            else
            {
                _storage[item] += count;
            }

            ItemsCount += count;
        }

        public void Remove(T item)
        {
            if (_storage.ContainsKey(item))
            {
                if (_storage[item] > 1)
                {
                    _storage[item] -= 1;
                }
                else
                {
                    _storage.Remove(item);
                }
            }

            ItemsCount--;
        }

        public void Clear()
        {
            _storage.Clear();

            ItemsCount = 0;
        }

        public IEnumerator<KeyValuePair<T, int>> GetEnumerator()
        {
            foreach (var product in _storage)
            {
                yield return product;
            }
        }
    }
}
