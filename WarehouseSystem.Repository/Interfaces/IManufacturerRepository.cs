using System.Collections.Generic;
using WarehouseSystem.DataAccess;

namespace WarehouseSystem.Repository.Interfaces
{
    public interface IManufacturerRepository
    {
        IList<Manufacturer> GetManufacturers();

        Manufacturer GetManufacturer(long id);

        void Save(Manufacturer manufacturer);
    }
}
