using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Entites.Entites;

public class Patient
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;

    public DateTime BirthDate { get; set; }


    [ForeignKey(nameof(HospitalAdmin))]
    public string HospitalAdminId { get; set; }
    public HospitalAdmin? HospitalAdmin { get; set; } 

    public ICollection<Attatchment> Attatchments { get; set; } = new HashSet<Attatchment>();
    public Image? ProfilePicutre { get; set; } 

    public ICollection<Relative> Relatives { get; set; } = new HashSet<Relative>();
    public ICollection<PatientMedicine> PatientMedicines { get; set; } = new HashSet<PatientMedicine>();

}
