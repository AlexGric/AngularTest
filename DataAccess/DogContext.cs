using Microsoft.Extensions.Configuration;
using DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class DogContext : DbContext
    {
        IConfiguration _configuration;

        public DogContext(IConfiguration configuration) : base()
        {
            this._configuration = configuration;
            DbInitializer.Initialize(this);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Dog> Dogs { get; set; }
    }
}
