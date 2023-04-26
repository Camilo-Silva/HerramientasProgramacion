using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Class6.Models;

namespace Class6.Data
{
    public class MenuContext : DbContext
    {
        public MenuContext(DbContextOptions<MenuContext> options)
            : base(options)
        {
        }

        public DbSet<Class6.Models.Menu> Menu { get; set; } = default!;

        public DbSet<Class6.Models.Restaurant> Restaurant { get; set; } = default!;

        // Configuración de relaciones de uno a muchos
        // Variables de configuracion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>()
            .HasMany(p => p.Restaurants)
            .WithOne(p => p.Menu)
            .HasForeignKey(p => p.MenuId);
        }
    }
}
