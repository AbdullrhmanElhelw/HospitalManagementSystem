using HospitalManagementSystem.Entites.Entites;
using HospitalManagementSystem.Infrastructure.BaseRepository;

namespace HospitalManagementSystem.Infrastructure.Abstracts.PatinetsRepository;

public interface IPatientRepository: IRepository<Patient>
{
    void UploadProfilePicture(Image profilePicture, int patientId);
}
