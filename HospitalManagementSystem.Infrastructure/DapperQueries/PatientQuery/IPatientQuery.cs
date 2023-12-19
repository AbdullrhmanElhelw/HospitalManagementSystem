using HospitalManagementSystem.Entites.Entites;

namespace HospitalManagementSystem.Infrastructure.DapperQueries.PatientQuery;

public interface IPatientQuery : IBaseQuery<Patient>
{
    Patient? FindByName(string name);
    IQueryable<Patient> FindByCreatedDate(DateTime createdDate);
}
