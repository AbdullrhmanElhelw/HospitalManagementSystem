using HospitalManagementSystem.Core.CommonUtilites;
using HospitalManagementSystem.DataService.DTOs.Relative;
using MediatR;

namespace HospitalManagementSystem.Core.CQRS.Relative.Queries.Models;

public record GetAllRelativesQuery()
    : IRequest<GenericResult<IQueryable<RelativeReadDTO>>>;

