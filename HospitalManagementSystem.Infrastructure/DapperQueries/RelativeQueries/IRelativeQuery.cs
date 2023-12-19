using HospitalManagementSystem.Entites.Entites;

namespace HospitalManagementSystem.Infrastructure.DapperQueries.RelativeQueries;

public interface IRelativeQuery : IBaseQuery<Relative>
{
    Relative? FindById(string id);
    IQueryable<Relative> FindRelativesByName(string name);
}
