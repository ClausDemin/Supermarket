using Supermarket.Infrastructure.Extensions;
using Supermarket.Model;

namespace Supermarket.Infrastructure
{
    public class ClientFactory
    {
        private List<Client> _clientRepository = new List<Client>();
        
        public Client[] Clients => _clientRepository.ToArray();

        public Client CreateClient(Vendor vendor, int minProductsInCart = 1, int maxProductsInCart = 15)
        {
            var clientWallet = new Wallet(GetRandomMoneyAmount());
            var client = new Client(clientWallet);

            var productsInCart = RandomUtils.Random.Next(minProductsInCart, maxProductsInCart);

            while (client.ProductsInCartCount < productsInCart)
            {
                client.AddProductInCart(vendor.GetRandomItem());
            }

            _clientRepository.Add(client);

            return client;
        }

        private float GetRandomMoneyAmount(float minValue = 500f, float maxValue = 2000f)
        {
            return RandomUtils.Random.NextSingle(minValue, maxValue);
        }
    }
}
