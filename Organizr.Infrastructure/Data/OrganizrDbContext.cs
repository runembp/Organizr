using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Organizr.Core.Entities;
using System.Reflection;

namespace Organizr.Infrastructure.Data
{
    public class OrganizrDbContext : IdentityDbContext<OrganizrUser, OrganizrRole, int>
    {
        public DbSet<UserGroup> UserGroups { get; set; }

        public OrganizrDbContext(DbContextOptions<OrganizrDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}