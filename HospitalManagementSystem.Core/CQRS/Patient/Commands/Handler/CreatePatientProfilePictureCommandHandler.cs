using AutoMapper;
using HospitalManagementSystem.Core.CommonUtilites;
using HospitalManagementSystem.Core.CQRS.Patient.Commands.Models;
using HospitalManagementSystem.DataService.Abstracts;
using HospitalManagementSystem.DataService.DTOs.Patient;
using HospitalManagementSystem.Infrastructure.DapperQueries.PatientQuery;
using MediatR;

namespace HospitalManagementSystem.Core.CQRS.Patient.Commands.Handler;

public sealed class CreatePatientProfilePictureCommandHandler
    : IRequestHandler<CreatePatientProfilePictureCommand>
{
    private readonly IPatientQuery _patientQuery;
    private readonly IPatientService _patientService;
    private readonly IMapper _mapper;

    public CreatePatientProfilePictureCommandHandler(IPatientQuery patientQuery,IPatientService patientService, IMapper mapper)
    {
        _patientQuery = patientQuery;
        _mapper = mapper;
        _patientService = patientService;
    }

    Task IRequestHandler<CreatePatientProfilePictureCommand>.Handle
        (CreatePatientProfilePictureCommand request, CancellationToken cancellationToken)
    {
        var patient = _patientQuery.GetById(request.PatientProfilePictureCreateDTO.PatientId);
        if(patient is null)
        {
            return Task.FromResult(Result.Failure(PatientErrors.NotFound(request.PatientProfilePictureCreateDTO.PatientId)));
        }
        _patientService.AddProfilePicture(request.PatientProfilePictureCreateDTO);
        return Task.FromResult(Result.Success());
    }
}