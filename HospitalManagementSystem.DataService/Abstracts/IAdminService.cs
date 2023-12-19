using HospitalManagementSystem.DataService.DTOs.User;

namespace HospitalManagementSystem.DataService.Abstracts;

public interface IAdminService
{
    void UploadMRI(MRIUploadDTO mRIUploadDTO);
}
