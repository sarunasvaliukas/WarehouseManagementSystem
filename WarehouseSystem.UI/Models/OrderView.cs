using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WarehouseSystem.UI.Models
{
    public class OrderView
    {
        public long? Id { get; set; }

        [DisplayName("Orderer")]
        public string StoreName { get; set; }

        public virtual ProductModelView ProductModel { get; set; }

        [DisplayName("Quantity of products")]
        public int ProductQuantity { get; set; }
    }
}