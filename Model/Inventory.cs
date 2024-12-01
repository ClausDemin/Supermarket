namespace Supermarket.Model
{
    public class Inventory<T>
        where T : notnull
    {
        private Dictionary<T, int> _items;

        public Inventory()
        {
            _items = new();
        }

        public IReadOnlyDictionary<T, int> Items => _items;
        public int ItemsCount { get; private set; }

        public void Add(T item, int amount = 1)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);

            if (_items.ContainsKey(item) == false)
            {
                _items.Add(item, amount);
            }
            else
            {
                _items[item] += amount;
            }

            ItemsCount += amount;
        }

        public void Remove(T item)
        {
            if (_items.ContainsKey(item))
            {
                if (_items[item] > 0)
                {
                    _items[item]--;
                }

                if (_items[item] == 0)
                {
                    _items.Remove(item);
                }
            }

            ItemsCount--;
        }

        public void Clear()
        {
            _items.Clear();

            ItemsCount = 0;
        }

        public IEnumerator<KeyValuePair<T, int>> GetEnumerator()
        {
            foreach (var product in _items)
            {
                yield return product;
            }
        }
    }
}
