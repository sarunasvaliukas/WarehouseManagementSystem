using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystem.DataAccess;

namespace WarehouseSystem.Repository
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        public IList<Manufacturer> GetManufacturers()
        {
            using (var dbContext = new WarehouseContext())
            {
                return dbContext.Manufacturers.ToList();
            }
        }

        public Manufacturer GetManufacturer(long id)
        {
            using (var dbContext = new WarehouseContext())
            {
                return dbContext.Manufacturers.FirstOrDefault(p => p.Id == id);
            }
        }

        public void Save(Manufacturer manufacturer)
        {
            using (var dbContext = new WarehouseContext())
            {
                if (manufacturer.Id.HasValue)
                {
                    dbContext.Entry(manufacturer).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    dbContext.Manufacturers.Add(manufacturer);
                }

                dbContext.SaveChanges();
            }
        }
    }
}