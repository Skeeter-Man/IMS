using IMS.CoreBusiness;

namespace IMS.UseCases.Activties.Interfaces
{
    public interface ISellProductUseCase
    {
        Task ExecuteAsync(string salesOrderNumber, Product product, int quantity, string doneBy);
    }
}