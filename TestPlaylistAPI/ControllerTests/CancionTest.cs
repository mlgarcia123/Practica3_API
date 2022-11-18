using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Practica3_PlaylistAPI.Controllers;
using Practica3_PlaylistAPI.Entities;
using Practica3_PlaylistAPI.Models;
using Practica3_PlaylistAPI.Profiles;
using Practica3_PlaylistAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPlaylistAPI.ControllerTests
{
    public class CancionTest
    {
        private CantantesController _cantantesController;
        private CancionesController _cancionesController;
        public CancionTest()
        {
            var cantanteInfoMock = new Mock<ICantanteInfoRepository>();
            cantanteInfoMock.Setup(m => m.GetCantantesAsync())
                .ReturnsAsync(new List<Cantante>() {
                new Cantante("Rihanna")
                {
                    Id = 1
                }
                });

            cantanteInfoMock.Setup(c => c.GetCancionesForCantanteAsync(1))
                .ReturnsAsync(new List<Cancion>() {
                    new Cancion("Pelicula1")
                    {
                        Id = 1
                    }
                });


            var mapperConf = new MapperConfiguration(cfg => cfg.AddProfile<CantanteProfile>());
            var mapper = new Mapper(mapperConf);
            var loggerMock = new Mock<ILogger<CancionesController>>();

            _cantantesController = new CantantesController(cantanteInfoMock.Object, mapper);
            _cancionesController = new CancionesController(loggerMock.Object, cantanteInfoMock.Object, mapper);
        }

        [Fact]
        public void checkCancionName()
        {
            // Arrange
            CancionForCreationDto cancion = new CancionForCreationDto()
            {
                Name = "Umbrella"
            };

            // Act
            var length = cancion.Name.Length;

            // Assert
            Assert.True(length <= 100);
        }

        [Fact]
        public async Task GetCancion_ReturnOk()
        {
            // Arrange
            int cantanteId = 1;
            int cancionId = 1;

            // Act
            var cancion = await _cancionesController.GetCancion(cantanteId, cancionId);


            // Assert
            Assert.NotNull(cancion);
        }

        [Fact]
        public async Task GetCancion_NameOk()
        {
            // Arrange
            CancionForCreationDto newCancion = new CancionForCreationDto() { Name = "Umbrella" };

            // Assert
            Assert.Equal("Umbrella", newCancion.Name);
        }

    }

    
}
