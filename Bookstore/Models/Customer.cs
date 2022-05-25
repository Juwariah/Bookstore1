using System.ComponentModel.DataAnnotations;
namespace Bookstore.Models
{
    public class Customer
    {
        [Key]
        [Required]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Email is required")]
        public char Email { get; set; }

    }
}
