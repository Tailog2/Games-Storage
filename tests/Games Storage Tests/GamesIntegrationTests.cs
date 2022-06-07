using Games_Storage.Core.Services.IServices;
using Games_Storage.Persistence;
using Games_Storage_Tests.Factories;
using Games_Storage_Tests.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Respawn;
using Respawn.Graph;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games_Storage_Tests
{
    public class GamesIntegrationTests
    {  
        private readonly TestDataFactory _dataFactory;
        private readonly HttpHelper _httpHelper;
        private readonly ApiWebApplicationFactory _webAppFactory;

        private const string gamesUrl = "https://localhost:7073/api/Games";
        private const string studiosUrl = "https://localhost:7073/api/Studios";

        public GamesIntegrationTests()
        {
            _webAppFactory = new ApiWebApplicationFactory();
            _httpHelper = new HttpHelper();
            _dataFactory = new TestDataFactory();                
        }

        [Fact]
        public async Task GetGames_UseTestDatabase_ReceiveExpectedData()
        {
            // Arrange
            var httpClient = CreateClient();

            // Act
            var response = await httpClient.GetAsync(gamesUrl);

            // Assert
            Assert.Equal(StatusCodes.Status200OK, (int)response.StatusCode);

            var games = await _httpHelper.ConvertResponce<IEnumerable<GameDto>>(response);
            Assert.NotNull(games);
            Assert.NotEmpty(games);
            Assert.Equal(3, games.Count());
        }

        [Fact]
        public async Task PostGame_UseInvalidData_ReceiveStatus400BadReques()
        {
            // Arrange
            var httpClient = CreateClient();
            var games = _dataFactory.CreateInvalidNewGameDto();

            foreach (var game in games)
            {
                // Act
                var content = _httpHelper.ConvertModel(game);
                var response = await httpClient.PostAsync(gamesUrl, content);

                // Assert
                Assert.Equal(StatusCodes.Status400BadRequest, (int)response.StatusCode);
            }
        }

        [Fact]
        public async Task PostGame_UseValidData_ReceiveStatus201Created()
        {
            // Arrange
            var httpClient = CreateClient();
            var games = _dataFactory.CreateValidNewGameDto();

            foreach (var game in games)
            {
                // Act
                var content = _httpHelper.ConvertModel(game);
                var response = await httpClient.PostAsync(gamesUrl, content);

                // Assert
                Assert.Equal(StatusCodes.Status201Created, (int)response.StatusCode);
            }
        }

        [Fact]
        public async Task PostStudio_UseValidData_ReceiveStatus201Created()
        {
            // Arrange
            var httpClient = CreateClient();
            var studios = _dataFactory.CreateValidStudiosDtos();

            foreach (var studio in studios)
            {
                // Act
                var content = _httpHelper.ConvertModel(studio);
                var response = await httpClient.PostAsync(studiosUrl, content);

                // Assert
                Assert.Equal(StatusCodes.Status201Created, (int)response.StatusCode);
            }
        }

        private HttpClient CreateClient()
        {
            var studios = _dataFactory.CreateFillingStudios();
            var games = _dataFactory.CreateFillingGames();

            var scopeFactory = _webAppFactory.Services.GetService<IServiceScopeFactory>();

            using (var scope = scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<SqlDatabaseContext>();
                
                context.Database.EnsureDeleted();

                context.AddRange(studios);
                context.AddRange(games);
                context.Add(new Genre { Id = 1, Name = "Genre 1" });
                context.Add(new Genre { Id = 2, Name = "Genre 2" });
                context.Add(new Genre { Id = 3, Name = "Genre 3" });
                context.Add(new Genre { Id = 4, Name = "Genre 4" });
                context.SaveChanges();

                return _webAppFactory.CreateClient();
            }          
        }
    }
}
