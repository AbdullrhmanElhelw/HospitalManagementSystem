using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Entites.Entites;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string SSN { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; } 

    [NotMapped]
    public string FullName
    {
        get => $"{FirstName} {LastName}";
    }
}
