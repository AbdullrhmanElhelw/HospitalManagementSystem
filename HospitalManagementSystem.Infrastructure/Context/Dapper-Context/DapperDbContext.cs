using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace HospitalManagementSystem.Infrastructure.Context.Dapper_Context;
public class DapperDbContext
{
    private readonly string _connectionString;
    private readonly IConfiguration _configuration;

    public DapperDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("HospitalDb") ??
            throw new ApplicationException("Connection String NotFound");
    }

    public IDbConnection CreateConnection()=>  new SqlConnection(_connectionString);
}
