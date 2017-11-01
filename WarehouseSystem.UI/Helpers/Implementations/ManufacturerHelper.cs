using System.Collections.Generic;
using System.Linq;
using WarehouseSystem.DataAccess;
using WarehouseSystem.Repository.Interfaces;
using WarehouseSystem.UI.Helpers.Interfaces;
using WarehouseSystem.UI.Models;

namespace WarehouseSystem.UI.Helpers.Implementations
{
    public class ManufcaturerHelper : IManufacturerHelper
    {
        private readonly IManufacturerRepository manufacturerRepository;

        public ManufcaturerHelper(IManufacturerRepository manufacturerRepository)
        {
            this.manufacturerRepository = manufacturerRepository;
        }

        public IList<ManufacturerViewList> GetManufacturers()
        {
            return manufacturerRepository.GetManufacturers().Select(CreateManufacturerViewList).ToList();
        }

        public ManufacturerView GetManufacturer(long id)
        {
            var manufacturer = manufacturerRepository.GetManufacturer(id);
            return manufacturer == null ? null : CreateManufacturerView(manufacturer);
        }

        public void Save(ManufacturerView manufacturerView)
        {
            Manufacturer manufacturer = manufacturerView.Id.HasValue ? Get(manufacturerView.Id.Value) : new Manufacturer();
            UpdateManufacturer(manufacturer, manufacturerView);
            manufacturerRepository.Save(manufacturer);
        }

        private Manufacturer Get(long id)
        {
            return manufacturerRepository.GetManufacturer(id);
        }

        private ManufacturerView CreateManufacturerView(Manufacturer manufacturer)
        {
            return new ManufacturerView
            {
                Id = manufacturer.Id,
                CompanyCode = manufacturer.CompanyCode,
                Country = manufacturer.Country,
                Tittle = manufacturer.Tittle
            };
        }

        private ManufacturerViewList CreateManufacturerViewList(Manufacturer manufacturer)
        {
            return new ManufacturerViewList
            {
                Id = manufacturer.Id,
                Tittle = manufacturer.Tittle
            };
        }

        private void UpdateManufacturer(Manufacturer manufacturer, ManufacturerView manufacturerView)
        {
            manufacturer.Id = manufacturerView.Id;
            manufacturer.CompanyCode = manufacturerView.CompanyCode;
            manufacturer.Country = manufacturerView.Country;
            manufacturer.Tittle = manufacturerView.Tittle;
        }
    }
}