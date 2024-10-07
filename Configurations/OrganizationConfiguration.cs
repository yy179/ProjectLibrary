using ProjectLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Configurations
{
    public class OrganizationConfiguration : IEntityTypeConfiguration<OrganizationEntity>
    {
        public void Configure(EntityTypeBuilder<OrganizationEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .HasMany(x => x.Requests)
                .WithOne(x => x.Organization)
                .HasForeignKey(x => x.OrganizationId);

        }
    }
}
