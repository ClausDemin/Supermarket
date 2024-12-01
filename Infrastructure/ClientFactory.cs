using Supermarket.Interfaces;
using Supermarket.Model;
using Supermarket.Utils;

namespace Supermarket.Infrastructure
{
    public class ClientFactory
    {
        public Client CreateClient(IHaveProducts vendor, int minProductsInCart = 1, int maxProductsInCart = 15)
        {
            var clientWallet = new Wallet(GetRandomMoneyAmount());
            var client = new Client(clientWallet);

            var productsInCart = RandomGenetator.Next(minProductsInCart, maxProductsInCart);

            while (client.ProductsInCartCount < productsInCart)
            {
                client.AddProductInCart(vendor.GetRandomItem());
            }

            return client;
        }

        public Queue<Client> CreateClientsQueue(IHaveProducts vendor, int clientsCount)
        {
            Queue<Client> clients = new Queue<Client>();

            for (int i = 0; i < clientsCount; i++)
            {
                clients.Enqueue(CreateClient(vendor));
            }

            return clients;
        }

        private float GetRandomMoneyAmount(float minValue = 500f, float maxValue = 2000f)
        {
            return RandomGenetator.NextSingle(minValue, maxValue);
        }
    }
}
