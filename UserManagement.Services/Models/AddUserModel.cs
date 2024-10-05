using DateEntry.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UserManagement.Services.Models
{
    public class AddUserModel
    {
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
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        public int UserTypeId { get; set; }

    }
}
