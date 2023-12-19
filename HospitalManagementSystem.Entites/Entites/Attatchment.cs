namespace HospitalManagementSystem.Entites.Entites;

public class Attatchment
{
    // Patient Files Like X-Ray, MRI, CT-Scan, etc. Store the content in the database 
    public int Id { get; set; }
    public byte[] File { get; set; } = Array.Empty<byte>();
    public string FileExtension { get; set; } = string.Empty;
    public string FileType { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    public DateTime DateUpdated { get; set; }
    public int PatientId { get; set; }
    public Patient? Patient { get; set; }
}
