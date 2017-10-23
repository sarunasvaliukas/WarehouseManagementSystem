using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarehouseSystem.API.Models
{
    public class OrderModel
    {
        public long? ProductModelId { get; set; }

        public string StoreName { get; set; }

        public int ProductQuantity { get; set; }
    }
}