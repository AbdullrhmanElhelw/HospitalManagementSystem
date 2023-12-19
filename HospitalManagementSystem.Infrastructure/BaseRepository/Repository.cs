using HospitalManagementSystem.Infrastructure.Context.EF_Context;

namespace HospitalManagementSystem.Infrastructure.BaseRepository;

public class Repository<TModel> : IRepository<TModel> where TModel : class
{
    private readonly EFDbContext _context;

    public Repository(EFDbContext context)
    {
        _context = context;
    }

    public void Add(TModel entity) => _context.Set<TModel>().Add(entity);

    public void Delete(TModel entity) => _context.Set<TModel>().Remove(entity);

    public void Update(TModel entity) => _context.Set<TModel>().Update(entity);

    public void AddRange(IEnumerable<TModel> entities) => _context.Set<TModel>().AddRange(entities);

}

