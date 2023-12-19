namespace HospitalManagementSystem.DataService.DTOs.User;

public record MRIUploadDTO
{
    public string HospitalAdminId{ get; init; }
    public byte[]? Picture { get; init; }
    public string FileExtension { get; init; } = string.Empty;
    public string FileType { get; init; } = string.Empty;
    public string FileName { get; init; } = string.Empty;

    public MRIUploadDTO(byte[]? picture)
    {
        Picture = picture;
    }
}
