using IndividualsApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace IndividualsApi.Data
{
    public class IndividualsContext : DbContext
    {
        public IndividualsContext(DbContextOptions<IndividualsContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Individual> Individuals { get; set; }
        public DbSet<Relation> Relations { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Phone> Phones { get; set; }
    }
}
