using HospitalManagementSystem.Core.CQRS.Patient.Commands.Models;
using HospitalManagementSystem.DataService.Abstracts;
using HospitalManagementSystem.DataService.DTOs.Patient;
using MediatR;

namespace HospitalManagementSystem.Core.CQRS.Patient.Commands.Handler;

public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand, PatientUpdateDTO>
{
    private readonly IPatientService _patientService;

    public UpdatePatientCommandHandler(IPatientService patientService)
    {
        _patientService = patientService;
    }

    public Task<PatientUpdateDTO> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
    {
        _patientService.Update(request.id, request.PatientUpdateDTO);
        return Task.FromResult(request.PatientUpdateDTO);
    }
}