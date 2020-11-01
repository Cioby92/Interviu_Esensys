using Essensys.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Essensys.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Transaction> Transactions { get; set; }
        public DbSet<Account> Accounts { get; set; }
        DbSet<Token> Tokens { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
