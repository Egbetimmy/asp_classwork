using Microsoft.EntityFrameworkCore;

namespace bit.userManager.Models
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) 
        {
        }   

        public DbSet<user> Users { get; set; }
    }
}
