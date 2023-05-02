using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TP2.Models;

namespace TP2.Data
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options)
            : base(options)
        {
        }

        public DbSet<TP2.Models.Car> Car { get; set; } = default!;

        public DbSet<TP2.Models.Brand> Brand { get; set; } = default!;

        // Relación one to one Un auto un solo motor y visceversa.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
            .HasOne(p => p.Motor)
            .WithOne(p => p.Car)
            .HasForeignKey<Motor>(p => p.CarId)
            .IsRequired();
        }

        // Relación one to many - (Un Auto una marca). Una Marca Varios autos.
        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Brand>()
        //     .HasMany(p => p.Cars)
        //     .WithOne(p => p.Brand)
        //     .HasForeignKey(p => p.BrandId)
        //     .IsRequired();
        // }


    }
}
