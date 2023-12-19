namespace HospitalManagementSystem.DataService.DTOs.Relative;

public record RelativeReadDTO
{
    public string? Id { get; init; } 
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string Address { get; init; } = string.Empty;
    public string SSN { get; init; } = string.Empty;
    public DateTime BirthDate { get; init; }
}
