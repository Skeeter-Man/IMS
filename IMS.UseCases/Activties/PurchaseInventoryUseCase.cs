using IMS.CoreBusiness;
using IMS.UseCases.Activties.Interfaces;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Activties
{
    public class PurchaseInventoryUseCase : IPurchaseInventoryUseCase
    {
        private readonly IInventoryTransactionRepository _inventoryTransactionRepository;
        private readonly IInventoryRepository _inventoryRepository;

        public PurchaseInventoryUseCase(IInventoryTransactionRepository inventoryTransactionRepository,
            IInventoryRepository inventoryRepository)
        {
            _inventoryTransactionRepository = inventoryTransactionRepository;
            _inventoryRepository = inventoryRepository;
        }

        public async Task ExecuteAsync(string poNumber, Inventory inventory, int quantity, string doneBy)
        {
            // Insert record in the transaction table
            _inventoryTransactionRepository.PurchaseAsync(poNumber, inventory, quantity, doneBy, inventory.Price);

            // Increase the quantity
            inventory.Quantity += quantity;
            await _inventoryRepository.UpdateInventoryAsync(inventory);
        }
    }
}
