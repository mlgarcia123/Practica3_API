using Microsoft.EntityFrameworkCore;
using Practica3_PlaylistAPI.Entities;

namespace Practica3_PlaylistAPI.DbContexts
{
    public class CantanteInfoContext : DbContext
    {
        public DbSet<Cantante> Cantantes { get; set; } = null!;
        public DbSet<Cancion> Canciones { get; set; } = null!;

        public CantanteInfoContext(DbContextOptions<CantanteInfoContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cantante>().HasData(
                new Cantante("Rihanna")
                {
                    Id = 1
                },
                new Cantante("Beyonce")
                {
                    Id = 2
                    
                },
                new Cantante("Maroon 5")
                {
                    Id = 3
                    
                });

            modelBuilder.Entity<Cancion>()
             .HasData(
               new Cancion("Umbrella")
               {
                   Id = 1,
                   CantanteId = 1,
                   Estreno = 2007
               },
               new Cancion("Diamonds")
               {
                   Id = 2,
                   CantanteId = 1,
                   Estreno = 2012
               },
                 new Cancion("Single Ladies")
                 {
                     Id = 3,
                     CantanteId = 2,
                     Estreno = 2008
                 },
               new Cancion("Run the World")
               {
                   Id = 4,
                   CantanteId = 2,
                   Estreno = 2011
               },
               new Cancion("Girls Like You")
               {
                   Id = 5,
                   CantanteId = 3,
                   Estreno = 2017
               },
               new Cancion("Animals")
               {
                   Id = 6,
                   CantanteId = 3,
                   Estreno = 2015
               }
               );
            base.OnModelCreating(modelBuilder);
        }

    }
}
