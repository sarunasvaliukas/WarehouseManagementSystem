using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WarehouseSystem.API.Models
{
    public class ProductManufacturerModel
    {
        public long? Id { get; set; }

        [DisplayName("Model number")]
        public string ModelNumber { get; set; }

        public string Manufacturer { get; set; }

        [DisplayName("Product quantity")]
        public int ProductQuantity { get; set; }
    }
}