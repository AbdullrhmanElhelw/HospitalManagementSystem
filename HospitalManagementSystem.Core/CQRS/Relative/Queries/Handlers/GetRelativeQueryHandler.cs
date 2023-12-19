using HospitalManagementSystem.Core.CommonUtilites;
using HospitalManagementSystem.Core.CQRS.Relative.Queries.Models;
using HospitalManagementSystem.DataService.Abstracts;
using HospitalManagementSystem.DataService.DTOs.Relative;
using HospitalManagementSystem.DataService.Implementations;
using HospitalManagementSystem.Infrastructure.DapperQueries.PatientQuery;
using HospitalManagementSystem.Infrastructure.DapperQueries.RelativeQueries;
using MediatR;

namespace HospitalManagementSystem.Core.CQRS.Relative.Queries.Handlers;

public sealed class GetRelativeQueryHandler : IRequestHandler<GetRelativeQuery, GenericResult<RelativeReadDTO>>
{
    private IRelativeQuery  _relativeQuery;
    private IRelativeService _relativeService;

    public GetRelativeQueryHandler(IRelativeQuery relativeQuery, IRelativeService relativeService)
    {
        _relativeQuery = relativeQuery;
        _relativeService = relativeService;
    }

    public Task<GenericResult<RelativeReadDTO>> Handle(GetRelativeQuery request, CancellationToken cancellationToken)
    {
        var relative = _relativeQuery.FindById(request.id);
        if(relative is null)
        {
            return Task.FromResult(GenericResult<RelativeReadDTO>.Failure(PatientErrors.NotFound(request.id)));
        }
        var relativeReadDTO = new RelativeReadDTO
        {
            Id = relative.Id,
            FirstName = relative.FirstName,
            LastName = relative.LastName,
            Address = relative.Address,
            SSN = relative.SSN,
            BirthDate = relative.BirthDate
        };
        return Task.FromResult(GenericResult<RelativeReadDTO>.Success(relativeReadDTO));
    }
}
