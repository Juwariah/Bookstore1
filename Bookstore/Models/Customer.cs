using System.ComponentModel.DataAnnotations;
namespace Bookstore.Models
{
    public class Customer
    {
       [Key]
        public int CustomerId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "First name is required")] 
        public string LastName { get; set; }
        [Required(ErrorMessage = "Last name is required")] 

        public char Email { get; set; }
        [Required(ErrorMessage = "Email is required")]
    }
}
