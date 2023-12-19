namespace HospitalManagementSystem.DataService.DTOs.Report;

public record ReportCreateDTO
{
    public int PatientId { get; init; }
    public string PatientName { get; init; } = string.Empty;
    public DateTime DateOfBirth { get; init; }
    public string Address { get; init; } = string.Empty;
    public string ReportType { get; init; } = string.Empty;

    public DateTime CreatedDate { get; init; }
    public string ReportName { get; init; } = string.Empty;
    public string ReportDescription { get; init; } = string.Empty;

}