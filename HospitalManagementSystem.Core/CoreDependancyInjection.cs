using iText.Signatures;
using Microsoft.Extensions.DependencyInjection;
using Org.BouncyCastle.Security;
using System.Reflection;

namespace HospitalManagementSystem.Core;

public static class CoreDependancyInjection
{
    public static IServiceCollection AddMeidatrDependencies(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        return services;
    }
}
