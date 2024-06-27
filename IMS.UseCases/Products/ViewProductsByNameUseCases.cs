using IMS.CoreBusiness;
using IMS.UseCases.Inventories;
using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.Products.Interfaces;

namespace IMS.UseCases.Products
{
    public class ViewProductsByNameUseCases : IViewProductsByNameUseCases
    {
        private readonly IProductRepository _productRepository;

        public ViewProductsByNameUseCases(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> ExecuteAsync(string name = "")
        {
            return await _productRepository.GetProductByNameAsync(name);
        }
    }
}
