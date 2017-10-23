using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystem.DataAccess;

namespace WarehouseSystem.Repository
{
    public interface IWarehouseRepository
    {
        IList<Warehouse> GetWarehouses();

        Warehouse GetWarehouse(long id);
    }
}
