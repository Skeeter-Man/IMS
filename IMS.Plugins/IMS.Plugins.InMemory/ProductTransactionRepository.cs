using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory
{
    public class ProductTransactionRepository : IProductTransactionRepository
    {
        private List<ProductTransaction> _productTransactions = new List<ProductTransaction>();

        private readonly IProductRepository _productRepository;
        private readonly IInventoryTransactionRepository _inventoryTransactionRepository;
        private readonly IInventoryRepository _inventoryRepository;

        public ProductTransactionRepository(
            IProductRepository productRepository,
            IInventoryTransactionRepository inventoryTransactionRepository,
            IInventoryRepository inventoryRepository)
        {
            _productRepository = productRepository;
            _inventoryTransactionRepository = inventoryTransactionRepository;
            _inventoryRepository = inventoryRepository;
        }
        public async void ProduceAsync(string productionNumber, Product product, int quantity, string doneBy)
        {
            
            var prod = await this._productRepository.GetProductByIdAsync(product.ProductId);
            if (prod != null)
            {
                foreach (var pi in prod.ProductInventories)
                {
                    if (pi.Inventory != null)
                    {
                        // Add inventory tranaction
                        this._inventoryTransactionRepository.ProduceAsync(productionNumber,
                            pi.Inventory,
                            pi.InventoryQuantity * quantity,
                            doneBy,
                            -1);

                        // Decrease the inventories
                        var inv = await this._inventoryRepository.GetInventoryByIdAsync(pi.InventoryId);
                        inv.Quantity -= pi.InventoryQuantity * quantity;
                        await this._inventoryRepository.UpdateInventoryAsync(inv);
                    }
                }
            }

            // Add product transaction record
            this._productTransactions.Add(new ProductTransaction
            {
                ProductionNumber = productionNumber,
                ProductId = product.ProductId,
                QuantityBefore = product.Quantity,
                ActivityType = ProductTransactionType.ProductProduct,
                QuantityAfter = product.Quantity + quantity,
                TransactionDate = DateTime.UtcNow,
                DoneBy = doneBy
            });
        }

        public Task SellProductAsync(string salesOrderNumber, Product product, int quantity, string doneBy)
        {
            this._productTransactions.Add(new ProductTransaction
            {
                ActivityType = ProductTransactionType.SaleProduct,
                SONumber = salesOrderNumber,
                ProductId = product.ProductId,
                QuantityBefore = product.Quantity,
                QuantityAfter = product.Quantity - quantity,
                TransactionDate= DateTime.UtcNow,
                DoneBy= doneBy,
                UnitPrice = product.Price
            });

            return Task.CompletedTask;
        }
    }
}
