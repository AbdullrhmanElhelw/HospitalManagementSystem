using HospitalManagementSystem.Entites.Entites;

namespace HospitalManagementSystem.Infrastructure.DapperQueries.AdminQueries;

public interface IAdminQuery : IBaseQuery<HospitalAdmin>
{
    HospitalAdmin? FindById(string id);
}
