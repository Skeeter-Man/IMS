using IMS.CoreBusiness;
using IMS.UseCases.Activties.Interfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.Activties
{
    public class SellProductUseCase : ISellProductUseCase
    {
        private readonly IProductTransactionRepository _productTransactionRepository;
        private readonly IProductRepository _productRepository;

        public SellProductUseCase(
            IProductTransactionRepository productTransactionRepository,
            IProductRepository productRepository)
        {
            _productTransactionRepository = productTransactionRepository;
            _productRepository = productRepository;
        }
        public async Task ExecuteAsync(string salesOrderNumber, Product product, int quantity, string doneBy)
        {
            await this._productTransactionRepository.SellProductAsync(salesOrderNumber, product, quantity, doneBy);

            product.Quantity -= quantity;
            await this._productRepository.UpdateProductAsync(product);
        }
    }
}
