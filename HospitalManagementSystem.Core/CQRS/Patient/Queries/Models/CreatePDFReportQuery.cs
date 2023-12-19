using HospitalManagementSystem.Core.CommonUtilites;
using HospitalManagementSystem.Core.Helper;
using MediatR;

namespace HospitalManagementSystem.Core.CQRS.Patient.Queries.Models;

public sealed record CreatePDFReportQuery(int Id, ReportBody Report)
    : IRequest<GenericResult<byte[]>>;
