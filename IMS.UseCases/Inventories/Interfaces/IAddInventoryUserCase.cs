using IMS.CoreBusiness;

namespace IMS.UseCases.Inventories
{
    public interface IAddInventoryUserCase
    {
        Task ExecuteAsync(Inventory inventory);
    }
}