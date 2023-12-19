using HospitalManagementSystem.Entites.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Infrastructure.Context.EF_Context;

public class EFDbContext : IdentityDbContext<ApplicationUser>
{
    public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
    {
    }

    public DbSet<Patient> Patients { get; set; }
    public DbSet<Medicine> Medicines { get; set; }
    public DbSet<Relative> Relatives { get; set; }
    public DbSet<PatientMedicine> PatientMedicines { get; set; }
    public DbSet<HospitalAdmin> HospitalAdmins { get; set; }
    public DbSet<MRI> MRIs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // TPT Inheritance
        modelBuilder.Entity<ApplicationUser>().ToTable("Users");
        modelBuilder.Entity<HospitalAdmin>().ToTable("Admins");
        modelBuilder.Entity<Relative>().ToTable("Relatives");


        modelBuilder.Entity<ApplicationUser>(entity =>
        {
            entity.Property(e=>e.FirstName).HasMaxLength(50).IsRequired();
            entity.Property(e=>e.LastName).HasMaxLength(50).IsRequired();
            entity.Property(e=>e.SSN).HasMaxLength(14).IsRequired();
            entity.Property(e=>e.Address).HasMaxLength(100).IsRequired();
            entity.Property(e=>e.BirthDate).HasColumnType("date").IsRequired();
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.Property(e=>e.BirthDate).HasColumnType("date").IsRequired();
            entity.Property(e=>e.Name).HasMaxLength(50).IsRequired();
            entity.Property(e=>e.Address).HasMaxLength(100).IsRequired();
        });

        modelBuilder.Entity<Medicine>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50).IsRequired();
            entity.Property(e => e.Description).HasMaxLength(100).IsRequired();
        });

      

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFDbContext).Assembly);
    }
}

