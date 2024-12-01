namespace Supermarket.Interfaces
{
    public interface IHaveInventory<T>
    {
        public T GetRandomItem();
    }
}
