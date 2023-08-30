using Microsoft.EntityFrameworkCore;

namespace Login.Models
{
    public class Context : DbContext
    {
        public Context()
        { 
        }
        public  DbSet<User> UserModels { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=BijuteriDB;trusted_connection=true;TrustServerCertificate=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
    
    
}
