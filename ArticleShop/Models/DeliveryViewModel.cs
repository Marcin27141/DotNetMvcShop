using System.ComponentModel.DataAnnotations;

namespace ArticleShop.Models
{
    public class DeliveryViewModel
    {
        [Required(ErrorMessage = "First Name is required")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string City { get; set; }

        [Required]
        public string Street { get; set; }

        [Display(Name = "House Number")]
        [Required]
        public string HouseNumber { get; set; }

        [Display(Name = "Postal Code")]
        [Required]
        public string PostalCode { get; set; }
    }
}
