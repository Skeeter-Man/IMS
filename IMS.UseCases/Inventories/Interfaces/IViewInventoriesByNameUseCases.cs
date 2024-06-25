using IMS.CoreBusiness;

namespace IMS.UseCases.Inventories.Interfaces
{
    public interface IViewInventoriesByNameUseCases
    {
        Task<IEnumerable<Inventory>> ExecuteAsyn(string name = "");
    }
}