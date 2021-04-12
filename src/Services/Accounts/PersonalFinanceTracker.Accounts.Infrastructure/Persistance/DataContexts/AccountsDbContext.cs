using Microsoft.EntityFrameworkCore;
using PersonalFinanceTracker.Accounts.Application.Interfaces;
using PersonalFinanceTracker.Accounts.Domain.Entities;

namespace PersonalFinanceTracker.Accounts.Infrastructure.Persistance.DataContexts
{
    public class AccountsDbContext : DbContext, IAccountsDbContext
    {
        public AccountsDbContext(DbContextOptions<AccountsDbContext> options) : base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
    }
}
