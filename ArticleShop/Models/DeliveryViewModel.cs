using System.ComponentModel.DataAnnotations;

namespace ArticleShop.Models
{
    public class DeliveryViewModel
    {
        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? City { get; set; }

        [Required]
        public string? Street { get; set; }

        [Required]
        public string? HouseNumber { get; set; }

        [Required]
        public string? PostalCode { get; set; }
    }
}
