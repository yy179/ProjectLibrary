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
    public class OrganizationsRepository
    {
        private readonly ProjectDbContext _dbContext;
        public OrganizationsRepository(ProjectDbContext dbContext) {  _dbContext = dbContext; }
        public async Task<List<OrganizationEntity>> Get()
        {
            return await _dbContext.Organizations.AsNoTracking().ToListAsync();
        }
        public async Task<OrganizationEntity?> GetById(Guid id)
        {
            return await _dbContext.Organizations.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<VolunteerEntity>> GetVolunteersByOrganization(Guid organizationId)
        {
            var organization = await _dbContext.Organizations.Include(o => o.Volunteers).AsNoTracking().FirstOrDefaultAsync(o => o.Id == organizationId);
            return organization?.Volunteers ?? new List<VolunteerEntity>();
        }
        public async Task<List<RequestEntity>> GetActiveRequestsByOrganization(Guid organizationId)
        {
            return await _dbContext.Requests
                .Where(r => r.OrganizationId == organizationId && r.IsActive)
                .AsNoTracking().ToListAsync();
        }
        public async Task<List<RequestEntity>> GetCompletedRequestsByOrganization(Guid organizationId)
        {
            return await _dbContext.Requests
                .Where(r => r.OrganizationId == organizationId && r.CompletedDate != null)
                .AsNoTracking().ToListAsync();
        }
        public async Task Add(Guid id, string name, string city, string description, List<VolunteerEntity> volunteers, List<RequestEntity> requests)
        {
            var organizationEntity = new OrganizationEntity
            {
                Id = id,
                Name = name,
                City = city,
                Description = description,
                Volunteers = volunteers ?? new List<VolunteerEntity>(),
                Requests = requests ?? new List<RequestEntity>()
            };
            await _dbContext.AddAsync(organizationEntity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task Update(Guid id, string name, string city, string description, List<VolunteerEntity> volunteers, List<RequestEntity> requests)
        {
            var organization = await _dbContext.Organizations
            .Include(o => o.Volunteers)
            .Include(o => o.Requests)
            .FirstOrDefaultAsync(o => o.Id == id);
            if (organization != null)
            {
                organization.Name = name;
                organization.City = city;
                organization.Description = description;
                organization.Volunteers = volunteers;
                organization.Requests = requests;
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task Delete(Guid id) 
        {
            await _dbContext.Organizations.Where(x => x.Id == id).ExecuteDeleteAsync();
        }
    }
}
