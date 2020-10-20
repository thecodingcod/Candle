using Microsoft.Extensions.DependencyInjection;

namespace TCC.Candle.Logic.IOC
{
    public static class ConfigureDI
    {
        public static IServiceCollection AddLogicLayerServices(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            return services;
        }
    }
}
