using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Entites.Entites;

[PrimaryKey(nameof(PatientId), nameof(MedicineId))]
public class PatientMedicine
{
    public int PatientId { get; set; }
    public int MedicineId { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    public DateTime DateUpdated { get; set; }

    public Patient? Patient { get; set; }
    public Medicine? Medicine { get; set; }
}
