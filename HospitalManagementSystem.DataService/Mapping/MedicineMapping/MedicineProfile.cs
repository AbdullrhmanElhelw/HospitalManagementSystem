using AutoMapper;
using HospitalManagementSystem.DataService.DTOs.Medicine;
using HospitalManagementSystem.Entites.Entites;

namespace HospitalManagementSystem.DataService.Mapping.MedicineMapping;

public class MedicineProfile : Profile
{
    public MedicineProfile()
    {
        CreateMap<MedicineCreateDTO, Medicine>();
    }
}
