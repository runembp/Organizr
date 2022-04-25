using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Organizr.Infrastructure.Models;

namespace Organizr.Database;

public class OrganizrDataContext : IdentityDbContext<OrganizrUser>
{
    public DbSet<Group> Groups => Set<Group>();
    public DbSet<Person> Persons => Set<Person>();
    
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