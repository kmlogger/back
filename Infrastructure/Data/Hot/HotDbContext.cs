using System;
using System.Reflection;
using Domain.Entities;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Hot;

public class HotDbContext : DbContext
{
    public HotDbContext(DbContextOptions<HotDbContext> options) : base(options) { }
    public DbSet<LogApp> Logs {get; init;}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Ignore<Notification>();
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
