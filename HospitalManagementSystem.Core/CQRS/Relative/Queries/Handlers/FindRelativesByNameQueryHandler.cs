using AutoMapper;
using HospitalManagementSystem.Core.CommonUtilites;
using HospitalManagementSystem.Core.CQRS.Relative.Queries.Models;
using HospitalManagementSystem.DataService.DTOs.Relative;
using HospitalManagementSystem.Infrastructure.DapperQueries.PatientQuery;
using HospitalManagementSystem.Infrastructure.DapperQueries.RelativeQueries;
using MediatR;


namespace HospitalManagementSystem.Core.CQRS.Relative.Queries.Handlers;

public sealed class FindRelativesByNameQueryHandler(IMapper mapper, IRelativeQuery relativeQuery) 
    : IRequestHandler<FindRelativesByNameQuery, GenericResult<IQueryable<RelativeReadDTO>>>
{
    private readonly IMapper _mapper = mapper;
    private readonly IRelativeQuery _relativeQuery = relativeQuery;

    public  Task<GenericResult<IQueryable<RelativeReadDTO>>> Handle(FindRelativesByNameQuery request, CancellationToken cancellationToken)
    {
        var relatives = _relativeQuery.FindRelativesByName(request.Name);
        if (relatives is null)
            return Task.FromResult(GenericResult<IQueryable<RelativeReadDTO>>.Failure(new Error("No relatives found")));
        var relativesDTO = relatives.Select(relative => _mapper.Map<RelativeReadDTO>(relative));

        return Task.FromResult(GenericResult<IQueryable<RelativeReadDTO>>.Success(relativesDTO));
    }
}