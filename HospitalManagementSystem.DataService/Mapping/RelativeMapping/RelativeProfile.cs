using AutoMapper;
using HospitalManagementSystem.DataService.DTOs.Relative;
using HospitalManagementSystem.Entites.Entites;
using Microsoft.AspNetCore.JsonPatch;

namespace HospitalManagementSystem.DataService.Mapping.RelativeMapping;

public class RelativeProfile : Profile
{
    public RelativeProfile()
    {
        CreateMap<Relative, RelativeReadDTO>();
        CreateMap<RelativeUpdateDTO, Relative>()
            .ForMember(des => des.BirthDate, opt => opt.MapFrom(src => src.DateOfBirth));
        CreateMap<Relative, RelativeUpdateDTO>()
            .ForMember(des => des.DateOfBirth, opt => opt.MapFrom(src => src.BirthDate))
            .ConstructUsing(x => new RelativeUpdateDTO(x.Id, x.FirstName, x.LastName, x.PhoneNumber!, x.Address, x.SSN, x.BirthDate));

    }
}
