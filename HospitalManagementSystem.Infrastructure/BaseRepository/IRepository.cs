namespace HospitalManagementSystem.Infrastructure.BaseRepository;

public interface IRepository <T> where T : class
{
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    void AddRange(IEnumerable<T> entities);
}
