using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystem.DataAccess;

namespace WarehouseSystem.Repository
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