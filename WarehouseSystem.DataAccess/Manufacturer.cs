using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSystem.DataAccess
{
    public class Manufacturer
    {
        [Key]
        public long? Id { get; set; }

        [Required]
        public string Tittle { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string CompanyCode { get; set; }

        public ICollection<ProductModel> ProductModels { get; set; }
    }
}
