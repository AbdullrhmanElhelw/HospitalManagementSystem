using HospitalManagementSystem.Infrastructure.Abstracts.AdminRepository;
using HospitalManagementSystem.Infrastructure.Abstracts.PatinetsRepository;
using HospitalManagementSystem.Infrastructure.Abstracts.RelativeRepository;
using HospitalManagementSystem.Infrastructure.Context.EF_Context;

namespace HospitalManagementSystem.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly EFDbContext _context;
    public PatientRepository PatientRepository { get; private set; }
    public RelativeRepository RelativeRepository { get; private set; }
    public AdminRepository AdminRepository { get; private set; }

    public UnitOfWork(EFDbContext context)
    {
        _context = context;
        PatientRepository = new PatientRepository(_context);
        RelativeRepository = new RelativeRepository(_context);
        AdminRepository = new AdminRepository(_context);
    }

    public int Commit() => _context.SaveChanges();

    public void Dispose() => _context.Dispose();
}
