using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSystem.DataAccess
{
    public class Location
    {
        [Key]
        public virtual long? Id { get; set; }

        public virtual string Room { get; set; }

        public virtual string Section { get; set; }

        public virtual long? WarehouseId { get; set; }

        [Required]
        [ForeignKey("WarehouseId")]
        public virtual Warehouse Warehouse { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
