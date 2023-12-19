using HospitalManagementSystem.Core.CommonUtilites;
using HospitalManagementSystem.DataService.DTOs.Relative;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;

namespace HospitalManagementSystem.Core.CQRS.Relative.Commands.Models;

public sealed record  UpdateRelativePatchCommand
    (string Id, JsonPatchDocument RelativePatchDocument) : IRequest<Result>;

