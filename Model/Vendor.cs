using Supermarket.Interfaces;
using Supermarket.Utils;

namespace Supermarket.Model
{
    public class Vendor : IHaveProducts
    {
        private Wallet _wallet;
        private Inventory<Product> _availableProducts;
        private Queue<Client> _clients;

        public Vendor(Inventory<Product> storage, Queue<Client> clients = null)
        {
            _wallet = new Wallet();
            _availableProducts = storage;

            if (clients == null)
            {
                _clients = new Queue<Client>();
            }
            else
            {
                _clients = clients;
            }
        }

        public IEnumerable<Product> ProductsList => GetProductsList();
        public int ClientsToServe => _clients.Count;

        public void ServeNextClient()
        {
            if (_clients.Count > 0)
            {
                var client = _clients.Dequeue();

                client.PrintInfo();

                bool isClientServed = false;

                while (isClientServed == false)
                {
                    isClientServed = TryServeClient(client);
                }

                client.NotEnoughMoney -= OnPaymentFailed;
                client.PaymentComplited -= OnPaymentComplited;
            }
        }

        public void Enqueue(Client client)
        {
            _clients.Enqueue(client);

            client.NotEnoughMoney += OnPaymentFailed;
            client.PaymentComplited += OnPaymentComplited;
        }

        public void Enqueue(Queue<Client> clientsQueue) 
        {
            while (clientsQueue.Count > 0) 
            { 
                Enqueue(clientsQueue.Dequeue());
            }
        }

        public Product GetRandomItem()
        {
            var products = GetProductsList();

            return products[RandomGenetator.Next(products.Count)];
        }

        public void PrintInfo()
        {
            string venorInfo = $"Клиентов в очереди: {ClientsToServe}\n" +
                $"Баланс: {_wallet.Balance}\n";

            Console.WriteLine(venorInfo);
        }

        private void OnPaymentFailed(Product product)
        {
            string itemRemovedInfo = $"Клиенту не хватает денег для покупки. Клиент убирает товар {product.ToString()} из корзины.";

            Console.WriteLine(itemRemovedInfo);
        }

        private void OnPaymentComplited(float paymentAmount)
        {
            string paymentCompleteMessage = $"Клиент оплатил товаров на сумму {paymentAmount}";

            Console.WriteLine(paymentCompleteMessage);
        }

        private bool TryServeClient(Client client)
        {
            bool isPaymentCompleted = false;

            float paymentAmount = GetPaymentAmount(client.ProductsCart);

            isPaymentCompleted = client.TryMakePayment(paymentAmount);

            if (isPaymentCompleted)
            {
                _wallet.AddMoney(paymentAmount);
            }

            return isPaymentCompleted;
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

            foreach (var product in _availableProducts)
            {
                result.Add(product.Key);
            }

            return result;
        }
    }
}
