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
    public class RequestConfiguration : IEntityTypeConfiguration<RequestEntity>
    {
        public void Configure(EntityTypeBuilder<RequestEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .HasOne(x => x.MilitaryUnit)
                .WithMany(x => x.Requests)
                .HasForeignKey(x => x.MilitaryUnitId);
        }
    }
}
