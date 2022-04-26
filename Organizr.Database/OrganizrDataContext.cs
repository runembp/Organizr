using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Organizr.Database;

public class OrganizrDataContext : IdentityDbContext
{
    public OrganizrDataContext(DbContextOptions<OrganizrDataContext> options)
        : base(options)
    {           
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}