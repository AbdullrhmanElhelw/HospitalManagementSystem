
using HospitalManagementSystem.Core.CommonUtilites;
using HospitalManagementSystem.DataService.DTOs.Relative;
using MediatR;

namespace HospitalManagementSystem.Core.CQRS.Relative.Queries.Models;

public sealed record GetRelativeQuery (string id)
    :IRequest<GenericResult<RelativeReadDTO>>;