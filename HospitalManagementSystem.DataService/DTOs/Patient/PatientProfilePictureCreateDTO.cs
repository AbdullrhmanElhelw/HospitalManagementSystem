namespace HospitalManagementSystem.DataService.DTOs.Patient;

public record PatientProfilePictureCreateDTO
{
    public int PatientId { get; init; }
    public byte[]? Picture { get; init; } 
    public string FileExtension { get; init; } = string.Empty;
    public string FileType { get; init; } = string.Empty;
    public string FileName { get; init; } = string.Empty;

    public PatientProfilePictureCreateDTO(byte[]?picture)
    {
        Picture = picture;
    }

}

