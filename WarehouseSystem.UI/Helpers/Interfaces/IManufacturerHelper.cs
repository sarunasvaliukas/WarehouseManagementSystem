using System.Collections.Generic;
using WarehouseSystem.UI.Models;

namespace WarehouseSystem.UI.Helpers.Interfaces
{
    public interface IManufacturerHelper
    {
        IList<ManufacturerViewList> GetManufacturers();

        ManufacturerView GetManufacturer(long id);

        void Save(ManufacturerView manufacturerView);
    }
}
