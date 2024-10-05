using DateEntry.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    [Required]
    public long Id { get; set; }
    public Guid UserIdentifier { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string ZipCode { get; set; }
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
    public DateTime CreationDate { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime? UpdateDate { get; set; }
    public Guid? UpdatedBy { get; set; }
    public DateTime? DeleteDate { get; set; }
    public Guid? DeletedBy { get; set; }
    public bool IsDeleted { get; set; }
}
