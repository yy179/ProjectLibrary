using ProjectLibrary.Models;
using Microsoft.EntityFrameworkCore;
using ProjectLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectLibrary.Repositories.Interfaces;

namespace ProjectLibrary.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly ProjectDbContext _dbContext;
        public RequestRepository(ProjectDbContext dbContext) { _dbContext = dbContext; }
        public async Task<List<RequestEntity>> Get()
        {
            return await _dbContext.Requests.AsNoTracking().ToListAsync();
        }
        public async Task<RequestEntity?> GetById(Guid id)
        {
            return await _dbContext.Requests.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<RequestEntity>> GetByStatus(bool isActive)
        {
            return await _dbContext.Requests
                .Where(r => r.IsActive == isActive)
                .AsNoTracking().ToListAsync();
        }
        
        public async Task<List<RequestEntity>> GetByVolunteerId(Guid volunteerId)
        {
            return await _dbContext.Requests
                .Where(r => r.VolunteerId == volunteerId)
                .AsNoTracking().ToListAsync();
        }

        public async Task<List<RequestEntity>> GetByOrganizationId(Guid organizationId)
        {
            return await _dbContext.Requests
                .Where(r => r.OrganizationId == organizationId)
                .AsNoTracking().ToListAsync();
        }
        public async Task Add(
        Guid id,
        string shortDescription,
        string longDescription,
        DateTime submissionDate,
        DateTime? dueDate,
        bool isActive,
        Guid militaryUnitId,
        Guid? organizationId,
        Guid? volunteerId)
        {
            var requestEntity = new RequestEntity
            {
                Id = id,
                ShortDescription = shortDescription,
                LongDescription = longDescription,
                SubmissionDate = submissionDate,
                DueDate = dueDate,
                IsActive = isActive,
                MilitaryUnitId = militaryUnitId,
                OrganizationId = organizationId ?? Guid.Empty,
                VolunteerId = volunteerId ?? Guid.Empty,
            };
            await _dbContext.AddAsync(requestEntity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task Update(
        Guid id,
        string shortDescription,
        string longDescription,
        DateTime submissionDate,
        DateTime? dueDate,
        bool isActive,
        Guid militaryUnitId,
        Guid? organizationId,
        Guid? volunteerId)
        {
            var request = await _dbContext.Requests
            .Include(r => r.MilitaryUnit)
            .Include(r => r.Organization)
            .Include(r => r.Volunteer)
            .FirstOrDefaultAsync(r => r.Id == id);
            if (request != null)
            {
                request.ShortDescription = shortDescription;
                request.LongDescription = longDescription;
                request.DueDate = dueDate;
                request.IsActive = isActive;
                request.MilitaryUnitId = militaryUnitId;
                request.OrganizationId = organizationId ?? Guid.Empty;
                request.VolunteerId = volunteerId ?? Guid.Empty;
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task Delete(Guid id)
        {
            await _dbContext.Requests.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

    }
}
