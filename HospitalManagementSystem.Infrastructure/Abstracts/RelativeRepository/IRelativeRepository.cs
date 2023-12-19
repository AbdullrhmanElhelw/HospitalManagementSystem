using HospitalManagementSystem.Entites.Entites;
using HospitalManagementSystem.Infrastructure.BaseRepository;
using Microsoft.AspNetCore.JsonPatch;

namespace HospitalManagementSystem.Infrastructure.Abstracts.RelativeRepository;

public interface IRelativeRepository : IRepository<Relative>
{
    void PartialUpdate(string id, JsonPatchDocument relativePatch);
}
