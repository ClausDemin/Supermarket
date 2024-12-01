namespace Supermarket.Model
{
    public class Product
    {
        public Product(string name, float price)
        {
            Price = price;
            Name = name;
        }

        public float Price { get; }
        public string Name { get; }

        public override string ToString()
        {
            var result = $"Product: {Name}, Price: {Price}";

            return result;
        }
    }
}
