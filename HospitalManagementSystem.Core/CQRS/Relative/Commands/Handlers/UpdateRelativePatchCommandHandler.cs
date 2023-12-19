using HospitalManagementSystem.Core.CommonUtilites;
using HospitalManagementSystem.Core.CQRS.Relative.Commands.Models;
using HospitalManagementSystem.DataService.Abstracts;
using MediatR;


namespace HospitalManagementSystem.Core.CQRS.Relative.Commands.Handlers;

public sealed class UpdateRelativePatchCommandHandler
    : IRequestHandler<UpdateRelativePatchCommand, Result>
{

    private readonly IRelativeService _relativeService;

    public UpdateRelativePatchCommandHandler(IRelativeService relativeService)
    {
        _relativeService = relativeService;
    }

    public Task<Result> Handle(UpdateRelativePatchCommand request, CancellationToken cancellationToken)
    {
        var relative = _relativeService.GetRelative(request.Id);   
        if(relative is not null)
        {
            _relativeService.UpdateRelative(request.Id, request.RelativePatchDocument);
            return Task.FromResult(Result.Success());
        }
        return Task.FromResult(Result.Failure(new Error("Relative not found")));
    }
}
