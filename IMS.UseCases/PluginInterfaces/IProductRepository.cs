using IMS.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.PluginInterfaces
{
    public interface IProductRepository
    {
        Task AddProductAsync(Product product);
        Task DeleteProductByIdAsync(int productId);
        Task UpdateProductAsync(Product product);
        Task<Product> GetProductById(int productId);
        Task<IEnumerable<Product>> GetProductByNameAsync(string name);
    }
}
