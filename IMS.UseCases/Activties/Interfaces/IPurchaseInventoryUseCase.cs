using IMS.CoreBusiness;

namespace IMS.UseCases.Activties.Interfaces
{
    public interface IPurchaseInventoryUseCase
    {
        Task ExecuteAsync(string poNumber, Inventory inventory, int quantity, string doneBy);
    }
}