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
    public class VolunteerConfiguration : IEntityTypeConfiguration<VolunteerEntity>
    {
        public void Configure(EntityTypeBuilder<VolunteerEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .HasMany(x => x.Organizations)
                .WithMany(x => x.Volunteers);
            builder
                .HasMany(x => x.Requests)
                .WithOne(x => x.Volunteer)
                .HasForeignKey(x => x.VolunteerId);
        }
    }
}
