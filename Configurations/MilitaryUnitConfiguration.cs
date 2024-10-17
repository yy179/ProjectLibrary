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
    public class MilitaryUnitConfiguration : IEntityTypeConfiguration<MilitaryUnitEntity>
    {
        public void Configure(EntityTypeBuilder<MilitaryUnitEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .HasOne(x => x.ContactPerson)
                .WithOne(x => x.MilitaryUnit)
                .HasForeignKey<ContactPersonEntity>(x => x.MilitaryUnitId)
                .IsRequired(false);
        }
    }
}
