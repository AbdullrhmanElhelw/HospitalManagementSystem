using HospitalManagementSystem.Core;
using HospitalManagementSystem.DataService;
using HospitalManagementSystem.Entites.Entites;
using HospitalManagementSystem.Entites.Roles;
using HospitalManagementSystem.Infrastructure;
using HospitalManagementSystem.Infrastructure.Context.Dapper_Context;
using HospitalManagementSystem.Infrastructure.Context.EF_Context;
using HospitalManagementSystem.Presentation.Utilites;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
#region swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});
#endregion

#region EFDbContext

builder.Services.AddDbContext<EFDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("HospitalDb"));
});

#endregion 

#region DapperDbContext

builder.Services.AddSingleton<DapperDbContext>();

#endregion

#region Identity

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 6;


    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
})
    .AddEntityFrameworkStores<EFDbContext>()
    .AddDefaultTokenProviders();
#endregion

#region Services 

builder.Services
    .AddInfrastructureDependancies()
    .AddAutoMapperDependancy()
    .AddMeidatrDependencies()
    .AddDataServiceDependancy();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<UserUtility>();

#endregion

#region BearerDefaultAuthentecation

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "Default";
    options.DefaultChallengeScheme = "Default";
}
)
    .AddJwtBearer("Default", options =>
    {
        var Getkey = builder.Configuration.GetValue<string>("JWT:Key");
        var secretKeyInBytes = Encoding.ASCII.GetBytes(Getkey);
        var key = new SymmetricSecurityKey(secretKeyInBytes);
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            IssuerSigningKey = key
        };
    });

#endregion

#region Authorization

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(nameof(RolesEnum.Admin), policy => policy.RequireRole(nameof(RolesEnum.Admin)));
    options.AddPolicy(nameof(RolesEnum.Relative), policy => policy.RequireRole(nameof(RolesEnum.Relative)));
    options.AddPolicy(nameof(RolesEnum.User), policy => policy.RequireRole(nameof(RolesEnum.User)));
});

#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region Middlewares

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion