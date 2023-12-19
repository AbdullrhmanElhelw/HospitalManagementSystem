using MediatR;

namespace HospitalManagementSystem.Core.CQRS.Patient.Commands.Models;

public sealed record DeletePatientCommand(int id) : IRequest<string>;

