using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Entites.Entites;

public class MRI
{
    public int Id { get; set; }
    public byte[] Picture { get; set; } = Array.Empty<byte>();
    public string FileExtension { get; set; } = string.Empty;
    public string FileType { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    public DateTime DateUpdated { get; set; }

    [ForeignKey(nameof(HospitalAdmin))]
    public string HospitalAdminId { get; set; }
    public HospitalAdmin? HospitalAdmin { get; set; }

}
