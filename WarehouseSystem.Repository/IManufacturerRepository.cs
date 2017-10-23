using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystem.DataAccess;

namespace WarehouseSystem.Repository
{
    public interface IManufacturerRepository
    {
        IList<Manufacturer> GetManufacturers();

        Manufacturer GetManufacturer(long id);

        void Save(Manufacturer manufacturer);
    }
}
