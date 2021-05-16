using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PersonalFinanceTracker.Login.Api.Models
{
    public class LoginDbContext : IdentityDbContext<ApplicationUser>
    {
        public LoginDbContext(DbContextOptions<LoginDbContext> options) : base(options)
        {
        }
    }
}
