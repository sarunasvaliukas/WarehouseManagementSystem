using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSystem.DataAccess
{
    public class ProductModel
    {
        [Key]
        public long? Id { get; set; }

        [Required]
        public string ModelNumber { get; set; }

        [Required]
        public string Title { get; set; }

        public long? ManufacturerId { get; set; }

        [Required]
        [ForeignKey("ManufacturerId")]
        public virtual Manufacturer Manufacturer { get; set; }

        public string Description { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
