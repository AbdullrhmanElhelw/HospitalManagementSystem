using AutoMapper;
using HospitalManagementSystem.Core.CommonUtilites;
using HospitalManagementSystem.Core.CQRS.Patient.Queries.Models;
using HospitalManagementSystem.DataService.Abstracts;
using HospitalManagementSystem.DataService.DTOs.Patient;
using HospitalManagementSystem.Infrastructure.DapperQueries.PatientQuery;
using MediatR;

namespace HospitalManagementSystem.Core.CQRS.Patient.Queries.Handler;

public class GetPatientByNameQueryHandler : IRequestHandler<GetPatientByNameQuery, GenericResult<PatientReadDTO>>
{
    private readonly IPatientQuery _patientQuery;
    private readonly IMapper _mapper;

    public GetPatientByNameQueryHandler(IPatientQuery patientQuery, IMapper mapper)
    {
        _patientQuery = patientQuery;
        _mapper = mapper;

    }

    public Task<GenericResult<PatientReadDTO>> Handle(GetPatientByNameQuery request, CancellationToken cancellationToken)
    {
        var patient = _patientQuery.FindByName(request.name);
        if (patient is null)
        {
            return Task.FromResult(GenericResult<PatientReadDTO>.Failure(PatientErrors.NotFound(request.name)));
        }

        var result = GenericResult<PatientReadDTO>.Success(_mapper.Map<PatientReadDTO>(patient));
        return Task.FromResult(result);
    }

}
