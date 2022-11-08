using Practica3_PlaylistAPI.Models;

namespace Practica3_PlaylistAPI
{
    public class CantantesDataStore
    {
        public List<CantanteDto> Cantantes { get; set; }

        //public static CantantesDataStore Current { get; } = new CantantesDataStore();

        public CantantesDataStore()
        {
            // init dummy data
            Cantantes = new List<CantanteDto>()
            {
                new CantanteDto()
                {
                     Id = 1,
                     Name = "Rihanna",
                     Canciones = new List<CancionDto>()
                     {
                         new CancionDto() {
                             Id = 1,
                             Name = "Umbrella",
                             Estreno = 2007 },
                          new CancionDto() {
                             Id = 2,
                             Name = "Diamonds",
                             Estreno = 2012 },
                     }
                },
                new CantanteDto()
                {
                    Id = 2,
                    Name = "Beyonce",
                    Canciones = new List<CancionDto>()
                     {
                         new CancionDto() {
                             Id = 3,
                             Name = "Single Ladies",
                             Estreno = 2008 },
                          new CancionDto() {
                             Id = 4,
                             Name = "Run the World",
                             Estreno = 2011 },
                     }
                },
                new CantanteDto()
                {
                    Id= 3,
                    Name = "Maroon 5",
                    Canciones = new List<CancionDto>()
                     {
                         new CancionDto() {
                             Id = 5,
                             Name = "Girls Like You",
                             Estreno = 2017 },
                          new CancionDto() {
                             Id = 6,
                             Name = "Animals",
                             Estreno = 2015 },
                     }
                }
            };

        }
    }
}
