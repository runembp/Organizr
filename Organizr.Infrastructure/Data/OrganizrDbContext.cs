using Microsoft.EntityFrameworkCore;
using Organizr.Core.Entities;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Organizr.Infrastructure.Data
{
    public class OrganizrDbContext : IdentityDbContext<OrganizrUser>
    {
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