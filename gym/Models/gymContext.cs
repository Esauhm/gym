using Microsoft.EntityFrameworkCore;

namespace gym.Models
{
    public class gymContext : DbContext
    {

        public gymContext(DbContextOptions<gymContext> options): base(options) 
        { 
        
        }

        public DbSet<categoria> categoria { get; set; }

        public DbSet<ejercicios> ejercicios { get; set; }

        public DbSet<usuarios> usuarios { get; set; }


    }
}
