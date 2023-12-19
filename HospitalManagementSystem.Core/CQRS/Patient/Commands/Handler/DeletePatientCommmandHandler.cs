using HospitalManagementSystem.Core.CQRS.Patient.Commands.Models;
using HospitalManagementSystem.DataService.Abstracts;
using MediatR;

namespace HospitalManagementSystem.Core.CQRS.Patient.Commands.Handler;

public class DeletePatientCommmandHandler : IRequestHandler<DeletePatientCommand, string>
{
    private readonly IPatientService _patientService;

    public DeletePatientCommmandHandler(IPatientService patientService)
    {
        _patientService = patientService;
    }

    public Task<string> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
    {
        _patientService.Delete(request.id);
        return Task.FromResult("Patient Deleted Successfully");
    }
}
