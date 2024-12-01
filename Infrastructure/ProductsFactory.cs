using Supermarket.Model;

namespace Supermarket.Infrastructure
{
    public class ProductsFactory
    {
        private Dictionary<AvailbaleProducts, float> _productsData = new Dictionary<AvailbaleProducts, float>()
        {
            {AvailbaleProducts.Milk, 159.99f },
            {AvailbaleProducts.Eggs, 129.99f },
            {AvailbaleProducts.Bread, 58.99f },
            {AvailbaleProducts.Pasta, 119.89f },
            {AvailbaleProducts.Sausage, 219.99f },
            {AvailbaleProducts.Knife,  519.99f},
            {AvailbaleProducts.Fork, 159.99f },
            {AvailbaleProducts.Spoon, 109.99f }
        };

        public Product Create(AvailbaleProducts productType)
        {
            var product = new Product(productType.ToString(), _productsData[productType]);

            return product;
        }

        public Product Create(string productName)
        {
            if (Enum.TryParse<AvailbaleProducts>(productName, out var productType))
            {
                return Create(productType);
            }

            return null;
        }
    }
}
