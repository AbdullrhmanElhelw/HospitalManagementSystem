using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.DataService.DTOs.User;

public record UserLoginDTO
{
    [Required]
    [EmailAddress]
    public string Email { get; init; } = string.Empty;

    [Required]
    [MinLength(8)]
    [MaxLength(20)]
    public string Password { get; init; } = string.Empty;
}
