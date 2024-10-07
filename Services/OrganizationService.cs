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
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationsRepository _organizationsRepository;

        public OrganizationService(IOrganizationsRepository organizationsRepository)
        {
            _organizationsRepository = organizationsRepository;
        }

        public async Task<List<OrganizationEntity>> Get()
        {
            return await _organizationsRepository.Get();
        }

        public async Task<OrganizationEntity?> GetById(Guid id)
        {
            return await _organizationsRepository.GetById(id);
        }

        public async Task<List<VolunteerEntity>> GetVolunteersByOrganization(Guid organizationId)
        {
            return await _organizationsRepository.GetVolunteersByOrganization(organizationId);
        }

        public async Task<List<RequestEntity>> GetActiveRequestsByOrganization(Guid organizationId)
        {
            return await _organizationsRepository.GetActiveRequestsByOrganization(organizationId);
        }

        public async Task<List<RequestEntity>> GetCompletedRequestsByOrganization(Guid organizationId)
        {
            return await _organizationsRepository.GetCompletedRequestsByOrganization(organizationId);
        }

        public async Task Add(Guid id, string name, string city, string description, List<VolunteerEntity> volunteers, List<RequestEntity> requests)
        {
            if (id == Guid.Empty) throw new ArgumentException("ID не может быть пустым.");
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Имя обязательно.");
            if (string.IsNullOrWhiteSpace(city)) throw new ArgumentException("Город обязателен.");
            if (volunteers == null) throw new ArgumentException("Список волонтеров не может быть пустым.");
            await _organizationsRepository.Add(id, name, city, description, volunteers, requests);
        }

        public async Task Update(Guid id, string name, string city, string description, List<VolunteerEntity> volunteers, List<RequestEntity> requests)
        {
            await _organizationsRepository.Update(id, name, city, description, volunteers, requests);
        }

        public async Task Delete(Guid id)
        {
            await _organizationsRepository.Delete(id);
        }
    }
}
