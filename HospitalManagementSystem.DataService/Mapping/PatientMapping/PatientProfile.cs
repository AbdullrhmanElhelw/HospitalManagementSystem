using AutoMapper;
using HospitalManagementSystem.DataService.DTOs.Patient;
using HospitalManagementSystem.Entites.Entites;

namespace HospitalManagementSystem.DataService.Mapping.PatientMapping;

public class PatientProfile : Profile
{
    public PatientProfile()
    {
        CreateMap<Patient,PatientReadDTO>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.address, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.dateOfBirth, opt => opt.MapFrom(src => src.BirthDate))
            .ConstructUsing (src => new PatientReadDTO(src.Id,src.Name,src.Address,src.BirthDate));

        CreateMap<PatientCreateDTO, Patient>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.address))
            .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.dateOfBirth))
            .ForMember(dest => dest.HospitalAdminId, opt => opt.MapFrom(src => src.adminId));

        CreateMap<Patient,PatientCreateDTO>()
            .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.address, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.dateOfBirth, opt => opt.MapFrom(src => src.BirthDate))
            .ForMember(dest => dest.adminId, opt => opt.MapFrom(src => src.HospitalAdminId))
            .ConstructUsing(src => new PatientCreateDTO(src.Name,src.Address,src.BirthDate,src.HospitalAdminId));

        CreateMap<PatientUpdateDTO, Patient>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.address))
            .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.dateOfBirth));

        CreateMap<Patient,PatientUpdateDTO>()
            .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.address, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.dateOfBirth, opt => opt.MapFrom(src => src.BirthDate));

        CreateMap<PatientProfilePictureCreateDTO, Image>();
    }
}
