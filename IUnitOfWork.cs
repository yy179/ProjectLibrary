using ProjectLibrary.Repositories;
using ProjectLibrary.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary
{
    public interface IUnitOfWork : IDisposable
    {
        IOrganizationsRepository OrganizationsRepository { get; }
        IVolunteersRepository VolunteersRepository { get; }
        IRequestRepository RequestRepository { get; }
        IMilitaryUnitRepository MilitaryUnitRepository { get; }
        IContactPersonRepository ContactPersonRepository { get; }

        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
