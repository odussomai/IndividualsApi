using System;
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
            modelBuilder.Entity<Individual>(i =>
            {
                i.HasData(new Individual
                {
                    Id = 1,
                    DateOfBirth = new DateTime(1991, 5, 5),
                    FirstName = "Aleksandre",
                    LastName = "Tsereteli",
                    PersonalId = "01024080411",
                    Sex = BinarySex.Male,
                    Image = "",
                });

                i.OwnsOne(c => c.City).HasData(new City
                {
                    Id = 1,
                    Name = "Tbilisi",
                });

                //i.OwnsMany(p => p.PhoneNumbers).HasData(
                //    new
                //    {
                //        Id = 1,
                //        IndividualId = 1,
                //        PhoneNumber = "598499901"
                //    },
                //    new 
                //    {
                //        Id = 2,
                //        IndividualId = 1,
                //        PhoneNumber = "577676767"
                //    });


            });

            modelBuilder.Entity<Phone>().HasData(new
            {
                Id = 1,
                IndividualId = 1,
                PhoneNumber = "598499901",
                Type = PhoneType.Mobile,
            },
            new
            {
                Id = 2,
                IndividualId = 1,
                PhoneNumber = "577676767",
                Type = PhoneType.Home,
            });
        }

        public DbSet<Individual> Individuals { get; set; }
        public DbSet<Relation> Relations { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Phone> Phones { get; set; }
    }
}
