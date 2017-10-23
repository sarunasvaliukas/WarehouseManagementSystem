using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarehouseSystem.API.Models
{
    public class ProductManufacturerModel
    {
        public long? Id { get; set; }

        public string ModelNumber { get; set; }

        public string Manufacturer { get; set; }

        public int ProductQuantity { get; set; }
    }
}