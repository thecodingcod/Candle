using Microsoft.Extensions.DependencyInjection;
using TCC.Candle.Logic.Services.Abstract;
using TCC.Candle.Logic.Services.Concrete;

namespace TCC.Candle.Logic.IOC
{
    public static class ConfigureDI
    {
        public static IServiceCollection AddLogicLayerServices(this IServiceCollection services)
        {
            services.AddScoped<ILibraryService, LibraryService>();
            services.AddScoped<IShelfService, ShelfService>();
            services.AddScoped<IBookService, BookService>();
            return services;
        }
    }
}
