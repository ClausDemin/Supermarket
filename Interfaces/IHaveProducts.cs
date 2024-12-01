using Supermarket.Model;

namespace Supermarket.Interfaces
{
    public interface IHaveProducts : IHaveInventory<Product>
    {
        public IEnumerable<Product> ProductsList { get; }
    }
}
