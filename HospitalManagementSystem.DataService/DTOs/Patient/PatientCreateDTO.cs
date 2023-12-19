using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.DataService.DTOs.Patient;
public record PatientCreateDTO
    (string name, string address, DateTime dateOfBirth, string adminId)
{
    [Display(Name = "Full Name")]
    [Required(ErrorMessage = "Full Name is required")]
    [MaxLength(20, ErrorMessage = "Full Name cannot be more than 50 characters")]
    [MinLength(2, ErrorMessage = "Full Name cannot be less than 2 characters")]
    public string Name { get; init; } = name;

    [Required(ErrorMessage = "Address is required")]
    [MaxLength(100, ErrorMessage = "Address cannot be more than 50 characters")]
    [MinLength(2, ErrorMessage = "Address cannot be less than 2 characters")]
    public string Address { get; init; } = address;

    [Required(ErrorMessage = "Date of Birth is required")]
    [DataType(DataType.Date)]
    [Display(Name = "Date of Birth")]
    public DateTime DateOfBirth { get; init; }= dateOfBirth;

    [Required(ErrorMessage = "Admin Id is required")]
    [Display(Name = "Admin Id")]
    public string AdminId { get; init; } = adminId;
}
