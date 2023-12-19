using HospitalManagementSystem.Core.CommonUtilites;
using HospitalManagementSystem.Core.CQRS.Relative.Commands.Models;
using HospitalManagementSystem.DataService.Abstracts;
using HospitalManagementSystem.Infrastructure.DapperQueries.RelativeQueries;
using MediatR;

namespace HospitalManagementSystem.Core.CQRS.Relative.Commands.Handlers;

public sealed class UpdateRelativeCommandHandler
    (IRelativeQuery relativeQuery, IRelativeService relativeService) : IRequestHandler<UpdateRelativeCommand, Result>
{
    private readonly IRelativeQuery _relativeQuery = relativeQuery;
    private readonly IRelativeService _relativeService = relativeService;

    public Task<Result> Handle(UpdateRelativeCommand request, CancellationToken cancellationToken)
    {
        var relative = _relativeQuery.FindById(request.UpdateDTO.Id);
        if(relative is null)
        {
            return Task.FromResult(Result.Failure(new Error("Relative not found")));
        }
        _relativeService.UpdateRelative(request.UpdateDTO);
        return Task.FromResult(Result.Success());
    }
}


