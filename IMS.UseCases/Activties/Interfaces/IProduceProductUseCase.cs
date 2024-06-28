using IMS.CoreBusiness;

namespace IMS.UseCases.Activties.Interfaces
{
    public interface IProduceProductUseCase
    {
        Task ExecuteAsyn(string productionNumber, Product product, int quantity, string doneBy);
    }
}