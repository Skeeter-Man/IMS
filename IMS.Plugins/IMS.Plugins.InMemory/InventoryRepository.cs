﻿using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory
{
    public class InventoryRepository : IInventoryRepository
    {
        private List<Inventory> _inventories;
        public InventoryRepository()
        {
            _inventories = new List<Inventory>()
            {
                new Inventory { InventoryId = 1, InventoryName = "InMemory Bike Seat", Quantity = 10, Price = 2 },
                new Inventory { InventoryId = 2, InventoryName = "InMemory Bike Body", Quantity = 10, Price = 15 },
                new Inventory { InventoryId = 3, InventoryName = "InMemory Bike Wheel", Quantity = 20, Price = 8 },
                new Inventory { InventoryId = 4, InventoryName = "InMemory Bike Pedal", Quantity = 20, Price = 1 }
            };
        }

        public Task AddInventoryAsync(Inventory inventory)
        {
            if (_inventories.Any(x => x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
            { return Task.CompletedTask; }

            if (_inventories.Count() > 0)
            {
                inventory.InventoryId = _inventories.Max(x => x.InventoryId) + 1;
            }
            else
            {
                inventory.InventoryId = 1;
            }


            _inventories.Add(inventory);

            return Task.CompletedTask;
        }

        public Task DeleteInventoryByIdAsync(int inventoryId)
        {
            var invToDelete = _inventories.FirstOrDefault(x => x.InventoryId == inventoryId);
            if (invToDelete != null)
            {
                _inventories.Remove(invToDelete);
            }

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_inventories);

            return _inventories.Where(x => x.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<Inventory> GetInventoryByIdAsync(int inventoryId)
        {
            var inv = _inventories.First(x => x.InventoryId == inventoryId);
            var newInv = new Inventory
            {
                InventoryId = inv.InventoryId,
                InventoryName = inv.InventoryName,
                Price = inv.Price,
                Quantity = inv.Quantity,
            };

            return await Task.FromResult(newInv);
        }

        public Task UpdateInventoryAsync(Inventory inventory)
        {
            if (_inventories.Any(x => x.InventoryId != inventory.InventoryId &&
                x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
                return Task.CompletedTask;

            var invToUpdate = _inventories.FirstOrDefault(x => x.InventoryId == inventory.InventoryId);
            if (invToUpdate != null)
            {
                invToUpdate.InventoryName = inventory.InventoryName;
                invToUpdate.Quantity = inventory.Quantity;
                invToUpdate.Price = inventory.Price;
            }
            return Task.CompletedTask;
        }
    }
}
