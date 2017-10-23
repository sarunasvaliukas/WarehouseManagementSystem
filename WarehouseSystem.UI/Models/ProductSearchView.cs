using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WarehouseSystem.UI.Models
{
    public class ProductSearchModel
    {
        public long? ProductModelId { get; set; }

        public SelectList ProductModels { get; set; }

        public IEnumerable<ProductView> Products { get; set; }
    }
}