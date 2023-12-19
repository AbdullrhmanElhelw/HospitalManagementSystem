using HospitalManagementSystem.Core.CommonUtilites;
using HospitalManagementSystem.Core.CQRS.Patient.Commands.Models;
using HospitalManagementSystem.DataService.Abstracts;
using MediatR;

namespace HospitalManagementSystem.Core.CQRS.Patient.Commands.Handler;

public class CreateMulitPatientsCommandHandler
    : IRequestHandler<CreateMulitPatientsCommand, Result>
{
    private readonly IPatientService _patientService;

    public CreateMulitPatientsCommandHandler(IPatientService patientService)
    {
        _patientService = patientService;
    }

    public Task<Result> Handle(CreateMulitPatientsCommand request, CancellationToken cancellationToken)
    {
        if (request.PatientCreateDTOs.Count == 0)
            return Task.FromResult(Result.Failure(new Error("No Patient Exists To Added")));

        _patientService.AddMultiPatients(request.PatientCreateDTOs);
        return Task.FromResult(Result.Success());
    }
}
