using Microsoft.EntityFrameworkCore;
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
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _requestsRepository;

        public RequestService(IRequestRepository requestsRepository)
        {
            _requestsRepository = requestsRepository;
        }

        public async Task<List<RequestEntity>> Get()
        {
            return await _requestsRepository.Get();
        }

        public async Task<RequestEntity?> GetById(Guid id)
        {
            return await _requestsRepository.GetById(id);
        }

        
        public async Task<List<RequestEntity>> GetByStatus(bool isActive)
        {
            return await _requestsRepository.GetByStatus(isActive);
        }

        public async Task<List<RequestEntity>> GetByVolunteerId(Guid volunteerId)
        {
            return await _requestsRepository.GetByVolunteerId(volunteerId);
        }

        public async Task<List<RequestEntity>> GetByOrganizationId(Guid organizationId)
        {
            return await _requestsRepository.GetByOrganizationId(organizationId);
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
            if (id == Guid.Empty) throw new ArgumentException("ID не может быть пустым.");
            if (string.IsNullOrWhiteSpace(shortDescription)) throw new ArgumentException("Краткое описание обязательно.");
            if (string.IsNullOrWhiteSpace(longDescription)) throw new ArgumentException("Длинное описание обязательно.");
            if (submissionDate > DateTime.Now) throw new ArgumentException("Дата подачи не может быть в будущем.");
            if (dueDate.HasValue && dueDate < submissionDate) throw new ArgumentException("Дата завершения не может быть раньше даты подачи.");

            await _requestsRepository.Add(id, shortDescription, longDescription, submissionDate, dueDate, isActive, militaryUnitId, organizationId, volunteerId);
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
            await _requestsRepository.Update(id, shortDescription, longDescription, submissionDate, dueDate, isActive, militaryUnitId, organizationId, volunteerId);
        }

        public async Task Delete(Guid id)
        {
            await _requestsRepository.Delete(id);
        }
    }
}
