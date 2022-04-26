using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Organizr.Infrastructure.Models;

namespace Organizr.Database;

public class OrganizrDataContext : IdentityDbContext<OrganizrUser, IdentityRole, string>
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