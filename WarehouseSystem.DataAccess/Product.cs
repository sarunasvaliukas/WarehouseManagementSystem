using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSystem.DataAccess
{
    public class Product
    {
        [Key]
        public long? Id { get; set; }

        [Required]
        public string SerialNumber { get; set; }

        public long? ProductModelId { get; set; }

        public long? LocationId { get; set; }

        [Required]
        [ForeignKey("ProductModelId")]
        public virtual ProductModel ProductModel { get; set; }

        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
