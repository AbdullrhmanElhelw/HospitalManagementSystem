using HospitalManagementSystem.Core.CommonUtilites;
using HospitalManagementSystem.DataService.DTOs.Patient;
using MediatR;


namespace HospitalManagementSystem.Core.CQRS.Patient.Queries.Models
{
    public record GetPatientQuery(int id) 
        : IRequest<GenericResult<PatientReadDTO>>;
}
