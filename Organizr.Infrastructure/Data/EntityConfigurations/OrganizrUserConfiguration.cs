using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Organizr.Core.Entities;

namespace Organizr.Infrastructure.Data.EntityConfigurations
{
    public class OrganizrUserConfiguration : IEntityTypeConfiguration<OrganizrUser>
    {
        public void Configure(EntityTypeBuilder<OrganizrUser> builder)
        {

        }
    }
}
