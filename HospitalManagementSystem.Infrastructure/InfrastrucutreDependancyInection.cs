using HospitalManagementSystem.Infrastructure.DapperQueries;
using HospitalManagementSystem.Infrastructure.DapperQueries.PatientQuery;
using HospitalManagementSystem.Infrastructure.DapperQueries.RelativeQueries;
using HospitalManagementSystem.Infrastructure.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagementSystem.Infrastructure;

public static class InfrastrucutreDependancyInection
{
    public static IServiceCollection AddInfrastructureDependancies(this IServiceCollection services)
    {
        services.AddTransient<IUnitOfWork,UnitOfWork.UnitOfWork>();
        services.AddTransient<IPatientQuery, PatientQuery>();
        services.AddTransient<IRelativeQuery, RelativeQuery>();
        return services;
    }
}
