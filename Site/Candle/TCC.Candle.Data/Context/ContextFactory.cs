using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;

namespace TCC.Candle.Data
{
    internal class ContextFactory : IDesignTimeDbContextFactory<CandleContext>
    {
        private IConfiguration config;
        public ContextFactory()
        {
            var BaseDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(BaseDirectory.FullName);
            builder.AddJsonFile("appsettings.json");
            config = builder.Build();
        }
        public CandleContext CreateDbContext(string[] args)
        {
            // Connection String is Obtained from the appsettings.json file in the Presentation Layer
            var options = new DbContextOptionsBuilder();
            options.UseSqlServer(config.GetConnectionString("Default"));
            return new CandleContext(options.Options);
        }
    }
}
