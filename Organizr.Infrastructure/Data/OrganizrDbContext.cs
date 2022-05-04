using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Organizr.Core.Entities;
using System.Reflection;

namespace Organizr.Infrastructure.Data
{
    public class OrganizrDbContext : IdentityDbContext<Member, OrganizrRole, int>
    {
        public DbSet<MemberGroup> MemberGroups { get; set; }

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