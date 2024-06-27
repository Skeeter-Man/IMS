using IMS.CoreBusiness;

namespace IMS.UseCases.Products.Interfaces
{
    public interface IViewProductsByNameUseCases
    {
        Task<IEnumerable<Product>> ExecuteAsync(string name = "");
    }
}