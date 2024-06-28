using IMS.CoreBusiness;

namespace IMS.UseCases.PluginInterfaces
{
    public interface IInventoryRepository
    {
        Task AddInventoryAsync(Inventory inventory);
        Task DeleteInventoryByIdAsync(int inventoryId);
        Task UpdateInventoryAsync(Inventory inventory);
        Task<Inventory> GetInventoryById(int inventoriesId);
        Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name);
    }
}
