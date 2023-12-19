using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Entites.Entites;

public class Relative : ApplicationUser
{
    [ForeignKey(nameof(Patient))]
    public int PatientId { get; set; }  
    public Patient? Patient { get; set; }

}
