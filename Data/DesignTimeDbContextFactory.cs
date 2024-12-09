using gerenciamentoapirest.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace gerenciamentoapirest
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApiDbContext>
    {
        public ApiDbContext CreateDbContext(string[] args)
        {
            // Define o caminho para o arquivo appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Configura o DbContext com a string de conexão do appsettings.json
            var builder = new DbContextOptionsBuilder<ApiDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseNpgsql(connectionString); // Certificando-se de que está usando o Npgsql para PostgreSQL

            return new ApiDbContext(builder.Options);
        }
    }
}
