using HospitalManagementSystem.Core.CommonUtilites;
using HospitalManagementSystem.Core.CQRS.Admin.Commands.Models;
using HospitalManagementSystem.DataService.Abstracts;
using MediatR;

namespace HospitalManagementSystem.Core.CQRS.Admin.Commands.Handlers;

public sealed class UploadMRICommandHandler(IAdminService adminService) : IRequestHandler<UploadMRICommand, Result>
{
    private readonly IAdminService _adminService = adminService;

    public Task<Result> Handle(UploadMRICommand request, CancellationToken cancellationToken)
    {
        var mri = request.MRIUploadDto;
        if(mri is null || mri.Picture.Length <= 0)
            return Task.FromResult(Result.Failure(new Error("MRI Is Not Valid")));

        _adminService.UploadMRI(mri);
        return Task.FromResult(Result.Success());
    }
}
