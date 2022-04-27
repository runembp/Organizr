using Microsoft.EntityFrameworkCore;
using Organizr.Core.Entities;
using System.Reflection;

namespace Organizr.Infrastructure.Data
{
    public class OrganizrDbContext : DbContext
    {
        public DbSet<OrganizrUser> Users => Set<OrganizrUser>();

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
