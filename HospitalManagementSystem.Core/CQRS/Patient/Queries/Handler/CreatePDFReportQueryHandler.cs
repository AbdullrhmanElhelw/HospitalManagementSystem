using HospitalManagementSystem.Core.CommonUtilites;
using HospitalManagementSystem.Core.CQRS.Patient.Queries.Models;
using HospitalManagementSystem.Core.Helper;
using HospitalManagementSystem.DataService.DTOs.Report;
using HospitalManagementSystem.Infrastructure.DapperQueries.PatientQuery;
using MediatR;
using StackExchange.Redis;

namespace HospitalManagementSystem.Core.CQRS.Patient.Queries.Handler;

public sealed class CreatePDFReportQueryHandler(IPatientQuery patientQuery) :
    IRequestHandler<CreatePDFReportQuery, GenericResult<byte[]>>
{
    private readonly IPatientQuery _patientQuery = patientQuery;

    public Task<GenericResult<byte[]>> Handle(CreatePDFReportQuery request, CancellationToken cancellationToken)
    {
        var patient = _patientQuery.GetById(request.Id);

        if(patient is null)
            return Task.FromResult(GenericResult<byte[]>.Failure(PatientErrors.NotFound(request.Id)));

        var reportCreateDTO= MappiingToDTO(patient, request.Report);
        var report = PDFReport.GeneratePdfReport(reportCreateDTO);

        return Task.FromResult(GenericResult<byte[]>.Success(report));

    }

    private static ReportCreateDTO MappiingToDTO(Entites.Entites.Patient patient, ReportBody report)
    {
        return new ReportCreateDTO
        {
            PatientId = patient.Id,
            PatientName = patient.Name,
            DateOfBirth = patient.BirthDate,
            Address = patient.Address,
            CreatedDate = DateTime.Now,
            ReportName = report.ReportName,
            ReportDescription = report.ReportDescription,
            ReportType = report.ReportType
        };
    }

}
