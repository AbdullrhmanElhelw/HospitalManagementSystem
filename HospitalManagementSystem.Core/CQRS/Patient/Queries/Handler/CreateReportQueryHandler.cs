using HospitalManagementSystem.Core.CommonUtilites;
using HospitalManagementSystem.Core.CQRS.Patient.Queries.Models;
using HospitalManagementSystem.Core.Helper;
using HospitalManagementSystem.DataService.DTOs.Report;
using HospitalManagementSystem.Entites.Entites;
using HospitalManagementSystem.Infrastructure.DapperQueries.PatientQuery;
using MediatR;

namespace HospitalManagementSystem.Core.CQRS.Patient.Queries.Handler;

public sealed class CreateReportQueryHandler : IRequestHandler<CreateReportQuery, GenericResult<byte[]>>
{
    private readonly IPatientQuery _patientQuery;

    public CreateReportQueryHandler(IPatientQuery patientQuery)
    {
        _patientQuery = patientQuery;
    }


    private static ReportCreateDTO MappiingToDTO(Entites.Entites.Patient patient,ReportBody report)
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

    public Task<GenericResult<byte[]>> Handle(CreateReportQuery request, CancellationToken cancellationToken)
    {
        var patient = _patientQuery.GetById(request.Id);
        if (patient == null)
        {
            return Task.FromResult(GenericResult<byte[]>.Failure(PatientErrors.NotFound(request.Id)));
        }

        var reportCreateDTO = MappiingToDTO(patient,request.Report);
        var report = GenerateReport.GenereatePatientReport(reportCreateDTO);
        return Task.FromResult(GenericResult<byte[]>.Success(report));
    }
}
