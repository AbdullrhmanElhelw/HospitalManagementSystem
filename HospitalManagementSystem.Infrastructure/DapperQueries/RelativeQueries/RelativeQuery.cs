using Dapper;
using HospitalManagementSystem.Entites.Entites;
using HospitalManagementSystem.Infrastructure.Context.Dapper_Context;

namespace HospitalManagementSystem.Infrastructure.DapperQueries.RelativeQueries;

public class RelativeQuery : IRelativeQuery
{
    private readonly DapperDbContext _context;
    public RelativeQuery(DapperDbContext context)
    {
        _context = context;
    }

    public Relative? FindById(string id)
    {
        var sql = "SELECT * FROM Users WHERE Id = @Id";
        using var connection = _context.CreateConnection();
        return connection.QuerySingleOrDefault<Relative>(sql, new { Id = id });
    }

    public IQueryable<Relative> FindRelativesByName(string name)
    {
        var sql =
            """
             SELECT *
             FROM Users
             INNER JOIN Relatives ON Relatives.id = Users.Id
             WHERE CONCAT(Users.firstname, ' ', Users.lastname) COLLATE Latin1_General_CI_AI LIKE @name COLLATE Latin1_General_CI_AI;
             ORDER BY Relatives.PatientId
         """;
        using var connection = _context.CreateConnection();
        return connection.Query<Relative>(sql, new { name = $"%{name}%" }).AsQueryable();
    }

    public IQueryable<Relative> GetAll()
    {
        var sql = 
            """
                SELECT *
                FROM Users
                INNER JOIN Relatives ON Relatives.id = Users.Id
             """;
        using var connection = _context.CreateConnection();
        return connection.Query<Relative>(sql).AsQueryable();
    }

    public Relative? GetById(int id)
    {
        var sql = "SELECT * FROM Relatives WHERE Id = @Id";
        using var connection = _context.CreateConnection();
        return connection.QuerySingleOrDefault<Relative>(sql, new { Id = id });
    }
}
