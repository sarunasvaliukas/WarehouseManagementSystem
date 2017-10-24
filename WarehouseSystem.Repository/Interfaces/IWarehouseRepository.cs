using System.Collections.Generic;
using WarehouseSystem.DataAccess;

namespace WarehouseSystem.Repository.Interfaces
{
    public interface IWarehouseRepository
    {
        IList<Warehouse> GetWarehouses();

        Warehouse GetWarehouse(long id);
    }
}
