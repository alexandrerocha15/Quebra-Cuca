using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace QuebraCuca.Infra.Compartilhado.Orm;

public sealed class QuebraCucaDbContext(
    DbContextOptions<QuebraCucaDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Assembly assembly = typeof(QuebraCucaDbContext).Assembly;

        modelBuilder.ApplyConfigurationsFromAssembly(assembly);
    }
}
