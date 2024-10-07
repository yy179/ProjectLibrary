using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ProjectLibrary;

namespace ProjectLibrary
{
    public class ProjectDbContextFactory : IDesignTimeDbContextFactory<ProjectDbContext>
    {
        public ProjectDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProjectDbContext>();
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\user\\Documents\\ProjectDB.mdf;Integrated Security=True;Connect Timeout=30");

            return new ProjectDbContext(optionsBuilder.Options);
        }
    }
}
