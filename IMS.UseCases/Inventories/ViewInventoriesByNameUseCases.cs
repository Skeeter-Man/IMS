using IMS.CoreBusiness;
using IMS.UseCases.Inventories.Interfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.Inventories
{
    public class ViewProductsByNameUseCases : IViewInventoriesByNameUseCases
    {
        private readonly IInventoryRepository _inventoryRepository;

        public ViewProductsByNameUseCases(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public async Task<IEnumerable<Inventory>> ExecuteAsyn(string name = "")
        {
            return await _inventoryRepository.GetInventoriesByNameAsync(name);
        }
    }
}
