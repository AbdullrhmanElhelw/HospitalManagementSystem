using HospitalManagementSystem.Entites.Entites;
using HospitalManagementSystem.Infrastructure.BaseRepository;
using HospitalManagementSystem.Infrastructure.Context.EF_Context;

namespace HospitalManagementSystem.Infrastructure.Abstracts.PatinetsRepository;

public class PatientRepository : Repository<Patient>, IPatientRepository
{
    private readonly EFDbContext _context;
    public PatientRepository(EFDbContext context) : base(context)
    {
        _context = context;
    }

    public void UploadProfilePicture(Image profilePicture, int patientId)
    {
        var patient = _context.Patients.Find(patientId);
        if(patient is not null)
        {
            patient.ProfilePicutre = profilePicture;
        }
    }
}
