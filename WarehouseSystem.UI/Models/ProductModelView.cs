using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WarehouseSystem.UI.Models
{
    public class ProductModelView
    {
        public long? Id { get; set; }

        [DisplayName("Model number")]
        [Required]
        [MaxLength(50)]
        public string ModelNumber { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("Model title")]
        public string Title { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

        [DisplayName("Manufacturer")]
        [Required]
        public long? ManufacturerId { get; set; }
    }
}