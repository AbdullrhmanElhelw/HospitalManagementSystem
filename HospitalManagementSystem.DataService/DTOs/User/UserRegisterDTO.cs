using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.DataService.DTOs.User;

public record UserRegisterDTO
{
    [Required]
    [MinLength(2)]
    [MaxLength(20)]
    public string FirstName { get; init; } = string.Empty;

    [MinLength(2)]
    [MaxLength(20)]
    [Required]
    public string LastName { get; init; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; init; } = string.Empty;

    [Required]
    [MinLength(8)]
    [MaxLength(20)]
    public string Password { get; init; } = string.Empty;

    [Required]
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; init; } = string.Empty;
}
