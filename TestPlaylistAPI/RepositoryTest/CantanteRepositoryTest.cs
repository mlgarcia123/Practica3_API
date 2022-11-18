using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Practica3_PlaylistAPI.DbContexts;
using Practica3_PlaylistAPI.Entities;
using Practica3_PlaylistAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPlaylistAPI.RepositoryTest
{
    public class CantanteRepositoryTest : IDisposable
    {

        public CantanteInfoRepository _cantanteInfoRepository;
        public CantanteRepositoryTest()
        {
            var connection = new SqliteConnection("Data source=CantanteInfo.db");
            connection.Open();

            var optionsBuilder = new DbContextOptionsBuilder<CantanteInfoContext>().UseSqlite(connection);
            var dbContext = new CantanteInfoContext(optionsBuilder.Options);
            dbContext.Database.Migrate();

            _cantanteInfoRepository = new CantanteInfoRepository(dbContext);
        }
        public void Dispose()
        {
        }

        [Fact]
        public async Task CheckCanciones()
        {
            // Arrange
            var cantante = await _cantanteInfoRepository.GetCantanteAsync(1, false);

            // Act

            // Assert
            Assert.Empty(cantante.Canciones);
        }

        [Fact]
        public async Task CheckNumCanciones()
        {
            // Arrange
            var cantante = await _cantanteInfoRepository.GetCantanteAsync(1, true);

            // Act
            var numCanciones = cantante.Canciones.Count;

            // Assert
            Assert.True(numCanciones >= 1);
        }

        [Fact]
        public async Task CheckCantanteName()
        {
            // Arrange
            var cantante = await _cantanteInfoRepository.GetCantanteAsync(1, false);

            // Act

            // Assert
            Assert.Equal("Rihanna", cantante.Name);
        }

        [Fact]
        public async Task GetCantante_CheckCantanteNoExist()
        {
            int cantanteId = 15;

            var cantante = await _cantanteInfoRepository.GetCantanteAsync(cantanteId,false);

            Assert.Null(cantante);
        }

    }
}
