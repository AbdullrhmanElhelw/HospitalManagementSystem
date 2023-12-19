using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.DataService.DTOs.Relative;

public record RelativeCreateDTO
{
    public int PatientId { get; init; }

    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string FirstName { get; init; }

    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string LastName { get; init; }

    [Required]
    [StringLength(14, MinimumLength = 14)]
    public string SSN { get; init; }
}
