using MyMvcApp.Application.Interfaces;
using MyMvcApp.Infrastructure.Data;
using MyMvcApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvcApp.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IUserRepository Users { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
        }

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();
    }
}
