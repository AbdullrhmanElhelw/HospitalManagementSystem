using HospitalManagementSystem.Core.CommonUtilites;
using MediatR;

namespace HospitalManagementSystem.Core.CQRS.Relative.Commands.Models;

public sealed record DeleteRelativeCommand(string Id) : IRequest<Result>;
