using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using PersonalFinanceTracker.Accounts.Infrastructure.Persistance.DataContexts;
using Microsoft.EntityFrameworkCore;

namespace PersonalFinanceTracker.Accounts.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AccountsDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("AnagraphicsDbConnection")));
            return services;
        }
    }
}
