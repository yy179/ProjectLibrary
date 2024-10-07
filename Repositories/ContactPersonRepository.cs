using Azure.Core;
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
    public class ContactPersonRepository
    {
        private readonly ProjectDbContext _dbContext;
        public ContactPersonRepository(ProjectDbContext dbContext) { _dbContext = dbContext; }
        public async Task<List<ContactPersonEntity>> Get()
        {
            return await _dbContext.ContactPersons.AsNoTracking().ToListAsync();
        }
        public async Task<ContactPersonEntity?> GetById(Guid id)
        {
            return await _dbContext.ContactPersons.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task Add(Guid id, Guid militaryUnitId, string name, string surname, DateTime dateOfBirth, string address)
        {
            var contactPersonEntity = new ContactPersonEntity
            {
                Id = id,
                MilitaryUnitId = militaryUnitId,
                Name = name,
                Surname = surname,
                DateOfBirth = dateOfBirth,
                Address = address
            };
            await _dbContext.AddAsync(contactPersonEntity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task Update(Guid id, Guid militaryUnitId, string name, string surname, DateTime dateOfBirth, string address)
        {
            var contactPersonUnit = await _dbContext.ContactPersons
            .Include(o => o.MilitaryUnit)
            .FirstOrDefaultAsync(o => o.Id == id);
            if (contactPersonUnit != null)
            {
                contactPersonUnit.Name = name;
                contactPersonUnit.Id = id;
                contactPersonUnit.MilitaryUnitId = militaryUnitId;
                contactPersonUnit.DateOfBirth = dateOfBirth;
                contactPersonUnit.Surname = surname;
                contactPersonUnit.Address = address;
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task Delete(Guid id)
        {
            await _dbContext.ContactPersons.Where(x => x.Id == id).ExecuteDeleteAsync();
        }
    }
}
