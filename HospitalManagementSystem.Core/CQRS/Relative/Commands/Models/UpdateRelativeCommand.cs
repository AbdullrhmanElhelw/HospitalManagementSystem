using HospitalManagementSystem.Core.CommonUtilites;
using HospitalManagementSystem.DataService.DTOs.Relative;
using MediatR;

namespace HospitalManagementSystem.Core.CQRS.Relative.Commands.Models;

public sealed record UpdateRelativeCommand(RelativeUpdateDTO UpdateDTO) : IRequest<Result>;

