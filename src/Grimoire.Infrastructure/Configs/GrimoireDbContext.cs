using System.Reflection;
using Grimoire.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;

namespace Grimoire.Infrastructure.Configs;

public class GrimoireDbContext(DbContextOptions<GrimoireDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}