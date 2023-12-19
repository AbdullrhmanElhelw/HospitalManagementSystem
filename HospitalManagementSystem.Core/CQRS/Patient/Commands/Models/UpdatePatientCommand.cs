using HospitalManagementSystem.DataService.DTOs.Patient;
using MediatR;

namespace HospitalManagementSystem.Core.CQRS.Patient.Commands.Models;

public sealed record UpdatePatientCommand 
    (int id, PatientUpdateDTO PatientUpdateDTO) : IRequest<PatientUpdateDTO>;
