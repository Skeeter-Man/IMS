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
    public class ProduceProductUseCase : IProduceProductUseCase
    {
        private readonly IProductTransactionRepository _productTransactionRepository;
        private readonly IProductRepository _productRepository;

        public ProduceProductUseCase(
            IProductTransactionRepository productTransactionRepository,
            IProductRepository productRepository)
        {
            _productTransactionRepository = productTransactionRepository;
            _productRepository = productRepository;
        }
        public async Task ExecuteAsyn(string productionNumber, Product product, int quantity, string doneBy)
        {
            // Add transaction record
            this._productTransactionRepository.ProduceAsync(productionNumber, product, quantity, doneBy);

            // Decrease the quantity of inventory

            // Update the quantity of the product
            product.Quantity += quantity;
            await this._productRepository.UpdateProductAsync(product);
        }
    }
}
