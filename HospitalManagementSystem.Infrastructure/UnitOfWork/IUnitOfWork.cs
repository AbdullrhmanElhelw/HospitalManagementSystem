using HospitalManagementSystem.Infrastructure.Abstracts.AdminRepository;
using HospitalManagementSystem.Infrastructure.Abstracts.PatinetsRepository;
using HospitalManagementSystem.Infrastructure.Abstracts.RelativeRepository;

namespace HospitalManagementSystem.Infrastructure.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    PatientRepository PatientRepository { get; }
    RelativeRepository RelativeRepository { get; }
    AdminRepository AdminRepository { get; }

    int Commit();
}
