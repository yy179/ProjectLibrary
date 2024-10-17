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
    public class ContactPersonService : IContactPersonService
    {
        private readonly IContactPersonRepository _contactPersonsRepository;

        public ContactPersonService(IContactPersonRepository contactPersonsRepository)
        {
            _contactPersonsRepository = contactPersonsRepository;
        }

        public async Task<List<ContactPersonEntity>> Get()
        {
            return await _contactPersonsRepository.Get();
        }

        public async Task<ContactPersonEntity?> GetById(Guid id)
        {
            return await _contactPersonsRepository.GetById(id);
        }

        public async Task Add(Guid id, Guid? militaryUnitId, string name, string surname, DateTime dateOfBirth, string address)
        {
            if (id == Guid.Empty) throw new ArgumentException("ID не может быть пустым.");
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Имя обязательно.");
            if (string.IsNullOrWhiteSpace(surname)) throw new ArgumentException("Фамилия обязательна.");
            if (string.IsNullOrWhiteSpace(address)) throw new ArgumentException("Адрес обязателен.");
            await _contactPersonsRepository.Add(id, militaryUnitId, name, surname, dateOfBirth, address);
        }

        public async Task Update(Guid id, Guid? militaryUnitId, string name, string surname, DateTime dateOfBirth, string address)
        {
            await _contactPersonsRepository.Update(id, militaryUnitId, name, surname, dateOfBirth, address);
        }

        public async Task Delete(Guid id)
        {
            await _contactPersonsRepository.Delete(id);
        }
    }
}
