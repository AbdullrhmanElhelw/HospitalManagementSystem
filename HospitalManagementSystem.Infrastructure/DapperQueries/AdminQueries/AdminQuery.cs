using Dapper;
using HospitalManagementSystem.Entites.Entites;
using HospitalManagementSystem.Infrastructure.Context.Dapper_Context;

namespace HospitalManagementSystem.Infrastructure.DapperQueries.AdminQueries;

public class AdminQuery(DapperDbContext context)
    : IAdminQuery
{
    private readonly DapperDbContext _context = context;

    public HospitalAdmin? FindById(string id)
    {
        var sql = "SELECT * FROM USERS WHERE @ID = ID";
        using var connection = _context.CreateConnection();
        var admin = connection.QuerySingleOrDefault<HospitalAdmin>(sql, new {id});
        return admin;
    }

    public IQueryable<HospitalAdmin> GetAll()
    {
        var sql = "SELECT * FROM USERS INNER JOIN ADMINS WHERE USERS.ID = ADMINS.ID";
        using var connection = _context.CreateConnection();
        var admins = connection.Query<HospitalAdmin>(sql);
        return admins.AsQueryable();
    }

    public HospitalAdmin? GetById(int id)
    {
        var sql = "SELECT * FROM USERS WHERE @ID = ID";
        using var connection = _context.CreateConnection();
        var admin = connection.QuerySingleOrDefault<HospitalAdmin>(sql, new { id });
        return admin;
    }
}
