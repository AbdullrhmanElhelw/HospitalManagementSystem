using System.Linq.Expressions;

namespace HospitalManagementSystem.Infrastructure.DapperQueries;

public interface IBaseQuery<T> where T : class
{
    T? GetById(int id);
    IQueryable<T> GetAll();
}
