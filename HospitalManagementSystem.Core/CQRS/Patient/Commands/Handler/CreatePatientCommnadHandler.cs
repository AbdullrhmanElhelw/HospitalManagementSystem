using AutoMapper;
using HospitalManagementSystem.Core.CQRS.Patient.Commands.Models;
using HospitalManagementSystem.DataService.Abstracts;
using HospitalManagementSystem.DataService.DTOs.Patient;
using MediatR;

namespace HospitalManagementSystem.Core.CQRS.Patient.Commands.Handler;

public class CreatePatientCommnadHandler : IRequestHandler<CreatePatientCommand, PatientCreateDTO>
{
    private readonly IPatientService _patientService;
    private readonly IMapper _mapper;

    public CreatePatientCommnadHandler(IPatientService patientService, IMapper mapper)
    {
        _patientService = patientService;
        _mapper = mapper;
    }

    public Task<PatientCreateDTO> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
    {
        var mappedPatient = _mapper.Map<Entites.Entites.Patient>(request.PatientCreateDTO);
        var patient = _patientService.Create(_mapper.Map<PatientCreateDTO>(mappedPatient));
        return Task.FromResult(patient);
    }
}
