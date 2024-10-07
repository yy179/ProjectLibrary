using Microsoft.EntityFrameworkCore;
using ProjectLibrary.Models;
using ProjectLibrary.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
        : base(options)
        {
        }
        public DbSet<ContactPersonEntity> ContactPersons { get; set; }
        public DbSet<MilitaryUnitEntity> MilitaryUnits { get; set; }
        public DbSet<OrganizationEntity> Organizations { get; set; }
        public DbSet<RequestEntity> Requests { get; set; }
        public DbSet<VolunteerEntity> Volunteers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContactPersonConfiguration());
            modelBuilder.ApplyConfiguration(new MilitaryUnitConfiguration());
            modelBuilder.ApplyConfiguration(new OrganizationConfiguration());
            modelBuilder.ApplyConfiguration(new RequestConfiguration());
            modelBuilder.ApplyConfiguration(new VolunteerConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\user\\Documents\\ProjectDB.mdf;Integrated Security=True;Connect Timeout=30");
            }
        }
    }
}
