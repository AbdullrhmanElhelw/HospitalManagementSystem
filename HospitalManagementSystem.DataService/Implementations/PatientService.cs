using AutoMapper;
using HospitalManagementSystem.DataService.Abstracts;
using HospitalManagementSystem.DataService.DTOs.Patient;
using HospitalManagementSystem.Entites.Entites;
using HospitalManagementSystem.Infrastructure.DapperQueries.PatientQuery;
using HospitalManagementSystem.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore.Internal;

namespace HospitalManagementSystem.DataService.Implementations;

public class PatientService : IPatientService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPatientQuery _patientQuery;

    public PatientService(IUnitOfWork unitOfWork, IMapper mapper,IPatientQuery patientQuery)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _patientQuery = patientQuery;
    }

    public void AddMultiPatients(List<PatientCreateDTO> patientCreateDTOs)
    {
        var patients = _mapper.Map<List<Entites.Entites.Patient>>(patientCreateDTOs);
        _unitOfWork.PatientRepository.AddRange(patients);
        _unitOfWork.Commit();   
    }

    public void AddProfilePicture(PatientProfilePictureCreateDTO patientProfilePictureCreateDTO)
    {
        var patient = _patientQuery.GetById(patientProfilePictureCreateDTO.PatientId);
        if(patient is null)
        {
            throw new Exception("Patient Not Found");
        }
        patient.ProfilePicutre = _mapper.Map<Image>(patientProfilePictureCreateDTO);
        _unitOfWork.PatientRepository.Update(patient);
        _unitOfWork.Commit();
    }

    public PatientCreateDTO Create(PatientCreateDTO patientCreateDTO)
    {
        var patient = _mapper.Map<Entites.Entites.Patient>(patientCreateDTO);
        _unitOfWork.PatientRepository.Add(patient);
        _unitOfWork.Commit();
        return _mapper.Map<PatientCreateDTO>(patient);
    }

    public void Delete(int id)
    {
        var patient = _patientQuery.GetById(id);

        // iwant to avoid the exception and return a message to the user
        if(patient is null)
        {
            throw new Exception("Patient Not Found");
        }
        _unitOfWork.PatientRepository.Delete(patient);
        _unitOfWork.Commit();
    }

    public IQueryable<PatientReadDTO> GetAll()
    {
       var patients = _patientQuery.GetAll();
        return _mapper.ProjectTo<PatientReadDTO>(patients);
    }

    public IQueryable<PatientReadDTO> GetByCreatedDay(DateTime createdDay)
    {
        var patients = _patientQuery.FindByCreatedDate(createdDay);
        return _mapper.ProjectTo<PatientReadDTO>(patients);
    }

    public PatientReadDTO? GetById(int id)
    {
        var patient = _patientQuery.GetById(id);
        if(patient is null)
        {
            throw new Exception("Patient Not Found");
        }
        return _mapper.Map<PatientReadDTO?>(patient);
    }

    public PatientReadDTO? GetByName(string name)
    {
        var patient = _patientQuery.FindByName(name);
        if(patient is null)
        {
            throw new Exception("Patient Not Found");
        }
        return _mapper.Map<PatientReadDTO?>(patient);
    }

    public PatientUpdateDTO Update(int id, PatientUpdateDTO patientUpdateDTO)
    {
        var patient = _patientQuery.GetById(id);
        if(patient is null)
        {
            throw new Exception("Patient Not Found");
        }
        _mapper.Map(patientUpdateDTO, patient);
        _unitOfWork.PatientRepository.Update(patient);
        _unitOfWork.Commit();
        return _mapper.Map<PatientUpdateDTO>(patient);
    }
}
