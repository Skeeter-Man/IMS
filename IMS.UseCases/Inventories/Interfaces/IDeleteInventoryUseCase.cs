using IMS.CoreBusiness;

namespace IMS.UseCases.Inventories
{
    public interface IDeleteInventoryUseCase
    {
        Task ExecuteAsync(Inventory inventory);
    }
}