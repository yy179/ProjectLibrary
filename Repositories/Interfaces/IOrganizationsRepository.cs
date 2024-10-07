using ProjectLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Repositories.Interfaces
{
    public interface IOrganizationsRepository
    {
        Task<List<OrganizationEntity>> Get();
        Task<OrganizationEntity?> GetById(Guid id);
        Task<List<VolunteerEntity>> GetVolunteersByOrganization(Guid organizationId);
        Task<List<RequestEntity>> GetActiveRequestsByOrganization(Guid organizationId);
        Task<List<RequestEntity>> GetCompletedRequestsByOrganization(Guid organizationId);
        Task Add(Guid id, string name, string city, string description, List<VolunteerEntity> volunteers, List<RequestEntity> requests);
        Task Update(Guid id, string name, string city, string description, List<VolunteerEntity> volunteers, List<RequestEntity> requests);
        Task Delete(Guid id);
    }
}
