using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSystem.DataAccess
{
    public class Order
    {
        [Key]
        public long? Id { get; set; }

        [Required]
        public string StoreName { get; set; }

        public long? ProductModelId { get; set; }

        [Required]
        [ForeignKey("ProductModelId")]
        public virtual ProductModel ProductModel { get; set; }

        public int ProductQuantity { get; set; }
    }
}
