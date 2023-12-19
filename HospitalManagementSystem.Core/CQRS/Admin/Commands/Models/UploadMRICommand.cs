using HospitalManagementSystem.Core.CommonUtilites;
using HospitalManagementSystem.DataService.DTOs.User;
using MediatR;

namespace HospitalManagementSystem.Core.CQRS.Admin.Commands.Models;

public sealed record UploadMRICommand(MRIUploadDTO MRIUploadDto) : IRequest<Result>;
