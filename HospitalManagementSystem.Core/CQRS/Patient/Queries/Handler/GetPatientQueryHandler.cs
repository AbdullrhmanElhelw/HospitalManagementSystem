using AutoMapper;
using HospitalManagementSystem.Core.CommonUtilites;
using HospitalManagementSystem.Core.CQRS.Patient.Queries.Models;
using HospitalManagementSystem.DataService.DTOs.Patient;
using HospitalManagementSystem.Infrastructure.DapperQueries.PatientQuery;
using MediatR;

namespace HospitalManagementSystem.Core.CQRS.Patient.Queries.Handler;

public class GetPatientQueryHandler : IRequestHandler<GetPatientQuery, GenericResult<PatientReadDTO>>
{
    private readonly IMapper _mapper;
    private readonly IPatientQuery _patientQuery;

    public GetPatientQueryHandler(IMapper mapper,IPatientQuery patientQuery)
    {
        _patientQuery = patientQuery;
        _mapper = mapper;
    }

    public Task<GenericResult<PatientReadDTO>> Handle(GetPatientQuery request, CancellationToken cancellationToken)
    {
        var patient = _patientQuery.GetById(request.id);
        if (patient is null)
        {
            return Task.FromResult(GenericResult<PatientReadDTO>.Failure(PatientErrors.NotFound(request.id)));
        }
        return Task.FromResult(GenericResult<PatientReadDTO>.Success(_mapper.Map<PatientReadDTO>(patient)));
    }
}

