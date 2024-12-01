using Supermarket.Interfaces;

namespace Supermarket.Model
{
    public class Vendor : IHaveInventory<Product>
    {
        private Wallet _wallet;
        private Inventory<Product> _storage;
        private Queue<Client> _clients;

        public Vendor(Inventory<Product> storage, Queue<Client> clients)
        {
            _wallet = new Wallet();
            _storage = storage;
            _clients = clients;
        }

        public IEnumerable<Product> ProductsList => GetProductsList();
        public int ClientsToServe => _clients.Count;

        public void ServeNextClient()
        {
            if (_clients.Count > 0)
            {
                var client = _clients.Dequeue();

                client.PrintInfo();

                bool clientServed = false;

                while (!clientServed)
                {
                    clientServed = TryServeClient(client);
                }
            }
        }

        public void AddClient(Client client)
        {
            _clients.Enqueue(client);
        }

        public Product GetRandomItem()
        {
            var random = new Random();

            var productsAtStorage = GetProductsList();

            return productsAtStorage[random.Next(productsAtStorage.Count)];
        }

        public void PrintInfo() 
        {
            string venorInfo = $"Клиентов в очереди: {ClientsToServe}\n" +
                $"Баланс: {_wallet.Balance}\n";

            Console.WriteLine(venorInfo);
        }

        private bool TryServeClient(Client client)
        {
            bool paymentCompleted = false;

            float paymentAmount = GetPaymentAmount(client.ProductsCart);

            paymentCompleted = client.TryMakePayment(paymentAmount);

            if (paymentCompleted)
            {
                _wallet.AddMoney(paymentAmount);
            }

            return paymentCompleted;
        }

        private float GetPaymentAmount(IEnumerable<Product> productsCart)
        {
            float total = 0;

            foreach (var product in productsCart)
            {
                total += product.Price;
            }

            return total;
        }

        private List<Product> GetProductsList()
        {
            var result = new List<Product>();

            foreach (var product in _storage)
            {
                result.Add(product.Key);
            }

            return result;
        }
    }
}
