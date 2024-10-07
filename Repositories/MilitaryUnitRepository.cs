using ProjectLibrary.Models;
using Microsoft.EntityFrameworkCore;
using ProjectLibrary.Repositories.Interfaces;
using ProjectLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Repositories
{
    public class MilitaryUnitRepository : IMilitaryUnitRepository
    {
        private readonly ProjectDbContext _dbContext;
        public MilitaryUnitRepository(ProjectDbContext dbContext) { _dbContext = dbContext; }
        public async Task<List<MilitaryUnitEntity>> Get()
        {
            return await _dbContext.MilitaryUnits.AsNoTracking().ToListAsync();
        }
        public async Task<MilitaryUnitEntity?> GetById(Guid id)
        {
            return await _dbContext.MilitaryUnits.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<RequestEntity>> GetRequestsByMilitaryUnit(Guid militaryUnitId, bool isActive)
        {
            return await _dbContext.Requests
                .Where(r => r.MilitaryUnitId == militaryUnitId && r.IsActive == isActive)
                .AsNoTracking().ToListAsync();
        }

        public async Task Add(Guid id, Guid contactPersonId, string name, List<RequestEntity> requests)
        {
            var militaryUnitEntity = new MilitaryUnitEntity
            {
                Id = id,
                Name = name,
                ContactPersonId = contactPersonId,
                Requests = requests ?? new List<RequestEntity>()
            };
            await _dbContext.AddAsync(militaryUnitEntity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task Update(Guid id, Guid contactPersonId, string name, List<RequestEntity> requests)
        {
            var militaryUnit = await _dbContext.MilitaryUnits
            .Include(o => o.ContactPerson)
            .Include(o => o.Requests)
            .FirstOrDefaultAsync(o => o.Id == id);
            if (militaryUnit != null)
            {
                militaryUnit.Name = name;
                militaryUnit.Id = id;
                militaryUnit.ContactPersonId = contactPersonId;
                militaryUnit.Requests = requests;
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task Delete(Guid id)
        {
            await _dbContext.MilitaryUnits.Where(x => x.Id == id).ExecuteDeleteAsync();
        }
    }
}
