using ProjectLibrary.Models;
using Microsoft.EntityFrameworkCore;
using ProjectLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Repositories
{
    public class VolunteersRepository
    {
        private readonly ProjectDbContext _dbContext;
        public VolunteersRepository(ProjectDbContext dbContext) { _dbContext = dbContext; }
        public async Task<List<VolunteerEntity>> Get()
        {
            return await _dbContext.Volunteers.AsNoTracking().ToListAsync();
        }
        public async Task<VolunteerEntity?> GetById(Guid id)
        {
            return await _dbContext.Volunteers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task Add(Guid id, string name, DateTime dateOfBirth, string city, string biography, List<OrganizationEntity> organizations, List<RequestEntity> requests)
        {
            var volunteerEntity = new VolunteerEntity
            {
                Id = id,
                Name = name,
                City = city,
                DateOfBirth = dateOfBirth,
                Organizations = organizations ?? new List<OrganizationEntity>(),
                Requests = requests ?? new List<RequestEntity>()
            };
            await _dbContext.AddAsync(volunteerEntity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task Update(Guid id, string name, DateTime dateOfBirth, string city, string biography, List<OrganizationEntity> organizations, List<RequestEntity> requests)
        {
            var volunteer = await _dbContext.Volunteers
                .Include(r => r.Organizations)
                .Include(r => r.Requests)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (volunteer != null)
            {
                volunteer.Name = name;
                volunteer.DateOfBirth = dateOfBirth;
                volunteer.City = city;
                volunteer.Biography = biography;
                volunteer.Organizations = organizations;
                volunteer.Requests = requests;

                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task Delete(Guid id)
        {
            await _dbContext.Volunteers.Where(x => x.Id == id).ExecuteDeleteAsync();
        }
        private bool IsAdmin(VolunteerEntity user)
        {
            return user.IsAdmin;
        }
    }
}
