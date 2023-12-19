using AutoMapper;
using HospitalManagementSystem.DataService.Abstracts;
using HospitalManagementSystem.DataService.DTOs.User;
using HospitalManagementSystem.Entites.Entites;
using HospitalManagementSystem.Infrastructure.UnitOfWork;

namespace HospitalManagementSystem.DataService.Implementations;

public class AdminService(IUnitOfWork unitOfWork, IMapper mapper) : IAdminService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public void UploadMRI(MRIUploadDTO mRIUploadDTO)
    {
        var mRI = _mapper.Map<MRI>(mRIUploadDTO);
        _unitOfWork.AdminRepository.UploadMRIImage(mRI);
        _unitOfWork.Commit();
    }
}
