using HospitalManagementSystem.DataService.DTOs.Relative;
using Microsoft.AspNetCore.JsonPatch;

namespace HospitalManagementSystem.DataService.Abstracts;

public interface IRelativeService
{
    RelativeReadDTO? GetRelative(string id);
    void DeleteRelative(string id);
    void UpdateRelative(RelativeUpdateDTO relativeUpdateDTO);

    void UpdateRelative(string id, JsonPatchDocument relativePatchDocument);

}
