namespace HospitalManagementSystem.Entites.Entites;

public class Medicine
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Information { get; set; } = string.Empty;
    public int ? ImageId { get; set; }
    public Image? Image { get; set; }

    public DateTime SetedAt { get; set; } = DateTime.UtcNow;
    public DateTime AvilableFor { get; set; }
    public DateTime TakedAt { get; set; } 
    public string HospitalAdminId { get; set; }
    public HospitalAdmin? HospitalAdmin { get; set; }
}
