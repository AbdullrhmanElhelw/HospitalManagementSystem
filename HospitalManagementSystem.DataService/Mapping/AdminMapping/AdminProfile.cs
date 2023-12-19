using AutoMapper;
using HospitalManagementSystem.DataService.DTOs.User;
using HospitalManagementSystem.Entites.Entites;

namespace HospitalManagementSystem.DataService.Mapping.AdminMapping;

public class AdminProfile : Profile
{
    public AdminProfile()
    {
        CreateMap<MRIUploadDTO, MRI>();
    }
}
