using DateEntry.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User
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
    [Required]
    [MinLength(8)]
    public string Password { get; set; }
    public int UserTypeId { get; set; }

    [ForeignKey("UserTypeId")]
    public virtual UserType UserType { get; set; }
}
