using System.Collections.Generic;
using System.Linq;
using WarehouseSystem.DataAccess;
using WarehouseSystem.Repository.Interfaces;

namespace WarehouseSystem.Repository.Implemanations
{
    public class WarehouseRepository : IWarehouseRepository
    {
        public IList<Warehouse> GetWarehouses()
        {
            using (var dbContext = new WarehouseContext())
            {
                return dbContext.Warehouses.ToList();
            }
        }

        public Warehouse GetWarehouse(long id)
        {
            using (var dbContext = new WarehouseContext())
            {
                return dbContext.Warehouses.FirstOrDefault(w => w.Id == id);
            }
        }
    }
}