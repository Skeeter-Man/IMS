using IMS.CoreBusiness;

namespace IMS.UseCases.Products.Interfaces
{
    public interface IViewProductByProductIdUseCase
    {
        Task<Product?> ExecuteAsync(int productId);
    }
}