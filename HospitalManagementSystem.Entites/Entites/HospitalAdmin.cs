namespace HospitalManagementSystem.Entites.Entites;

public class HospitalAdmin : ApplicationUser
{
    public ICollection<Patient> Patients { get; set; } = new HashSet<Patient>();
    public ICollection<Medicine> Medicines { get; set; } = new HashSet<Medicine>();

}
