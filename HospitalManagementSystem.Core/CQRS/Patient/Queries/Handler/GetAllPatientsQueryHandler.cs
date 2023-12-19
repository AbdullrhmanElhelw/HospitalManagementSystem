using HospitalManagementSystem.Core.CQRS.Patient.Queries.Models;
using HospitalManagementSystem.DataService.Abstracts;
using HospitalManagementSystem.DataService.DTOs.Patient;
using MediatR;

namespace HospitalManagementSystem.Core.CQRS.Patient.Queries.Handler;

public class GetAllPatientsQueryHandler : IRequestHandler<GetAllPatientsQuery, List<PatientReadDTO>>
{
    private readonly IPatientService _patientService;

    public GetAllPatientsQueryHandler(IPatientService patientService)
    {
        _patientService = patientService;
    }

    public Task<List<PatientReadDTO>> Handle(GetAllPatientsQuery request, CancellationToken cancellationToken)
    {
       return Task.FromResult(_patientService.GetAll().ToList());
    }
}
