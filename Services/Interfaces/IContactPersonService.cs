using ProjectLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Services.Interfaces
{
    public interface IContactPersonService
    {
        Task<List<ContactPersonEntity>> Get();
        Task<ContactPersonEntity?> GetById(Guid id);
        Task Add(Guid id, Guid militaryUnitId, string name, string surname, DateTime dateOfBirth, string address);
        Task Update(Guid id, Guid militaryUnitId, string name, string surname, DateTime dateOfBirth, string address);
        Task Delete(Guid id);
    }
}
