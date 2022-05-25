using System.ComponentModel.DataAnnotations;
namespace Bookstore.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public double Price { get; set; }
        [Required(ErrorMessage = "Price is required")]

        
        public string ShippingType { get; set; }
       

        
    }
}
