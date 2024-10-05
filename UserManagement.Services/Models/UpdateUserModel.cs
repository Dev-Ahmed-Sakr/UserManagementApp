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
        [Phone]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int UserTypeId { get; set; }

    }
}
