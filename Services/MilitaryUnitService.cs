using ProjectLibrary.Models;
using ProjectLibrary.Repositories;
using ProjectLibrary.Repositories.Interfaces;
using ProjectLibrary.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Services
{
    public class MilitaryUnitService : IMilitaryUnitService
    {
        private readonly IMilitaryUnitRepository _militaryUnitRepository;

        public MilitaryUnitService(IMilitaryUnitRepository militaryUnitRepository)
        {
            _militaryUnitRepository = militaryUnitRepository;
        }

        public async Task<List<MilitaryUnitEntity>> Get()
        {
            return await _militaryUnitRepository.Get();
        }

        public async Task<MilitaryUnitEntity?> GetById(Guid id)
        {
            return await _militaryUnitRepository.GetById(id);
        }

        public async Task<List<RequestEntity>> GetRequestsByMilitaryUnit(Guid militaryUnitId, bool isActive)
        {
            return await _militaryUnitRepository.GetRequestsByMilitaryUnit(militaryUnitId, isActive);
        }

        public async Task Add(Guid id, Guid? contactPersonId, string name, List<RequestEntity> requests)
        {
            if (id == Guid.Empty) throw new ArgumentException("ID не может быть пустым.");
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Имя обязательно.");
            await _militaryUnitRepository.Add(id, contactPersonId, name, requests);
        }

        public async Task Update(Guid id, Guid? contactPersonId, string name, List<RequestEntity> requests)
        {
            await _militaryUnitRepository.Update(id, contactPersonId, name, requests);
        }

        public async Task Delete(Guid id)
        {
            await _militaryUnitRepository.Delete(id);
        }
    }
}
