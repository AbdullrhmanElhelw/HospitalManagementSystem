using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Entites.Entites;
public class Image
{
    public int Id { get; set; }
    public byte[] Picture { get; set; } = Array.Empty<byte>();
    public string FileExtension { get; set; } = string.Empty;
    public string FileType { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    public DateTime DateUpdated { get; set; }


    [ForeignKey(nameof(Patient))]
    public int PatientId { get; set; }

    public Patient? Patient { get; set; }

    [ForeignKey(nameof(Medicine))]
    public int? MedicineId { get; set; }
    public Medicine? Medicine { get; set; }

   
}
