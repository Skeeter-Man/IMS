using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.Products.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.Products
{
    public class ViewProductByProductIdUseCase : IViewProductByProductIdUseCase
    {
        private readonly IProductRepository _productRepository;

        public ViewProductByProductIdUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product?> ExecuteAsync(int productId)
        {
            return await _productRepository.GetProductByIdAsync(productId);
        }
    }
}
