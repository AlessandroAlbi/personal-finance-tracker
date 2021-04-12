using Microsoft.EntityFrameworkCore;
using PersonalFinanceTracker.Accounts.Domain.Entities;

namespace PersonalFinanceTracker.Accounts.Application.Interfaces
{
    public interface IAccountsDbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
    }
}
