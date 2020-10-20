using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TCC.Candle.Data
{
    internal class ContextFactory : IDesignTimeDbContextFactory<CandleContext>
    {
        private IConfiguration configuration;
        public ContextFactory(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public CandleContext CreateDbContext(string[] args)
        {
            // Connection String is Obtained from the appsettings.json file in the Presentation Layer
            var options = new DbContextOptionsBuilder();
            options.UseSqlServer(configuration.GetConnectionString("Default"));
            return new CandleContext(options.Options);
        }
    }
}
