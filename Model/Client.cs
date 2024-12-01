using Supermarket.Interfaces;

namespace Supermarket.Model
{
    public class Client : IHaveInventory<Product>
    {
        private Wallet _wallet;
        private Inventory<Product> _profuctsCart;
        private Inventory<Product> _inventory;

        public Client(Wallet wallet)
        {
            _wallet = wallet;
            _profuctsCart = new Inventory<Product>();
            _inventory = new Inventory<Product>();
        }

        public IEnumerable<Product> ProductsCart => GetProductsInCart();

        public int ProductsInCartCount => _profuctsCart.ItemsCount;

        public bool TryMakePayment(float payemntAmount)
        {
            bool paymentResult = false;

            if (_wallet.TryWithdrawMoney(payemntAmount))
            {
                MoveProductsFromCartToInventory();

                paymentResult = true;

                string paymentCompleteMessage = $"Клиент оплатил товаров на сумму {payemntAmount}";

                Console.WriteLine(paymentCompleteMessage);
            }
            else 
            {
                var productToRemove = GetRandomItem();

                RemoveProductFormCart(productToRemove);

                string itemRemovedInfo = $"Клиенту не хватает денег для покупки. Клиент убирает товар {productToRemove.ToString()} из корзины.";

                Console.WriteLine(itemRemovedInfo);
            }

            return paymentResult;
        }

        public void AddProductInCart(Product product)
        {
            _profuctsCart.Add(product);
        }

        public void RemoveProductFormCart(Product product)
        {
            if (product != null) 
            { 
                _profuctsCart.Remove(product);
            }
        }

        public Product GetRandomItem()
        {
            Random random = new Random();

            var productsInStorage = GetProductsInCart();

            if (productsInStorage != null) 
            {
                return productsInStorage[random.Next(productsInStorage.Count)];
            }

            return null;
        }

        public void PrintInfo() 
        {
            string clientInfo = $"Товаров в корзине {ProductsInCartCount}\n" +
                $"Товары в корзине: \n";

            var products = ProductsCart;

            foreach (var product in products) 
            {
                clientInfo += $"{product.ToString()}\n";
            }

            Console.WriteLine(clientInfo);
        }

        private void MoveProductsFromCartToInventory()
        {
            foreach (var product in _profuctsCart)
            {
                _inventory.Add(product.Key, product.Value);
            }

            _profuctsCart.Clear();
        }

        private List<Product> GetProductsInCart()
        {
            var result = new List<Product>();

            foreach (var product in _profuctsCart)
            {
                for (int i = 0; i < product.Value; i++)
                {
                    result.Add(product.Key);
                }
            }

            return result;
        }
    }
}
