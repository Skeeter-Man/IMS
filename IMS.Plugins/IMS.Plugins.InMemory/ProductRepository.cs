using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products;
        public ProductRepository()
        {
            _products = new List<Product>()
            {
                new Product { ProductId = 1, ProductName = "InMemory Bike", Quantity = 10, Price = 150 },
                new Product { ProductId = 2, ProductName = "InMemory Car", Quantity = 5, Price = 25000 }
            };
        }

        public Task AddProductAsync(Product product)
        {
            if (_products.Any(x => x.ProductName.Equals(product.ProductName, StringComparison.OrdinalIgnoreCase)))
            { return Task.CompletedTask; }

            var maxId = _products.Max(x => x.ProductId) + 1;
            product.ProductId = maxId;

            _products.Add(product);

            return Task.CompletedTask;
        }

        public Task DeleteProductByIdAsync(int productId)
        {
            var prodToDelete = _products.FirstOrDefault(x => x.ProductId == productId);
            if (prodToDelete != null)
            {
                _products.Remove(prodToDelete);
            }

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Product>> GetProductByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_products);

            return _products.Where(x => x.ProductName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<Product?> GetProductByIdAsync(int productId)
        {
            var prod = _products.FirstOrDefault(x => x.ProductId == productId);
            var newProd = new Product();
            if (prod != null)
            {
                newProd.ProductId = prod.ProductId;
                newProd.ProductName = prod.ProductName;
                newProd.Price = prod.Price;
                newProd.Quantity = prod.Quantity;
                newProd.ProductInventories = new List<ProductInventory>();
                if (prod.ProductInventories != null)
                {
                    foreach (var prodInv in prod.ProductInventories)
                    {
                        var newProdInv = new ProductInventory
                        {
                            InventoryId = prodInv.InventoryId,
                            ProductId = prodInv.ProductId,
                            Product = prod,
                            Inventory = new Inventory(),
                            InventoryQuantity = prodInv.InventoryQuantity
                        };

                        if (prodInv.Inventory != null)
                        {
                            newProdInv.Inventory.InventoryId = prodInv.Inventory.InventoryId;
                            newProdInv.Inventory.InventoryName = prodInv.Inventory.InventoryName;
                            newProdInv.Inventory.Price = prodInv.Inventory.Price;
                            newProdInv.Inventory.Quantity = prodInv.Inventory.Quantity;
                        }

                        newProd.ProductInventories.Add(newProdInv);
                    }
                }
            }

            return await Task.FromResult(newProd);
        }

        public async Task UpdateProductAsync(Product product)
        {
            // To prevent different product from having the same name
            if (_products.Any(x => x.ProductId != product.ProductId &&
                x.ProductName.ToLower() == product.ProductName.ToLower())) return;

            var prodToUpdate = _products.FirstOrDefault(x => x.ProductId == product.ProductId);
            if (prodToUpdate != null)
            {
                prodToUpdate.ProductName = product.ProductName;
                prodToUpdate.Price = product.Price;
                prodToUpdate.Quantity = product.Quantity;
                prodToUpdate.ProductInventories = product.ProductInventories;
            }
            return;
        }
    }
}
