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

        public void Add(T item, int count = 1)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(count);

            if (_items.ContainsKey(item) == false)
            {
                _items.Add(item, count);
            }
            else
            {
                _items[item] += count;
            }

            ItemsCount += count;
        }

        public void Remove(T item, int amount = 1)
        {
            if (_items.ContainsKey(item))
            {
                if (_items[item] > amount)
                {
                    _items[item] -= amount;
                }
                else 
                {
                    _items.Remove(item);
                }
            }

            ItemsCount -= amount;
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
