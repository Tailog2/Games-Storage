using Games_Storage.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games_Storage_Tests.Factories
{
    internal class ApiWebApplicationFactory : WebApplicationFactory<Program>
    {
        public string DbContext 
        {
            get => _dbContext.GetConnectionString("DefaultConnection");
        }

        private IConfiguration _dbContext;

        public ApiWebApplicationFactory()
        {
            _dbContext = CreateConfiguration();     
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration(config => config.AddConfiguration(CreateConfiguration()));
            builder.ConfigureTestServices(services => { });

            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<SqlDatabaseContext>));

                services.Remove(descriptor);

                services.AddDbContext<SqlDatabaseContext>(options =>
                {
                    options.UseInMemoryDatabase("GameStorage_TestDatabase");
                });
            }); 
        }
        private IConfiguration CreateConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables();

            return builder.Build();
        }
    }
}
