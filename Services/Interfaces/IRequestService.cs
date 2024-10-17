using ProjectLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Services.Interfaces
{
    public interface IRequestService
    {
        Task<List<RequestEntity>> Get();
        Task<RequestEntity?> GetById(Guid id);
        Task<List<RequestEntity>> GetByStatus(bool isActive);
        Task<List<RequestEntity>> GetByVolunteerId(Guid volunteerId);
        Task<List<RequestEntity>> GetByOrganizationId(Guid organizationId);
        Task<IEnumerable<RequestEntity>> GetByMilitaryUnitId(Guid militaryUnitId);
        Task Add(
        Guid id,
        string shortDescription,
        string longDescription,
        DateTime submissionDate,
        DateTime? dueDate,
        bool isActive,
        Guid militaryUnitId,
        Guid? organizationId,
        Guid? volunteerId);
        Task Update(
        Guid id,
        string shortDescription,
        string longDescription,
        DateTime submissionDate,
        DateTime? dueDate,
        bool isActive,
        Guid militaryUnitId,
        Guid? organizationId,
        Guid? volunteerId);
        Task Delete(Guid id);
    }
}
