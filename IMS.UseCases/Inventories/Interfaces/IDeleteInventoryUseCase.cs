using IMS.CoreBusiness;

namespace IMS.UseCases.Inventories
{
    public interface IDeleteInventoryByIdUseCase
    {
        Task ExecuteAsync(int inventoryId);
    }
}