using HospitalManagementSystem.Core.CommonUtilites;
using HospitalManagementSystem.DataService.DTOs.Patient;
using MediatR;

namespace HospitalManagementSystem.Core.CQRS.Patient.Commands.Models;

public sealed record CreateMulitPatientsCommand
    (List<PatientCreateDTO> PatientCreateDTOs) : IRequest<Result>;
