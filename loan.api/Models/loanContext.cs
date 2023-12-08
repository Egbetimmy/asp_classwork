using Microsoft.EntityFrameworkCore;

namespace loan.api.Models
{
    public class loanContext : DbContext
    {
        public loanContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Loan> Loans { get; set; }
    }
}
