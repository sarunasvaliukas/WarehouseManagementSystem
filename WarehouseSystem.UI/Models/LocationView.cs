using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WarehouseSystem.UI.Models
{
    public class LocationView
    {
        public long? Id { get; set; }

        public string Room { get; set; }

        public string Section { get; set; }

        [DisplayName("Warehouse")]
        public long? WarehouseId { get; set; }
    }
}