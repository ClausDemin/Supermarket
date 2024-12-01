using Supermarket.Model;

namespace Supermarket.Infrastructure
{
    public class VendorFactory
    {
        InventoryFactory _inventoryFactory;

        public VendorFactory(InventoryFactory inventoryFactory)
        {
            _inventoryFactory = inventoryFactory;
        }

        public Vendor CreateVendor(int clientsCount = 10, Queue<Client> clientsQueue = null)
        {
            var vendor = new Vendor(_inventoryFactory.CreateVendorInventory(), clientsQueue);

            return vendor; 
        }
    }
}
