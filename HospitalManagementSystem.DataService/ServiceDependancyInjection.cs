using AutoMapper;
using HospitalManagementSystem.DataService.Abstracts;
using HospitalManagementSystem.DataService.Implementations;
using HospitalManagementSystem.DataService.Mapping.AdminMapping;
using HospitalManagementSystem.DataService.Mapping.PatientMapping;
using HospitalManagementSystem.DataService.Mapping.RelativeMapping;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagementSystem.DataService;

public static class ServiceDependancyInjection
{
    public static IServiceCollection AddAutoMapperDependancy(this IServiceCollection services)
    {
        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new PatientProfile());
            mc.AddProfile(new RelativeProfile());
            mc.AddProfile(new AdminProfile());
        });
        IMapper mapper = mappingConfig.CreateMapper();
        services.AddSingleton(mapper);
        return services;
    }

    public static IServiceCollection AddDataServiceDependancy(this IServiceCollection services)
    {
        services.AddTransient<IPatientService, PatientService>();
        services.AddTransient<IRelativeService, RelativeService>();
        services.AddTransient<IAdminService, AdminService>();
        return services;
    }

}
