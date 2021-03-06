using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Organizr.Domain.Entities;
using System.Reflection;

namespace Organizr.Infrastructure.Persistence
{
    public class OrganizrDbContext : IdentityDbContext<Member, OrganizrRole, int>
    {
        public DbSet<MemberGroup> MemberGroups { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<NewsPost> NewsPosts { get; set; }

        public OrganizrDbContext(DbContextOptions<OrganizrDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<MemberGroup>(entity =>
            {
                entity.HasIndex(group => group.Name).IsUnique();
            });

            modelBuilder.Entity<NewsPost>(entity =>
            {
                entity.Property(member => member.Id).IsRequired();
                entity.Property(memberGroup => memberGroup.Id).IsRequired();
            });

        }
    }
}