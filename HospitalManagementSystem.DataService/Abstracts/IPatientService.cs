using HospitalManagementSystem.DataService.DTOs.Patient;

namespace HospitalManagementSystem.DataService.Abstracts;

public interface IPatientService
{
    PatientCreateDTO Create(PatientCreateDTO patientCreateDTO);
    PatientUpdateDTO Update(int id, PatientUpdateDTO patientUpdateDTO);
    void Delete(int id);
    PatientReadDTO? GetById(int id);
    IQueryable<PatientReadDTO> GetAll();

    PatientReadDTO? GetByName(string name);
    IQueryable<PatientReadDTO> GetByCreatedDay(DateTime createdDay);

    void AddProfilePicture(PatientProfilePictureCreateDTO patientProfilePictureCreateDTO);

    void AddMultiPatients(List<PatientCreateDTO> patientCreateDTOs);


}
