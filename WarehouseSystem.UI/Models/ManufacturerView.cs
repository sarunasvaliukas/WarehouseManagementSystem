using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WarehouseSystem.UI.Models
{
    public class ManufacturerView
    {
        public long? Id { get; set; }

        [Required]
        [MinLength(1)]
        public string Tittle { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Country { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        [DisplayName("Company code")]
        public string CompanyCode { get; set; }
    }
}