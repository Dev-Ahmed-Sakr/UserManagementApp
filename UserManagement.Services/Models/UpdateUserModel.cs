using System.ComponentModel.DataAnnotations;

namespace UserManagement.Services.Models
{
    public class UpdateUserModel
    {
        [Required]
        public long Id { get; set; }

        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$", ErrorMessage = "Invalid Phone number format. Must follow the USA phone number format (e.g., (123) 456-7890).")]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        [Required]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid ZIP code format. It should be 5 digits or ZIP+4.")]
        public string ZipCode { get; set; }
        public int UserTypeId { get; set; }

    }
}
