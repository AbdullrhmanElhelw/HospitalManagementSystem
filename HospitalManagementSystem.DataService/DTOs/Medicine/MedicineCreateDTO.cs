using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HospitalManagementSystem.DataService.DTOs.Medicine;

public record MedicineCreateDTO
{
    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string Name { get; set; } = string.Empty;

    [StringLength(100)]
    public string Description { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Information { get; set; } = string.Empty;
    public string HospitalAdminId { get; set; }

    [JsonIgnore]
    public DateTime SetedAt { get; set; } = DateTime.UtcNow;
    [JsonIgnore]
    public DateTime AvilableFor { get; set; } = DateTime.UtcNow + TimeSpan.FromDays(30);

}
