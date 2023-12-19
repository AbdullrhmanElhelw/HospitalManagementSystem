using HospitalManagementSystem.Entites.Entites;
using HospitalManagementSystem.Infrastructure.Context.EF_Context;

namespace HospitalManagementSystem.Infrastructure.Abstracts.AdminRepository;

public class AdminRepository(EFDbContext dbContext) : IAdminRepository
{
    private readonly EFDbContext _dbContext = dbContext;

    public void UploadMRIImage(MRI mriImage)
    {
        _dbContext.MRIs.Add(mriImage);
    }
}
