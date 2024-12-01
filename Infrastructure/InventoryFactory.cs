using Supermarket.Model;

namespace Supermarket.Infrastructure
{
    public class InventoryFactory
    {
        ProductsFactory _productsFactory;

        public InventoryFactory(ProductsFactory productsFactory)
        {
            _productsFactory = productsFactory;
        }

        public Inventory<Product> CreateVendorInventory()
        {
            var products = Enum.GetNames(typeof(AvailbaleProducts));

            var inventory = new Inventory<Product>();

            foreach (var productName in products)
            {
                inventory.Add(_productsFactory.CreateProduct(productName));
            }

            return inventory;
        }
    }
}
