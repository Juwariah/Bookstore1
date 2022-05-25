using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models
{
    public class BookItem
    {
        [Key]
        public int BookItemId { get; set; }

        public string AuthorName { get; set; }

        [Required(ErrorMessage = "Full Name is required")]

        public string Title { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [MaxLength(64, ErrorMessage = "Length of description cannot be greater than 64 characters")]
        [MinLength(2, ErrorMessage = "Length of description cannot be less than 2 characters")]
        public int PublicationDate { get; set; }
        [Required(ErrorMessage = "Publication date is required")]
        public string Genre { get; set; }

        public double Price { get; set; }
        [Required(ErrorMessage = "Price is required")]


    }
}
