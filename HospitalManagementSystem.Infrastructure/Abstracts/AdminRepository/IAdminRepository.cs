using HospitalManagementSystem.Entites.Entites;

namespace HospitalManagementSystem.Infrastructure.Abstracts.AdminRepository;

public interface IAdminRepository
{
    void UploadMRIImage(MRI mriImage);
}
