using HospitalManagementSystem.Entites.Entites;
using HospitalManagementSystem.Infrastructure.BaseRepository;
using HospitalManagementSystem.Infrastructure.Context.EF_Context;
using Microsoft.AspNetCore.JsonPatch;

namespace HospitalManagementSystem.Infrastructure.Abstracts.RelativeRepository;

public class RelativeRepository(EFDbContext dbContext) : Repository<Relative>(dbContext), IRelativeRepository
{
    private readonly EFDbContext _dbContext = dbContext;

    public void PartialUpdate(string id, JsonPatchDocument relativePatch)
    {
        var relative = _dbContext.Relatives.FirstOrDefault(x => x.Id == id);
        relativePatch.ApplyTo(relative);
    }
}
