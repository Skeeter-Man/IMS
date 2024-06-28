using IMS.CoreBusiness;

namespace IMS.UseCases.PluginInterfaces
{
    public interface IProductTransactionRepository
    {
        void ProduceAsync(string productionNumber, Product product, int quantity, string doneBy);
    }
}