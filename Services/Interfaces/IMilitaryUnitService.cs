using ProjectLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Services.Interfaces
{
    public interface IMilitaryUnitService
    {
        Task<List<MilitaryUnitEntity>> Get();
        Task<MilitaryUnitEntity?> GetById(Guid id);
        Task<List<RequestEntity>> GetRequestsByMilitaryUnit(Guid militaryUnitId, bool isActive);
        Task Add(Guid id, Guid contactPersonId, string name, List<RequestEntity> requests);
        Task Update(Guid id, Guid contactPersonId, string name, List<RequestEntity> requests);
        Task Delete(Guid id);
    }
}
