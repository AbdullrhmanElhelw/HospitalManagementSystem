using Dapper;
using HospitalManagementSystem.Entites.Entites;
using HospitalManagementSystem.Infrastructure.Context.Dapper_Context;
using System.Linq.Expressions;

namespace HospitalManagementSystem.Infrastructure.DapperQueries.PatientQuery;

public class PatientQuery : IPatientQuery
{
    private readonly DapperDbContext _context;
    public PatientQuery(DapperDbContext context)
    {
        _context = context;
    }

    public IQueryable<Patient> FindByCreatedDate(DateTime createdDate)
    {
        var sql = """
                     SELECT * FROM Patients WHERE CreatedDate = @CreatedDate
                  """;
        using var connection = _context.CreateConnection();
        return connection.Query<Patient>(sql, new { CreatedDate = createdDate }).AsQueryable();
    }

    public Patient? FindByName(string name)
    {
        var sql = "SELECT * FROM Patients WHERE Name = @Name COLLATE Latin1_General_CI_AI";
        using var connection = _context.CreateConnection();
        return connection.QuerySingleOrDefault<Patient>(sql, new { Name = name });
    }


    public IQueryable<Patient> GetAll()
    {
        var sql  = "SELECT * FROM Patients";
        using var connection = _context.CreateConnection();
        return connection.Query<Patient>(sql).AsQueryable();
    }

   

    public Patient? GetById(int id)
    {
        var sql = "SELECT * FROM Patients WHERE Id = @Id";
        using var connection = _context.CreateConnection();
        return connection.QuerySingleOrDefault<Patient>(sql, new { Id = id });
    }
}
