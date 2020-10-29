using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using TCC.Candle.Data.Entities;
using TCC.Candle.Data.Repositories;
using TCC.Candle.Data.Repositories.Abstract;
using TCC.Candle.Data.Repositories.Concrete;

namespace TCC.Candle.Data.IOC
{
    public static class ConfigureDI
    {
        public static IServiceCollection AddDataLayerServices(this IServiceCollection services)
        {
            //services.AddScoped(typeof(DbContext), typeof(CandleContext));
            services.AddScoped<IDesignTimeDbContextFactory<CandleContext>, ContextFactory>();
            services.AddScoped<ILibraryRepository, LibraryRepository>();
            services.AddScoped<IShelfRepository, ShelfRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            //services.AddScoped<IRepository<Volume>, Repository<Volume>>();
            //services.AddScoped<IRepository<BookAuthor>, Repository<BookAuthor>>();
            //services.AddScoped<IRepository<Author>, Repository<Author>>();
            //services.AddScoped<IRepository<TaggedBook>, Repository<TaggedBook>>();
            //services.AddScoped<IRepository<Tag>, Repository<Tag>>();
            //services.AddScoped<IRepository<Review>, Repository<Review>>();
            return services;
        }
    }
}
