using System.Reflection;
using MasterChef.Application;
using MasterChef.Infra;
using MasterChef.Infra.Enums;
using MasterChef.Infra.Postgres;
using MasterChef.Infra.Sqlite;
using MasterChef.Infra.SqlServer;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using MasterChef.Infra.Helpers.ExtensionMethods;
using MasterChef.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApiServiceIoCDependency();
builder.Services.AddServices();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(
        x =>
        {
            x.DefaultAuthenticateScheme = "Jwt";
            x.DefaultChallengeScheme = "Jwt";
        })
    .AddJwtBearer("Jwt",
        o =>
        {
            o.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateAudience = false,
                ValidAudience = "clients-api",
                ValidIssuer = "api",
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Security.GetKey()),
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromMinutes(5)
            };
        }
    );

var databaseConfiguration = new DatabaseConfiguration(builder.Configuration, builder.Environment.IsProduction());

switch (databaseConfiguration.DatabaseType)
{
    case DatabaseType.Sqlite:
        builder.Services.AddSqLiteDependency(databaseConfiguration);
        break;
    case DatabaseType.Postgres:
        builder.Services.AddPostgresDependency(databaseConfiguration);
        break;
    case DatabaseType.SqlServer:
        builder.Services.AddSqLServerDependency(databaseConfiguration);
        break;
    default:
        throw new NotSupportedException("No database configuration found");
}

builder.Configuration.AddSerilogApi();
builder.Host.UseSerilog(Log.Logger);

Console.Title = Assembly.GetEntryAssembly().GetName().Name;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
