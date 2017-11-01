using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WarehouseSystem.API.Models
{
    public class OrderModel
    {
        public long? Id { get; set; }

        [Required]
        public long? ProductModelId { get; set; }

        [DisplayName("Store name")]
        [Required]
        public string StoreName { get; set; }

        [DisplayName("Quantity")]
        [Required]
        public int ProductQuantity { get; set; }

        public ProductManufacturerModel ProductModel { get; set; }
    }
}