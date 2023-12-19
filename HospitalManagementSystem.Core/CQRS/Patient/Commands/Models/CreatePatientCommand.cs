using HospitalManagementSystem.DataService.DTOs.Patient;
using MediatR;

namespace HospitalManagementSystem.Core.CQRS.Patient.Commands.Models;

public sealed record CreatePatientCommand
    (
        PatientCreateDTO PatientCreateDTO
    ) : IRequest<PatientCreateDTO>;