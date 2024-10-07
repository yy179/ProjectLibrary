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
    public class VolunteerService : IVolunteerService
    {
        private readonly IVolunteersRepository _volunteerRepository;
        public VolunteerService(IVolunteersRepository volunteersRepository)
        {
            _volunteerRepository = volunteersRepository;
        }
        public async Task<List<VolunteerEntity>> Get()
        {
            return await _volunteerRepository.Get();
        }
        public async Task<VolunteerEntity?> GetById(Guid id)
        {
            return await _volunteerRepository.GetById(id);
        }
        public async Task Add(Guid id, string name, DateTime dateOfBirth, string city, string biography, List<OrganizationEntity> organizations, List<RequestEntity> requests)
        {
            if (id == Guid.Empty) throw new ArgumentException("ID не может быть пустым.");
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Имя обязательно.");
            if (string.IsNullOrWhiteSpace(city)) throw new ArgumentException("Город обязателен.");
            if (string.IsNullOrWhiteSpace(biography)) throw new ArgumentException("Биография обязательна.");
            var age = DateTime.Now.Year - dateOfBirth.Year;
            if (age < 18)
            {
                throw new InvalidOperationException("Волонтер должен быть старше 18 лет.");
            }

            await _volunteerRepository.Add(id, name, dateOfBirth, city, biography, organizations, requests);
        }
        public async Task Update(Guid id, string name, DateTime dateOfBirth, string city, string biography, List<OrganizationEntity> organizations, List<RequestEntity> requests)
        {
            await _volunteerRepository.Add(id, name, dateOfBirth, city, biography, organizations, requests);
        }
        public async Task Delete(Guid id)
        {
            await _volunteerRepository.Delete(id);
        }
    }
}
