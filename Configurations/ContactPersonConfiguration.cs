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
    public class ContactPersonConfiguration : IEntityTypeConfiguration<ContactPersonEntity>
    {
        public void Configure(EntityTypeBuilder<ContactPersonEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .HasOne(x => x.MilitaryUnit)
                .WithOne(x => x.ContactPerson)
                .HasForeignKey<MilitaryUnitEntity>(x => x.ContactPersonId);
        }
    }
}
