using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Practica3_PlaylistAPI.Controllers;
using Practica3_PlaylistAPI.Entities;
using Practica3_PlaylistAPI.Models;
using Practica3_PlaylistAPI.Profiles;
using Practica3_PlaylistAPI.Services;
using Xunit;

namespace TestPlaylistAPI.ControllerTests
{
    public class CantanteTest
    {
        private CantantesController _cantantesController;

        public CantanteTest()
        {
            var cantanteInfoMock = new Mock<ICantanteInfoRepository>();
            cantanteInfoMock.Setup(c => c.GetCantantesAsync()).ReturnsAsync(new List<Cantante>() {
                new Cantante("Rihanna")
                {
                    Id = 1
                }
            });

            var mapperConf = new MapperConfiguration(cfg => cfg.AddProfile<CantanteProfile>());
            var mapper = new Mapper(mapperConf);

            _cantantesController = new CantantesController(cantanteInfoMock.Object, mapper);
        }

        [Fact]
        public void checkCantanteName()
        {
            // Arrange
            CantanteDto cantante = new CantanteDto()
            {
                Name = "Rihanna"
            };

            // Act
            var length = cantante.Name.Length;

            // Assert
            Assert.True(length >= 3);
        }

        [Fact]
        public async Task GetCantante_ReturnOk()
        {
            // Arrange
            int cantanteId = 1;

            // Act
            var cantante = await _cantantesController.GetCantante(cantanteId);


            // Assert
            Assert.NotNull(cantante);
        }

        [Fact]
        public async Task GetCantante_ReturnNotFound()
        {
            // Arrange
            int cantanteId = 8;

            // Act
            var cantante = await _cantantesController.GetCantante(cantanteId);

            // Assert
            Assert.IsType<NotFoundResult>(cantante);
        }

    }

        
}