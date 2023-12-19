

namespace HospitalManagementSystem.DataService.DTOs.Relative;

public record RelativeUpdateDTO
    (string Id, string FirstName, string LastName, string PhoneNumber, string Address,string SSN,DateTime DateOfBirth);