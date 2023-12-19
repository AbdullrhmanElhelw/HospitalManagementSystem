using HospitalManagementSystem.DataService.DTOs.Patient;
using MediatR;

namespace HospitalManagementSystem.Core.CQRS.Patient.Queries.Models;

public record GetAllPatientsQuery():IRequest<List<PatientReadDTO>>;
