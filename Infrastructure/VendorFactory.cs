using Supermarket.Model;

namespace Supermarket.Infrastructure
{
    public class VendorFactory
    {
        InventoryFactory _inventoryFactory;
        ClientFactory _clientFactory;

        public VendorFactory(InventoryFactory inventoryFactory, ClientFactory clientFactory)
        {
            _inventoryFactory = inventoryFactory;
            _clientFactory = clientFactory;
        }

        public Vendor CreateVendor(int clientsCount = 10)
        {
            var vendor = new Vendor(_inventoryFactory.CreateVendorInventory(), new Queue<Client>());

            var clientsQueue = CreateClientsQueue(vendor, clientsCount);

            foreach (var client in clientsQueue) 
            { 
                vendor.AddClient(client);
            }

            return vendor; 
        }

        private Queue<Client> CreateClientsQueue(Vendor vendor, int clientsCount)
        {
            Queue<Client> clients = new Queue<Client>();

            for (int i = 0; i < clientsCount; i++)
            {
                clients.Enqueue(_clientFactory.CreateClient(vendor));
            }

            return clients;
        }
    }
}
