using Application.Common.Repository;
using Infrastructure.DataAccessManager.EFCore.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccessManager.EFCore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CommandContext _context;

        public UnitOfWork(CommandContext context)
        {
            _context = context;
        }

        public async Task SaveAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
