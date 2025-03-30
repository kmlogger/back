using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Npgsql;

namespace Infrastructure.Data.Cold;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ColdDbContext>
{
    public ColdDbContext CreateDbContext(string[] args)
    {
       try
        {
            var connectionString = args.FirstOrDefault() ?? StringConnection.BuildConnectionString();
            if (string.IsNullOrEmpty(connectionString))
                throw new Exception("A connection string must be provided.");

            var builder = new DbContextOptionsBuilder<ColdDbContext>();
            builder.UseNpgsql(connectionString);
            var context = new ColdDbContext(builder.Options);
            return context;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            throw;
        }
    }
}

public static class StringConnection
{
    public static string BuildConnectionString()
    {
        var builder = new NpgsqlConnectionStringBuilder
        {
            Host = Environment.GetEnvironmentVariable("HOST_DATABASE") ?? string.Empty , 
                Port = int.TryParse(Environment.GetEnvironmentVariable("PORT_DATABASE"), 
                out var portdatabase) ? portdatabase : 5432, Database =
                Environment.GetEnvironmentVariable("DATABASE") ?? string.Empty,
            Username = Environment.GetEnvironmentVariable("USERNAME_DATABASE") ?? string.Empty,
            Password = Environment.GetEnvironmentVariable("PASSWORD_DATABASE") ?? string.Empty
        };
        return builder.ConnectionString;
    }
}
