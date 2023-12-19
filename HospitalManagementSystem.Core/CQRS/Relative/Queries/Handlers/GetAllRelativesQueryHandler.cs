using HospitalManagementSystem.Core.CommonUtilites;
using HospitalManagementSystem.Core.CQRS.Relative.Queries.Models;
using HospitalManagementSystem.DataService.DTOs.Relative;
using HospitalManagementSystem.Infrastructure.DapperQueries.RelativeQueries;
using MediatR;

namespace HospitalManagementSystem.Core.CQRS.Relative.Queries.Handlers;

public sealed class GetAllRelativesQueryHandler
    : IRequestHandler<GetAllRelativesQuery, GenericResult<IQueryable<RelativeReadDTO>>>
{
    private readonly IRelativeQuery _relativeQuery;

    public GetAllRelativesQueryHandler(IRelativeQuery relativeQuery)
    {
        _relativeQuery = relativeQuery;
    }

    public Task<GenericResult<IQueryable<RelativeReadDTO>>> Handle(GetAllRelativesQuery request, CancellationToken cancellationToken)
    {
        var relatives = _relativeQuery.GetAll();
        if (relatives is null)
        {
            return Task.FromResult(GenericResult<IQueryable<RelativeReadDTO>>.Failure(new Error("No Relative Found")));
        }
        var relativesReadDTO = relatives.Select(relative => new RelativeReadDTO
        {
            Id = relative.Id,
            FirstName = relative.FirstName,
            LastName = relative.LastName,
            Address = relative.Address,
            SSN = relative.SSN,
            BirthDate = relative.BirthDate
        });
        return Task.FromResult(GenericResult<IQueryable<RelativeReadDTO>>.Success(relativesReadDTO));
    }
}
