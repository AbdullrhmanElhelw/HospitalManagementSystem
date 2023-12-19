using HospitalManagementSystem.Core.CommonUtilites;
using HospitalManagementSystem.Core.CQRS.Relative.Commands.Models;
using HospitalManagementSystem.DataService.Abstracts;
using HospitalManagementSystem.Infrastructure.DapperQueries.RelativeQueries;
using MediatR;

namespace HospitalManagementSystem.Core.CQRS.Relative.Commands.Handlers;

public sealed class DeleteRelativeCommandHandler : IRequestHandler<DeleteRelativeCommand, Result>
{
    private readonly IRelativeQuery _relativeQuery;
    private readonly IRelativeService _relativeService;
    public DeleteRelativeCommandHandler(IRelativeQuery relativeQuery, IRelativeService relativeService)
    {
        _relativeQuery = relativeQuery;
        _relativeService = relativeService;
    }

    public Task<Result> Handle(DeleteRelativeCommand request, CancellationToken cancellationToken)
    {
        var relative = _relativeQuery.FindById(request.Id);
        if(relative is null)
        {
            return Task.FromResult(Result.Failure(new Error("Relative not found"))); 
        }
        _relativeService.DeleteRelative(request.Id);
        return Task.FromResult(Result.Success());
    }
}
