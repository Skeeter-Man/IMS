using IMS.CoreBusiness;

namespace IMS.UseCases.Inventories.Interfaces
{
    public interface IAddInventoryUserCase
    {
        Task ExecuteAsync(Inventory inventory);
    }
}