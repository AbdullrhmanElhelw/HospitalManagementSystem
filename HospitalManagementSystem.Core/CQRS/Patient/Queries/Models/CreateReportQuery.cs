using HospitalManagementSystem.Core.CommonUtilites;
using HospitalManagementSystem.Core.Helper;
using HospitalManagementSystem.DataService.DTOs.Report;
using MediatR;

namespace HospitalManagementSystem.Core.CQRS.Patient.Queries.Models;

public sealed record CreateReportQuery
    (int Id, ReportBody Report) : IRequest<GenericResult<byte[]>>;    
