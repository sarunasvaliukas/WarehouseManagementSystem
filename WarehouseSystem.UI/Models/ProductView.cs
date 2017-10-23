using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WarehouseSystem.UI.Models
{
    public class ProductView
    {
        public ProductView()
        {
            Location = new LocationView();
        }

        public long? Id { get; set; }

        [DisplayName("Serial number")]
        [Required]
        public string SerialNumber { get; set; }

        [Required]
        [DisplayName("Product model")]
        public long? ProductModelId { get; set; }

        public LocationView Location { get; set; }
    }
}