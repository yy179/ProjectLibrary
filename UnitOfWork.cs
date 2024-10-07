using ProjectLibrary.Repositories.Interfaces;
using ProjectLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjectDbContext _context;

        public UnitOfWork(ProjectDbContext context)
        {
            _context = context;
        }

        public IOrganizationsRepository OrganizationsRepository { get; }
        public IVolunteersRepository VolunteersRepository { get; }
        public IRequestRepository RequestRepository { get; }
        public IMilitaryUnitRepository MilitaryUnitRepository { get; }
        public IContactPersonRepository ContactPersonRepository { get; }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync()
        {
            await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            await _context.Database.CommitTransactionAsync();
        }

        public async Task RollbackAsync()
        {
            await _context.Database.RollbackTransactionAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
